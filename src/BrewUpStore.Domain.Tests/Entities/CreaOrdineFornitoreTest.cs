using BrewUpStore.Domain.CommandHandlers;
using BrewUpStore.Modules.Store.Shared.Commands;
using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.Modules.Store.Shared.Events;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;

namespace BrewUpStore.Domain.Tests.Entities;

public sealed class CreaOrdineFornitoreTest : CommandSpecification<CreaOrdineFornitore>
{
    private readonly OrderId _orderId = new(Guid.NewGuid());
    private readonly OrderNumber _orderNumber = new("20221028-01");

    private readonly Guid _correlationId = Guid.NewGuid();

    private readonly Fornitore _fornitore = new Fornitore(new FornitoreId(Guid.NewGuid().ToString()), new DenominazioneFornitore("Fornitore"));

    private readonly DataInserimento _dataInserimento = new(DateTime.UtcNow);
    private readonly DataPrevistaConsegna _dataPrevistaConsegna = new(DateTime.UtcNow.AddDays(30));

    protected override IEnumerable<DomainEvent> Given()
    {
        yield break;
    }

    protected override CreaOrdineFornitore When()
    {
        return new CreaOrdineFornitore(_orderId, _correlationId, _orderNumber, _fornitore, _dataInserimento, _dataPrevistaConsegna);
    }

    protected override ICommandHandlerAsync<CreaOrdineFornitore> OnHandler()
    {
        return new CreaOrdineFornitoreCommandHandler(Repository, new NullLoggerFactory());
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        yield return new OrdineFornitoreInserito(_orderId, _correlationId, _orderNumber, _fornitore, _dataInserimento, _dataPrevistaConsegna);
    }
}