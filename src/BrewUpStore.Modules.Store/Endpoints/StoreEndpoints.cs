using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.Dtos;
using BrewUpStore.Modules.Store.Shared.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BrewUpStore.Modules.Store.Endpoints;

public static class StoreEndpoints
{
    public static async Task<IResult> HandleCreaOrdineFornitore(IStoreOrchestrator storeOrchestrator,
        IValidator<OrdineFornitoreJson> validator,
        ValidationHandler validationHandler,
        OrdineFornitoreJson body)
    {
        await validationHandler.ValidateAsync(validator, body);
        if (!validationHandler.IsValid)
            return Results.BadRequest(validationHandler.Errors);

        var orderId = await storeOrchestrator.CreaOrdineFornitoreAsync(body);

        return Results.Accepted($"v1/suppliers/orders/{orderId}");
    }
}