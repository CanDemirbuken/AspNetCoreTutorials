using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("From Middleware One\n");
    await next(context);
});

//app.UseMyCustomMiddleware();
app.UseCustomConventionalMiddlewareExtension();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("From Middleware Three\n");
});

app.Run();
