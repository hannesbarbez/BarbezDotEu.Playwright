// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

namespace BarbezDotEu.Playwright
{
    /// <summary>
    /// Specifies the supported browser engines for automation using Playwright.
    /// </summary>
    public enum Browser
    {
        /// <summary>
        /// The Chromium browser engine (used by Chrome, Edge).
        /// </summary>
        Chromium,

        /// <summary>
        /// The Firefox browser engine (Gecko-based).
        /// </summary>
        Firefox,

        /// <summary>
        /// The WebKit browser engine (used by Safari).
        /// </summary>
        Webkit
    }
}
