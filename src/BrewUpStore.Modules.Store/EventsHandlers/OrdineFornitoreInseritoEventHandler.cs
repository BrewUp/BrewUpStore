using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.Events;
using BrewUpStore.Shared.Concretes;
using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.EventsHandlers;

public sealed class OrdineFornitoreInseritoEventHandler : StoreDomainEventHandler<OrdineFornitoreInserito>
{
    private readonly IInventoryService _inventoryService;

    public OrdineFornitoreInseritoEventHandler(ILoggerFactory loggerFactory,
        IInventoryService inventoryService) : base(loggerFactory)
    {
        _inventoryService = inventoryService;
    }

    public override async Task HandleAsync(OrdineFornitoreInserito @event, CancellationToken cancellationToken = new ())
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        try
        {
            foreach (var row in @event.Rows)
            {
                await _inventoryService.UpdateInventoriesAsync(row.Ingredient.IngredientId, row.Quantity);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }
}