using BrewUpStore.Modules.Store.Shared.CustomTypes;
using Muflone.Messages.Commands;

namespace BrewUpStore.Modules.Store.Shared.Commands;

public sealed class CreaOrdineFornitore : Command
{
    public readonly OrderId OrderId;
    public readonly OrderNumber OrderNumber;

    public readonly Fornitore Fornitore;

    public readonly DataInserimento DataInserimento;
    public readonly DataPrevistaConsegna DataPrevistaConsegna;

    public CreaOrdineFornitore(OrderId aggregateId, Guid commitId, OrderNumber orderNumber, Fornitore fornitore,
        DataInserimento dataInserimento, DataPrevistaConsegna dataPrevistaConsegna) : base(aggregateId, commitId)
    {
        OrderId = aggregateId;
        OrderNumber = orderNumber;

        Fornitore = fornitore;

        DataInserimento = dataInserimento;
        DataPrevistaConsegna = dataPrevistaConsegna;
    }
}