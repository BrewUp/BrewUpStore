using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.Dtos;
using BrewUpStore.Modules.Store.Shared.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BrewUpStore.Modules.Store.Endpoints;

public static class StoreEndpoints
{
    public static async Task<IResult> HandleCreateIngredient(IStoreOrchestrator storeOrchestrator,
        IValidator<IngredientJson> validator,
        ValidationHandler validationHandler,
        IngredientJson body)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var ingredientId = await storeOrchestrator.AddIngredientAsync(body);

        return Results.Created(new Uri($"v1/store/ingredients/{ingredientId}"), ingredientId);
    }

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
}