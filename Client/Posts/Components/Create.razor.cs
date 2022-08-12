using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Faith.Shared.Posts;

namespace Faith.Client.Posts.Components
{
    public partial class Create
    {
        private PostDto.Create post = new();
        [Inject] public IPostService PostService { get; set; }
        //[Inject] public NavigationManager NavigationManager { get; set; }
        //[Inject] public StorageService StorageService { get; set; }


        private async Task CreatePostAsync()
        {
            PostDto.Create request = new()
            {
                Text = post.Text,
                Date = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                Archive = false,
                Pinned = false,
                Image = ""
            };
            var response = await PostService.AddPostAsync(request);
        }
    }
}
