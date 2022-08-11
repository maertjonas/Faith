using Faith.Shared.Posts;
using Microsoft.AspNetCore.Components;

namespace Faith.Client.Posts
{
    public partial class Index
    {

        [Inject] public IPostService PostService { get; set; }

        public PostDto.Detail post;

        protected override async Task OnInitializedAsync()
        {
            post = await PostService.GetPostAsync(1);
        }
    }
}
