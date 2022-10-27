using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.ReadModel.Abstracts;
using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.Concretes;

public sealed class StoreService : StoreBaseService, IStoreService
{
    public StoreService(IPersister persister, ILoggerFactory loggerFactory)
        : base(persister, loggerFactory)
    {
    }
}