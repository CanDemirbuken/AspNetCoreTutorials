using UseCustomLoginMiddleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseCustomLoginMiddleware();

app.MapGet("/", () => Results.Ok("No response"));

app.Run();
