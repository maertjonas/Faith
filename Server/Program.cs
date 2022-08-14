using Faith.Shared.Posts;
using Faith.Shared.Users;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service.Data;
using Service.Posts;
using Service.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using FluentAssertions.Common;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

ConfigurationManager configuration = builder.Configuration;

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie().AddJwtBearer(options =>
{
    options.Authority = "https://dev-x6u3v-fg.us.auth0.com/";
    options.Audience = "https://api.faith.com";
})
   .AddOpenIdConnect("Auth0", options =>
   {
       // Set the authority to your Auth0 domain
       options.Authority = $"https://{configuration["Auth0:Domain"]}";

       // Configure the Auth0 Client ID and Client Secret
       options.ClientId = configuration["Auth0:ClientId"];
       options.ClientSecret = configuration["Auth0:ClientSecret"];

       // Set response type to code
       options.ResponseType = "code";

       // Configure the scope
       options.Scope.Clear();
       options.Scope.Add("openid");

       // Set the callback path, so Auth0 will call back to http://localhost:5000/callback
       options.CallbackPath = new PathString("/callback");

       // Configure the Claims Issuer to be Auth0
       options.ClaimsIssuer = "Auth0";

       options.Events = new OpenIdConnectEvents
       {
           // handle the logout redirection
           OnRedirectToIdentityProviderForSignOut = (context) =>
           {
               var logoutUri = $"https://{configuration["Auth0:Domain"]}/v2/logout?client_id={configuration["Auth0:ClientId"]}";

               var postLogoutUri = context.Properties.RedirectUri;
               if (!string.IsNullOrEmpty(postLogoutUri))
               {
                   if (postLogoutUri.StartsWith("/"))
                   {
                       // transform to absolute
                       var request = context.Request;
                       postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                   }
                   logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
               }

               context.Response.Redirect(logoutUri);
               context.HandleResponse();

               return Task.CompletedTask;
           }
       };
   });

builder.Services.AddAuth0AuthenticationClient(config =>
{
    config.Domain = builder.Configuration["Auth0:Authority"];
    config.ClientId = builder.Configuration["Auth0:ClientId"];
    config.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
});

builder.Services.AddAuth0ManagementClient().AddManagementAccessToken();

builder.Services.AddHttpContextAccessor();

//DbContext
builder.Services.AddDbContext<ApplicationContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("FaithDb")));


builder.Services.AddScoped<DbInitializer>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();

// Fluentvalidation middleware?

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Faith Api",
        Description = "",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    options.CustomSchemaIds(type => type.ToString());
    options.UseInlineDefinitionsForEnums();
});

builder.Services.ConfigureSwaggerGen(options =>
{
    options.CustomSchemaIds(x => $"{x.DeclaringType.Name}.{x.Name}");

});


var app = builder.Build();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    /*app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("./swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });*/

}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

// Cookie, authentication and authorization middleware
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Seed();

app.Run();
