using Dotnetstore.Intranet.Utility.Entities;
using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace Dotnetstore.Intranet.Utility.Loggers;

public class DurationLogger<TRequest> : PostProcessor<TRequest, StateBag, object>
{
    public override Task PostProcessAsync(
        IPostProcessorContext<TRequest, object> ctx, 
        StateBag state, 
        CancellationToken ct)
    {
        ctx.HttpContext.Resolve<ILogger<DurationLogger<TRequest>>>().LogInformation("request took {@duration} ms.", state.DurationMillis);

        return Task.CompletedTask;
    }
}