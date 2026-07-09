using System.Reflection;
using System.Text.Json;
using System.Net;
using static System.Net.HttpStatusCode;
using NUnit.Framework;
using PlaywrightApiDemo.Core;
using PlaywrightApiDemo.Clients;
using PlaywrightApiDemo.Models;



namespace PlaywrightApiDemo.Tests;

 [TestFixture]
public class PostTests : ApiTestBase
{ 
    [Test]
    public async Task Get_Post_By_Id_Should_Be_Valid()
    {
        System.Console.WriteLine("000000");
        PostsClient postsClient = new PostsClient(request);
        var response = await postsClient.GetPostAsync(1);
        
        Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.OK));
 //System.Console.WriteLine("1111111");
        var responseBody = await response.TextAsync();
        var post = JsonSerializer.Deserialize<Post>(responseBody);
        
        //TestContext.Progress.WriteLine("000000");
        //TestContext.Progress.WriteLine($"Status: {response.Status}");
        //TestContext.Progress.WriteLine($"Id: {post?.Id}");
        
        System.Console.WriteLine("post.Id: " + post?.Id);
        System.Console.WriteLine("post.Title: " + post?.Title);
        System.Console.WriteLine("post.Body: " + post?.Body);
        System.Console.WriteLine("post.UserId: " + post?.UserId);

        Assert.That(post, Is.Not.Null);
        Assert.That(post!.Id, Is.EqualTo(0));   
        Assert.That(post.UserId, Is.EqualTo(0));
        

    }    

}
