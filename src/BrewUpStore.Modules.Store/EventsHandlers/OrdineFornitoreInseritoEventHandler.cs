using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.Events;
using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.EventsHandlers;

public sealed class OrdineFornitoreInseritoEventHandler : StoreDomainEventHandler<OrdineFornitoreInserito>
{
    public OrdineFornitoreInseritoEventHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }

    public override Task HandleAsync(OrdineFornitoreInserito @event, CancellationToken cancellationToken = new ())
    {
        throw new NotImplementedException();
    }
}