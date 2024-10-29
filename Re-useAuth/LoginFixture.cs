using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace playwrightCSharp.Re_useAuth
{
    [SetUpFixture]
    public class LoginFixture
    {
        public IPlaywright Pw { get; set; }
        public IBrowser Browser { get; set; }

        [OneTimeSetUp]
        public async Task Login()
        {
            Pw = await Playwright.CreateAsync();
            Browser = await Pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await Browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://commitquality.com/login");
            await page.GetByTestId("username-textbox").FillAsync("test");
            await page.GetByTestId("password-textbox").FillAsync("test");
            await page.GetByTestId("login-button").ClickAsync();


            await context.StorageStateAsync(new()
            {
                //Path = "../../../playwright/.auth/state.json"
                Path = Path.Combine(Directory.GetCurrentDirectory(), "storageState.json")
            });

            await page.CloseAsync();
            await Browser.CloseAsync();
        }
    }
}
