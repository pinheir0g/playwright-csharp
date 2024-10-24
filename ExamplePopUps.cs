using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playwrightCSharp;

[TestFixture]
internal class ExamplePopUps: PageTest
{
    [Test]
    public async Task ExampleTest()
    {

        // Setup the handler incase overlay appears
        await Page.AddLocatorHandlerAsync(Page.GetByText("Random Popup"),
            async () =>
            {
                await Page.GetByRole(AriaRole.Button, new() { Name = "Close"}).ClickAsync();
            });

        await Page.GotoAsync("https://commitquality.com/practice-random-popup");
        await Task.Delay(6000);
        await Page.GetByTestId("accordion-1").ClickAsync(new () { Timeout = 2000});
    }
}
