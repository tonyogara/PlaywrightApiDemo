
using Microsoft.Playwright;
using PlaywrightApiDemo.Models;


namespace PlaywrightApiDemo.Clients;


public class PostsClient
{
    private readonly IAPIRequestContext _request;

    public PostsClient(IAPIRequestContext request)
    {
        _request = request;
    }

    public async Task<IAPIResponse> GetPostAsync(int postId)
    {
        System.Console.WriteLine("eeeee");
        return await _request.GetAsync($"/posts/{postId}");
    }


    public async Task<IAPIResponse> GetAllPostsAsync()
    {
        return await _request.GetAsync("/posts");
    }


    public async Task<IAPIResponse> CreatePostAsync(Post post)
    {
        var postData = new
        {
            userId = post.UserId,
            title = post.Title,
            body = post.Body
        };

        return await _request.PostAsync("/posts", new APIRequestContextOptions
        {
            DataObject = postData
        });
    }   

}