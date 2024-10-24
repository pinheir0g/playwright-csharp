using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace playwrightCSharp;

[TestFixture]
internal class Assertions : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("https://commitquality.com/");
    }

    [Test]
    public async Task AssertPageTitle()
    {
        await Expect(Page).ToHaveTitleAsync(new Regex("CommitQuality"));

        var firstRowName = Page.GetByTestId("name").First;

        await Expect(firstRowName).ToHaveTextAsync("Product 2");
    }

    [Test]
    public async Task EnterPracticeMenuAndGeneralComponents()
    {
        await Page.GetByTestId("navbar-practice").ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*practice"));
    }
}
