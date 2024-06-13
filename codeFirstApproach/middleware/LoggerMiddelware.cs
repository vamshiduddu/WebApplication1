namespace codeFirstApproach.middleware
{
    public class LoggerMiddelware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddelware(RequestDelegate next)
        {
            _next = next;
        }

            public async Task InvokeAsync(HttpContext context)
            {
                // Custom logic before the next middleware
                Console.WriteLine("Custom middleware executing before next middleware");

            await _next(context);

            if (context.Request.Headers["name"] == "vamshi")
                {

                }
               
                // Call the next middleware in the pipeline

                // Custom logic after the next middleware
                Console.WriteLine("Custom middleware executing after next middleware");
            }
      
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
             builder.UseMiddleware<LoggerMiddelware>();
            builder.UseMiddleware<RateLimitingMiddleware>();
            return builder;
        }
    }
}
