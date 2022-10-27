using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.Modules.Store.Shared.Dtos;
using BrewUpStore.ReadModel.Abstracts;
using BrewUpStore.Shared.Concretes;
using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.Concretes;

public sealed class IngredientsService : StoreBaseService, IIngredientsService
{
    public IngredientsService(IPersister persister, ILoggerFactory loggerFactory) : base(persister, loggerFactory)
    {
    }

    public async Task<string> AddIngredientAsync(IngredientJson ingredientToCreate)
    {
        try
        {
            if (string.IsNullOrEmpty(ingredientToCreate.Id))
                ingredientToCreate.Id = Guid.NewGuid().ToString();

            var ingredient = ReadModel.Models.Ingredient.CreateIngredient(new IngredientId(ingredientToCreate.Id),
                new IngredientName(ingredientToCreate.Name));
            await Persister.InsertAsync(ingredient);

            return ingredient.Id;
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }
}