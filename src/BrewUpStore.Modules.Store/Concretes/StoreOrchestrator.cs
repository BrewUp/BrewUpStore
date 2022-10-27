using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.Commands;
using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.Modules.Store.Shared.Dtos;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUpStore.Modules.Store.Concretes;

public sealed class StoreOrchestrator : StoreBaseOrchestrator, IStoreOrchestrator
{
    private readonly IStoreService _storeService;
    private readonly IServiceBus _serviceBus;

    public StoreOrchestrator(ILoggerFactory loggerFactory,
        IStoreService storeService,
        IServiceBus serviceBus) : base(loggerFactory)
    {
        _storeService = storeService;
        _serviceBus = serviceBus;
    }

    public async Task<string> CreaOrdineFornitoreAsync(OrdineFornitoreJson orderToCreate)
    {
        if (string.IsNullOrEmpty(orderToCreate.OrderId))
            orderToCreate.OrderId = Guid.NewGuid().ToString();

        var creaOrdineFornitore = new CreaOrdineFornitore(new OrderId(new Guid(orderToCreate.OrderId)), Guid.NewGuid(),
            new OrderNumber(orderToCreate.OrderNumber),
            new Fornitore(new FornitoreId(orderToCreate.Fornitore.FornitoreId),
                new DenominazioneFornitore(orderToCreate.Fornitore.Denominazione)),
            new DataInserimento(orderToCreate.DataInserimento),
            new DataPrevistaConsegna(orderToCreate.DataPrevistaConsegna));

        await _serviceBus.SendAsync(creaOrdineFornitore);

        return orderToCreate.OrderId;
    }
}