// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using FluentAssertions;

namespace BarbezDotEu.Playwright.Tests
{
    namespace BarbezDotEu.Tests.Playwright
    {
        public class SimplePlaywrightProviderTests
        {
            [Fact]
            public void Constructor_ShouldCallInstall()
            {
                // Arrange
                var exception = Record.Exception(() => new SimplePlaywrightProvider(Browser.Firefox));

                // Assert
                exception.Should().BeNull(); // Validates no runtime failure in install line
            }
        }
    }
}
