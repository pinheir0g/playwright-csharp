using Microsoft.Playwright;


namespace playwrightCSharp.Re_useAuth
{
    public class PlaywrightTestBase
    {
        public IBrowser Browser { get; set; }
        protected IPage Page { get; set; }

        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync();

            var context = await Browser.NewContextAsync(new()
            {
                StorageStatePath = Path.Combine(Directory.GetCurrentDirectory(), "storageState.json")
            });

            Page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Page.CloseAsync();
            await Browser.CloseAsync();
        }
    }
}
