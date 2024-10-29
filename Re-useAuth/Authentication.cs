using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace playwrightCSharp.Re_useAuth;

[TestFixture]
public class Authentication: PlaywrightTestBase
{
    [Test]
    public async Task ReUseState()
    {
        await Page.GotoAsync("https://commitquality.com/");
        Assert.IsTrue(await Page.GetByText("Logout").IsVisibleAsync(), "Logout text should be visible on the page");
    }
}