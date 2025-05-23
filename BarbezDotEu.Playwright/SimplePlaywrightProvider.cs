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
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            try
            {
                var @type = BrowserSelector.GetBrowserType(playwright, _browser);
                var browser = await @type.LaunchAsync(_browserTypeLaunchOption);
                try
                {
                    var page = await GetPage(url, browser);
                    var content = await page.ContentAsync();
                    return content;
                }
                finally
                {
                    await browser.CloseAsync();
                }
            }
            finally
            {
                playwright.Dispose();
            }
        }

        /// <summary>
        /// Asynchronously renders an image of the specified URL.
        /// </summary>
        /// <param name="url">The URL of the web page to render.</param>
        /// <param name="options">Optional screenshot options such as file path, quality, etc.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the screenshot image as a byte array.</returns>
        public async Task<byte[]> MakeScreenshot(string url, PageScreenshotOptions options = default)
        {
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            try
            {
                var @type = BrowserSelector.GetBrowserType(playwright, _browser);
                var browser = await @type.LaunchAsync(_browserTypeLaunchOption);
                try
                {
                    var page = await GetPage(url, browser);
                    var screenshot = await page.ScreenshotAsync(options);
                    return screenshot;
                }
                finally
                {
                    await browser.CloseAsync();
                }
            }
            finally
            {
                playwright.Dispose();
            }
        }

        /// <summary>
        /// Creates a new page in a fresh browser context, navigates to the specified URL,
        /// and returns the loaded page.
        /// </summary>
        /// <param name="url">The URL of the web page to load.</param>
        /// <param name="browser">The browser instance used to create a new context and page.</param>
        /// <returns>An <see cref="IPage"/> instance with the loaded content.</returns>
        private static async Task<IPage> GetPage(string url, IBrowser browser)
        {
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync(url);
            return page;
        }
    }
}
