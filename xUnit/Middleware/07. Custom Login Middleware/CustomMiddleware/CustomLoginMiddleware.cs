namespace UseCustomLoginMiddleware.CustomMiddleware
{
    public class CustomLoginMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method == "POST" && httpContext.Request.Path == "/")
            {
                var form = await httpContext.Request.ReadFormAsync();
                var email = form["email"].ToString();
                var password = form["password"].ToString();

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid input for 'email'\n Invalid input for 'password'");
                }
                else if (email == "admin@example.com" && password == "admin1234")
                {
                    httpContext.Response.StatusCode = 200;
                    await httpContext.Response.WriteAsync("Successful login.");
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid login.");
                }
            }
            else
            {
                await _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomLoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomLoginMiddleware>();
        }
    }
}
