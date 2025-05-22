// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using Microsoft.Playwright;
using System;

namespace BarbezDotEu.Playwright
{
    /// <summary>
    /// Provides utility methods for working with Playwright browser types.
    /// </summary>
    public static class BrowserSelector
    {
        /// <summary>
        /// Returns the name of the <see cref="IPlaywright"/> browser property corresponding to the specified <see cref="Browser"/> enum value.
        /// </summary>
        /// <param name="browser">The browser enum value.</param>
        /// <returns>The name of the corresponding property on <see cref="IPlaywright"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the provided browser value is not supported.</exception>
        public static string GetName(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chromium:
                    return nameof(IPlaywright.Chromium).ToLower();
                case Browser.Firefox:
                    return nameof(IPlaywright.Firefox).ToLower();
                case Browser.Webkit:
                    return nameof(IPlaywright.Webkit).ToLower();
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }
        }

        /// <summary>
        /// Retrieves the corresponding <see cref="IBrowserType"/> from the <see cref="IPlaywright"/> instance
        /// based on the specified <see cref="Browser"/> value.
        /// </summary>
        /// <param name="playwright">An initialized <see cref="IPlaywright"/> instance.</param>
        /// <param name="browser">The <see cref="Browser"/> enum value specifying the desired browser type.</param>
        /// <returns>The matching <see cref="IBrowserType"/> implementation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the provided browser enum value is not recognized.</exception>
        public static IBrowserType GetBrowserType(IPlaywright playwright, Browser browser)
        {
            switch (browser)
            {
                case Browser.Chromium:
                    return playwright.Chromium;
                case Browser.Firefox:
                    return playwright.Firefox;
                case Browser.Webkit:
                    return playwright.Webkit;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }
        }
    }
}
