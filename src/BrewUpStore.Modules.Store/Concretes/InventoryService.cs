using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.ReadModel.Abstracts;
using BrewUpStore.ReadModel.Models;
using BrewUpStore.Shared.Concretes;
using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.Concretes;

public sealed class InventoryService : StoreBaseService, IInventoryService
{
    public InventoryService(IPersister persister, ILoggerFactory loggerFactory)
        : base(persister, loggerFactory)
    {
    }

    public async Task UpdateInventoriesAsync(IngredientId ingredientId, Quantity ordered)
    {
        try
        {
            var inventory = await Persister.GetByIdAsync<IngredientsInventories>(ingredientId.Value);
            if (string.IsNullOrEmpty(inventory.Id))
            {
                inventory = IngredientsInventories.CreateInventories(ingredientId, new Quantity(0), ordered);
                await Persister.InsertAsync(inventory);
            }

            inventory.UpdateOrderedQuantity(ordered);
            var propertiesToUpdate = new Dictionary<string, object>
            {
                { "Ordered", inventory.Ordered }
            };
            await Persister.UpdateOneAsync<IngredientsInventories>(inventory.Id, propertiesToUpdate);
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }
}