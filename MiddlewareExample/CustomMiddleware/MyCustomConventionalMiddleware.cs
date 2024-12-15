namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomConventionalMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("firstname") && context.Request.Query.ContainsKey("lastname"))
            {
                string fullName = context.Request.Query["firstname"] + " " + context.Request.Query["lastname"];
                await context.Response.WriteAsync(fullName + "\n");
            }

            await _next(context);
        }
    }

    public static class CustomConventionalMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomConventionalMiddlewareExtension(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomConventionalMiddleware>();
        }
    }
}
