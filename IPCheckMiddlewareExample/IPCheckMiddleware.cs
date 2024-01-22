using System.Net;

namespace IPCheckMiddlewareExample
{
    public class IPCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<IPAddress> _allowedIPs;

        public IPCheckMiddleware(RequestDelegate next)
        {
            _next = next;
            _allowedIPs = new List<IPAddress>
            {
                // Allowed IP addresses
                IPAddress.Parse("127.0.0.1"),
                IPAddress.Parse("::1")
                // Not allowed IP adressess
                //IPAddress.Parse("127.0.0.1"),
                //IPAddress.Parse("::2")
            };
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/swagger"))
            {
                await _next.Invoke(context);
                return;
            }
            var clientIp = context.Connection.RemoteIpAddress;
            if (clientIp is null)
            {
                await context.Response.WriteAsync("Client IP address not available.");
            }

            if (!_allowedIPs.Contains(clientIp!))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("You are not allowed to access this resource.");
                return;
            }
            await _next.Invoke(context);
        }
    }
}
