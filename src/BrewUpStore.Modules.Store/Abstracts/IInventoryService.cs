using BrewUpStore.Modules.Store.Shared.CustomTypes;

namespace BrewUpStore.Modules.Store.Abstracts;

public interface IInventoryService
{
    Task UpdateInventoriesAsync(IngredientId ingredientId, Quantity ordered);
}