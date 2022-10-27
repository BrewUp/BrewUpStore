using BrewUpStore.Modules.Store.Shared.CustomTypes;
using Muflone.Messages.Events;

namespace BrewUpStore.Modules.Store.Shared.Events;

public sealed class OrdineFornitoreInserito : DomainEvent
{
    public readonly OrderId OrderId;
    public readonly OrderNumber OrderNumber;

    public readonly Fornitore Fornitore;

    public readonly DataInserimento DataInserimento;
    public readonly DataPrevistaConsegna DataPrevistaConsegna;

    public OrdineFornitoreInserito(OrderId aggregateId, Guid commitId, OrderNumber orderNumber, Fornitore fornitore,
        DataInserimento dataInserimento, DataPrevistaConsegna dataPrevistaConsegna) : base(aggregateId, commitId)
    {
        OrderId = aggregateId;
        OrderNumber = orderNumber;

        Fornitore = fornitore;

        DataInserimento = dataInserimento;
        DataPrevistaConsegna = dataPrevistaConsegna;
    }
}