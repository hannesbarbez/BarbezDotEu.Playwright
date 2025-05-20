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
            var result = browser switch
            {
                Browser.Chromium => nameof(IPlaywright.Chromium),
                Browser.Firefox => nameof(IPlaywright.Firefox),
                Browser.Webkit => nameof(IPlaywright.Webkit),
                _ => throw new ArgumentOutOfRangeException(nameof(browser), browser, null)
            };

            return result.ToLower();
        }

        /// <summary>
        /// Retrieves the corresponding <see cref="IBrowserType"/> from the <see cref="IPlaywright"/> instance
        /// based on the specified <see cref="Browser"/> value.
        /// </summary>
        /// <param name="playwright">An initialized <see cref="IPlaywright"/> instance.</param>
        /// <param name="browser">The <see cref="Browser"/> enum value specifying the desired browser type.</param>
        /// <returns>The matching <see cref="IBrowserType"/> implementation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the provided browser enum value is not recognized.</exception>
        public static IBrowserType GetBrowserType(IPlaywright playwright, Browser browser) => browser switch
        {
            Browser.Chromium => playwright.Chromium,
            Browser.Firefox => playwright.Firefox,
            Browser.Webkit => playwright.Webkit,
            _ => throw new ArgumentOutOfRangeException(nameof(browser), browser, null)
        };
    }
}
