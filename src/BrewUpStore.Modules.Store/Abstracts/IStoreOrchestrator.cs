using BrewUpStore.Modules.Store.Shared.Dtos;

namespace BrewUpStore.Modules.Store.Abstracts;

public interface IStoreOrchestrator
{

    Task<string> AddIngredientAsync(IngredientJson ingredientToCreate);
    Task<string> CreaOrdineFornitoreAsync(SupplierOrderJson orderToCreate);
}