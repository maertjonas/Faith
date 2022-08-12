using Faith.Shared.Posts;
using Faith.Shared.Users;
using Microsoft.AspNetCore.Components;

namespace Faith.Client.Users
{
    public partial class Index
    {
        [Inject] public IUserService? UserService { get; set; }

        public List<UserDto.Index>? users;

        protected override async Task OnInitializedAsync()
        {
            users = await UserService!.GetIndexAsync();
        }
    }
}
