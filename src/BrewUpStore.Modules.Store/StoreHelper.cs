using BrewUpProduction.Modules.Produzione.Factories;
using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Concretes;
using BrewUpStore.Modules.Store.EventsHandlers;
using BrewUpStore.Modules.Store.Shared.Events;
using BrewUpStore.Modules.Store.Shared.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Factories;
using Muflone.Messages.Events;

namespace BrewUpStore.Modules.Store;

public static class StoreHelper
{
    public static IServiceCollection AddStoreModule(this IServiceCollection services)
    {
        services.AddScoped<ValidationHandler>();
        services.AddFluentValidation(options =>
            options.RegisterValidatorsFromAssemblyContaining<OrdineFornitoreValidator>());

        services.AddScoped<IStoreOrchestrator, StoreOrchestrator>();
        services.AddScoped<IIngredientsService, IngredientsService>();
        services.AddScoped<IStoreService, StoreService>();

        services.AddScoped<IDomainEventHandlerFactoryAsync, DomainEventHandlerFactoryAsync>();
        services.AddScoped<ICommandHandlerFactoryAsync, CommandHandlerFactoryAsync>();

        services.AddScoped<IDomainEventHandlerAsync<OrdineFornitoreInserito>, OrdineFornitoreInseritoEventHandler>();

        return services;
    }
}