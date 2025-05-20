// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using FluentAssertions;
using Microsoft.Playwright;
using NSubstitute;

namespace BarbezDotEu.Playwright.Tests
{
    public class BrowserSelectorTests
    {
        [Fact]
        public void GetName_ShouldReturnCorrectBrowserTypeName()
        {
            BrowserSelector.GetName(Browser.Chromium).Should().Be("chromium");
            BrowserSelector.GetName(Browser.Firefox).Should().Be("firefox");
            BrowserSelector.GetName(Browser.Webkit).Should().Be("webkit");
        }

        [Fact]
        public void GetName_ShouldThrowForInvalidBrowser()
        {
            var invalidBrowser = (Browser)999;

            Action act = () => BrowserSelector.GetName(invalidBrowser);

            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("browser");
        }

        [Fact]
        public void GetBrowserType_ShouldReturnCorrectInstance()
        {
            var playwright = Substitute.For<IPlaywright>();

            var chromium = Substitute.For<IBrowserType>();
            var firefox = Substitute.For<IBrowserType>();
            var webkit = Substitute.For<IBrowserType>();

            playwright.Chromium.Returns(chromium);
            playwright.Firefox.Returns(firefox);
            playwright.Webkit.Returns(webkit);

            BrowserSelector.GetBrowserType(playwright, Browser.Chromium).Should().Be(chromium);
            BrowserSelector.GetBrowserType(playwright, Browser.Firefox).Should().Be(firefox);
            BrowserSelector.GetBrowserType(playwright, Browser.Webkit).Should().Be(webkit);
        }
    }
}
