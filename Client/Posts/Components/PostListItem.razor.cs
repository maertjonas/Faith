using Faith.Shared.Posts;
using Microsoft.AspNetCore.Components;

namespace Faith.Client.Posts.Components
{
    public partial class PostListItem
    {
        [Parameter] public PostDto.Detail Post { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        //Navigate to detail
        //Open edit form
    }
}
