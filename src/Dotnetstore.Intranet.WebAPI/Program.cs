using Dotnetstore.Intranet.WebAPI;
using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => 
    config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddWebApi(builder.Configuration);
    
var app = builder.Build();

app
    .UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints()
    .UseSwaggerGen()
    .UseExceptionHandler();
    
await app.RunAsync();

namespace Dotnetstore.Intranet.WebAPI
{
    public partial class Program;
}