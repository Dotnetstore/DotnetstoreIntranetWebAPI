using Dotnetstore.Intranet.Utility.Entities;
using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace Dotnetstore.Intranet.Utility.Loggers;

public class RequestLogger<TRequest> : PreProcessor<TRequest, StateBag>
{
    public override Task PreProcessAsync(IPreProcessorContext<TRequest> context, StateBag state, CancellationToken ct)
    {
        var logger = context.HttpContext.Resolve<ILogger<TRequest>>();
        
        logger.LogInformation($"request:{context.Request.GetType().FullName} path: {context.HttpContext.Request.Path}");
        
        return Task.CompletedTask;
    }
}