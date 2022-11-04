using BrewUpStore.Modules.Store;
using BrewUpStore.Modules.Store.Endpoints;

namespace BrewUpStore.Modules;

public sealed class StoreModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;

    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddStoreModule();

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        const string storeTag = "Store";

        endpoints.MapPost("v1/store/ingredients", StoreEndpoints.HandleCreateIngredient)
            .WithName("CreateIngredient")
            .WithTags(storeTag);

        endpoints.MapGet("v1/store/ingredients", StoreEndpoints.HandleGetIngredientsAsync)
            .WithName("GetIngredient")
            .WithTags(storeTag);

        return endpoints;
    }
}