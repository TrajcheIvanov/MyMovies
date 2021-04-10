using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyMovies.Custom
{
    public class RequestResponseLogMiddleware
    {
        private RequestDelegate _next;
        public RequestResponseLogMiddleware(RequestDelegate  next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //some logic
            //log httpContext.Request
            await _next(httpContext);
            //log httpContext.Response
        }
    }
}
