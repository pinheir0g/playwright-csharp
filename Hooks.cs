using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playwrightCSharp;

[TestFixture]
public class Hooks: PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("https://commitquality.com/");
        Console.WriteLine(Page.Url);
    }


    [Test]
    public async Task ExampleTest()
    {
        await Page.GotoAsync("https://commitquality.com/");
        Console.WriteLine(Page.Url);
    }

    [Test]
    public async Task ExampleTest2()
    {
        await Page.GotoAsync("https://commitquality.com/");
        Console.WriteLine(Page.Url);
    }
}

