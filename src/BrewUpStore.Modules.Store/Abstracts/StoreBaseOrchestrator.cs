using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.Abstracts;

public abstract class StoreBaseOrchestrator
{
    protected ILogger Logger;

    protected StoreBaseOrchestrator(ILoggerFactory loggerFactory)
    {
        Logger = loggerFactory.CreateLogger(GetType());
    }
}