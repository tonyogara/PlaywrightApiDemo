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
        
        PostsClient postsClient = new PostsClient(request);
        var response = await postsClient.GetPostAsync(1);

        Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.OK));

        var responseBody = await response.TextAsync();
        var post = JsonSerializer.Deserialize<Post>(responseBody);

        Assert.That(post, Is.Not.Null);
        Assert.That(post!.Id, Is.EqualTo(1));   
        Assert.That(post.UserId, Is.EqualTo(1));




    }    



}
