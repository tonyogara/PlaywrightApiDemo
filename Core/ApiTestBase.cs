using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightApiDemo.Core;

public class ApiTestBase
{
    protected IPlaywright _playwright;
    protected IAPIRequestContext request;

    protected ApiFactory _apiFactory;

    [SetUp]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        

        _apiFactory = new ApiFactory(_playwright);

        request = await _apiFactory.CreateClient("https://jsonplaceholder.typicode.com");

        

        /*
        request = await _playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            BaseURL = "https://jsonplaceholder.typicode.com/",
            ExtraHTTPHeaders = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            }
        });
        */
    }

    [TearDown]
    public async Task TearDown()
    {
        await request.DisposeAsync();
        _playwright.Dispose();
    }
}
