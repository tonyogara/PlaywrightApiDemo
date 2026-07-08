using Microsoft.Playwright;

namespace PlaywrightApiDemo.Core
{
    public class ApiFactory
    {
        private readonly IPlaywright _playwright;

        public ApiFactory(IPlaywright playwright)
        {
            _playwright = playwright;
        }

        public async Task<IAPIRequestContext> CreateClient(string baseUrl)
        {
            return await _playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = baseUrl,
                ExtraHTTPHeaders = new Dictionary<string, string>
                {
                    { "Accept", "application/json" }
                }
            });
        }
    }
}