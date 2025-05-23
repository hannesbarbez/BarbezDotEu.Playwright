# BarbezDotEu.Playwright
Helps retrieving content from web pages using [Microsoft Playwright](https://playwright.dev/dotnet/). Useful for basic testing or fetching content from dynamic pages that require JavaScript execution.

## SimplePlaywrightProvider

A lightweight .NET utility that uses Microsoft Playwright to retrieve the fully rendered content of web pages or capture screenshots. It is especially useful for basic testing scenarios or fetching content from sites that require JavaScript execution.

### Features

- **Fetch Rendered HTML:** Retrieve the full HTML content of a given URL after JavaScript execution.
- **Capture Screenshots:** Render the page to a screenshot image as a byte array. You can provide custom options (e.g., image file path, quality) using the `PageScreenshotOptions` parameter.
- **Headless or Headed Mode:** Option to run the browser in headless mode for performance or in headed mode for debugging and bypassing JavaScript-based protections.

### Usage

#### **SimplePlaywrightProvider(Browser browser, bool headless = false)**
Initializes a new instance of the provider using the specified browser instance. The optional parameter enables headless mode, which when set to false displays the browser window; this may be necessary for certain JavaScript-based protections.
  
#### **Task<string> GetContents(string url)**
Asynchronously retrieves the fully rendered HTML content of the specified URL. This method creates a new browser context, loads the page, and returns its HTML content after dynamic scripts have executed.
  
#### **Task<byte[]> MakeScreenshot(string url, PageScreenshotOptions options = default)**
Asynchronously captures a screenshot of the specified URL. You may pass optional screenshot options such as file path or image quality. This method returns the screenshot as a byte array.
