using Dotnetstore.Intranet.WebAPI;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApi(builder.Configuration);
    
var app = builder.Build();

app
    .UseFastEndpoints()
    .UseSwaggerGen()
    .UseExceptionHandler();
    
await app.RunAsync();

namespace Dotnetstore.Intranet.WebAPI
{
    public partial class Program;
}