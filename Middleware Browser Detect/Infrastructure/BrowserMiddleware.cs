using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware_Browser_Detect.Infrastructure
{
    public class BrowserMiddleware
    {
        private readonly RequestDelegate _next;

        public BrowserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IBrowserDetector detector) 
        {
            var browser = detector.Browser;

            if(browser.Name == BrowserNames.Edge || browser.Name == BrowserNames.EdgeChromium || browser.Name == BrowserNames.InternetExplorer)
            {
                await httpContext.Response.WriteAsync("Twoja przegladarka nie jest obslugiwana!");
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }
}
