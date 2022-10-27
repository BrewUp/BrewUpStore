using BrewUpStore.Modules.Store.Shared.Dtos;

namespace BrewUpStore.Modules.Store.Abstracts;

public interface IIngredientsService
{
    Task<string> AddIngredientAsync(IngredientJson ingredientToCreate);
    Task<IEnumerable<IngredientJson>> GetIngredientsAsync();
}