using BrewUpStore.Modules.Store.Abstracts;
using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.Concretes;

public sealed class StoreOrchestrator : StoreBaseOrchestrator, IStoreOrchestrator
{
    private readonly IInventoryService _inventoryService;

    public StoreOrchestrator(ILoggerFactory loggerFactory, IInventoryService inventoryService) : base(loggerFactory)
    {
        _inventoryService = inventoryService;
    }

}