using Microsoft.Playwright;
using NUnit.Framework;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using PlaywrightApiDemo.Tests.Models;

namespace PlaywrightApiDemo.Tests
{
    //[TestFixture]

    public class ApiTests
    {
        private IPlaywright _playwright;
        private IAPIRequestContext request;
    
    
    //    private IBrowser _browser;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            
            request = await _playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                //BaseURL = "https://demo.reqres.in",
                BaseURL = "https://jsonplaceholder.typicode.com/",
                ExtraHTTPHeaders = new Dictionary<string, string>
                {
                    //{ "Accept", "application/json" }
                   // {"x-api-key", "reqres-free-v1"}
                }
            });

        }

        

        [Test]
        public async Task TestGetRequest()
        {
            
            //var response = await request.GetAsync("/api/users/2");
            var response = await request.GetAsync("/posts/1");

            var responseBody = await response.TextAsync();

            
            Post? post = JsonSerializer.Deserialize<Post>(responseBody);
            System.Console.WriteLine($"Post ID: {post.Id}");
            
            Assert.That(post, Is.Not.Null);
            Assert.That(post!.Id, Is.EqualTo(0));            


        Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.OK));
        Assert.That(response.Headers["content-type"], Is.EqualTo("application/json; charset=utf-8"));
        



        }


        [TearDown]
        public async Task Teardown()
        {
            await request.DisposeAsync();
        _playwright.Dispose();
        }


    }
}