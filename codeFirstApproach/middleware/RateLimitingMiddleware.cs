using System.Collections.Concurrent;

namespace codeFirstApproach.middleware
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly ConcurrentDictionary<string, (int Count, DateTime Timestamp)> ClientRequestCounts = new();
        private static readonly TimeSpan TimeWindow = TimeSpan.FromMinutes(1); // 1 minute window
        private static readonly int RequestLimit = 5; // Limit to 5 requests per time window

        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var clientIp = context.Connection.RemoteIpAddress?.ToString();
            if (clientIp == null)
            {
                await _next(context);
                return;
            }

            var currentTime = DateTime.UtcNow;

            // Update the request count and timestamp
            ClientRequestCounts.AddOrUpdate(clientIp,(1, currentTime),
                (key, value) =>
                {
                    if (currentTime - value.Timestamp > TimeWindow)
                    {
                        return (1, currentTime); // Reset count if time window has passed
                    }
                    return (value.Count + 1, value.Timestamp);
                });

            // Check if the request count exceeds the limit
            if (ClientRequestCounts[clientIp].Count > RequestLimit)
            {
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.Response.WriteAsync("Too many requests.");
                return;
            }

            await _next(context);
        }
    }
}
