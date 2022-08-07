namespace Services.Data
{
    public static class Extensions
    {
        public static void Seed(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<ApplicationContext>();
                    context.Database.EnsureCreated();
                    Console.WriteLine("CALLED");
                    var dbInit = new DbInitializer(context);
                    dbInit.SeedData();
                }
            }
        }
    }
}
