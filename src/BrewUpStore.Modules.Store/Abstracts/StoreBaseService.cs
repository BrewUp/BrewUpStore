using BrewUpStore.ReadModel.Abstracts;
using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.Abstracts;

public abstract class StoreBaseService
{
    protected readonly IPersister Persister;
    protected readonly ILogger Logger;

    protected StoreBaseService(IPersister persister,
        ILoggerFactory loggerFactory)
    {
        Persister = persister;
        Logger = loggerFactory.CreateLogger(GetType());
    }
}