using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playwrightCSharp;

[TestFixture]
internal class DownloadFile: PageTest
{
    [Test]
    public async Task DownloadFileExample()
    {
        await Page.GotoAsync("https://commitquality.com/practice-file-download");
        var waitForDownloadTask = Page.WaitForDownloadAsync();
        await Page.GetByText("Download File").ClickAsync();
        var download = await waitForDownloadTask;

        // wait for download process to finish and save the file somewhere
        await download.SaveAsAsync("./../../../" +  download.SuggestedFilename);
    }
}
