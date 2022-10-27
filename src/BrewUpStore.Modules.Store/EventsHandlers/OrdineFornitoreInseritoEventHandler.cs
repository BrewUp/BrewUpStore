using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.Events;
using BrewUpStore.Shared.Concretes;
using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.EventsHandlers;

public sealed class OrdineFornitoreInseritoEventHandler : StoreDomainEventHandler<OrdineFornitoreInserito>
{
    private readonly IStoreService _storeService;

    public OrdineFornitoreInseritoEventHandler(ILoggerFactory loggerFactory,
        IStoreService storeService) : base(loggerFactory)
    {
        _storeService = storeService;
    }

    public override async Task HandleAsync(OrdineFornitoreInserito @event, CancellationToken cancellationToken = new ())
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        try
        {
            await _storeService.CreateSupplierOrderAsync(@event.OrderId, @event.OrderNumber, @event.Fornitore,
                @event.DataInserimento, @event.DataPrevistaConsegna, @event.Rows);
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }
}