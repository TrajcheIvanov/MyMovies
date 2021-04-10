using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MyMovies.Custom
{
    public class ExceptionLoggingMiddleware
    {
        private RequestDelegate _next;
        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //customer logic for http context
            try
            {
                await _next(httpContext);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
