using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playwrightCSharp;

[TestFixture]
internal class UploadFiles: PageTest
{
    [Test]
    public async Task UploadFilesExample()
    {
        await Page.GotoAsync("https://commitquality.com/practice-file-upload");
        await Page.Locator("input[type=\"file\"]").SetInputFilesAsync("./../../../README.md");

        // Add event listner for the dialog box
        Page.Dialog += async (_, dialog) =>
        {
            //await Page.PauseAsync();
            await dialog.AcceptAsync();
        };

        await Page.GetByText("Submit").ClickAsync();
    }
}
