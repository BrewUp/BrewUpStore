using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.Dtos;
using BrewUpStore.Modules.Store.Shared.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BrewUpStore.Modules.Store.Endpoints;

public static class StoreEndpoints
{
    #region Ingredients
    public static async Task<IResult> HandleCreateIngredient(IIngredientsService ingredientsService,
        IValidator<IngredientJson> validator,
        ValidationHandler validationHandler,
        IngredientJson body)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var ingredientId = await ingredientsService.AddIngredientAsync(body);

        return Results.Created(new Uri($"v1/store/ingredients/{ingredientId}"), ingredientId);
    }

    public static async Task<IResult> HandleGetIngredientsAsync(IIngredientsService ingredientsService)
    {
        var ingredients = await ingredientsService.GetIngredientsAsync();

        return Results.Ok(ingredients);
    }
    #endregion

    #region SupplierOrder
    public static async Task<IResult> HandleCreaOrdineFornitore(IStoreOrchestrator storeOrchestrator,
        IValidator<SupplierOrderJson> validator,
        ValidationHandler validationHandler,
        SupplierOrderJson body)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var orderId = await storeOrchestrator.CreaOrdineFornitoreAsync(body);

        return Results.Accepted($"v1/store/orders/{orderId}");
    }

    public static async Task<IResult> HandleGetSupplierOrders(IStoreService storeService)
    {
        var orders = await storeService.GetSupplierOrdersAsync();

        return Results.Ok(orders);
    }
    #endregion
}