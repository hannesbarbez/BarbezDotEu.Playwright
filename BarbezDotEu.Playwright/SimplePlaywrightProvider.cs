// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Threading.Tasks;
using Microsoft.Playwright;

namespace BarbezDotEu.Playwright
{
    /// <summary>
    /// Provides functionality to retrieve content from web pages using Microsoft Playwright.
    /// Useful for fetching content from dynamic pages that require JavaScript execution.
    /// </summary>
    public class SimplePlaywrightProvider
    {
        private readonly Browser _browser;
        private readonly BrowserTypeLaunchOptions _browserTypeLaunchOption;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimplePlaywrightProvider"/> class.
        /// </summary>
        /// <param name="browser">The <see cref="Browser"/> to use.</param>
        /// <param name="headless">
        /// Indicates whether the browser should run in headless mode.
        /// Set to <c>false</c> to display the browser window, which may be necessary for certain JavaScript-based protections.
        /// </param>
        public SimplePlaywrightProvider(Browser browser, bool headless = false)
        {
            _browser = browser;
            _browserTypeLaunchOption = new BrowserTypeLaunchOptions { Headless = headless };

            Program.Main(new string[] { "install", BrowserSelector.GetName(_browser) });
        }

        /// <summary>
        /// Asynchronously retrieves the fully rendered content of the specified URL.
        /// </summary>
        /// <param name="url">The URL of the web page to fetch.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the content as a string.</returns>
        public async Task<string> GetContents(string url)
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            var @type = BrowserSelector.GetBrowserType(playwright, _browser);
            var browser = await @type.LaunchAsync(_browserTypeLaunchOption);
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            var response = await page.GotoAsync(url);
            var content = await page.ContentAsync();
            await browser.CloseAsync();
            return content;
        }
    }
}
