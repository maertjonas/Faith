using Faith.Shared.Posts;
using Microsoft.AspNetCore.Components;

namespace Faith.Client.Posts
{
    public partial class Index
    {

        [Inject] public IPostService? PostService { get; set; }

        public List<PostDto.Detail>? posts;

        protected override async Task OnInitializedAsync()
        {
            posts = await PostService.GetPostAsync();
        }


    }
}
