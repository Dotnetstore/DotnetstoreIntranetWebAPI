using Dotnetstore.Intranet.Organization;
using Dotnetstore.Intranet.Utility.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "Dotnetstore Intranet API";
            s.Description = "API for Dotnetstore Intranet";
            s.Version = "1.0";
        };
    })
    .AddUtility()
    .AddOrganization(builder.Configuration);
    
var app = builder.Build();

app
    .UseFastEndpoints()
    .UseSwaggerGen();
    
await app.RunAsync();

public partial class Program;