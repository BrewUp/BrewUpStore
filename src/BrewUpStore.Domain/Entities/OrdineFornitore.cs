using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.Modules.Store.Shared.Events;
using Muflone.Core;

namespace BrewUpStore.Domain.Entities;

public sealed class OrdineFornitore : AggregateRoot
{
    private OrderNumber _orderNumber;

    private Fornitore _fornitore;

    private DataInserimento _dataInserimento;
    private DataPrevistaConsegna _dataPrevistaConsegna;

    private IEnumerable<OrderRow> _rows;

    protected OrdineFornitore()
    {}

    internal static OrdineFornitore CreaOrdineFornitore(OrderId orderId, OrderNumber orderNumber, Fornitore fornitore,
        DataInserimento dataInserimento, DataPrevistaConsegna dataPrevistaConsegna, IEnumerable<OrderRow> rows,
        Guid correlationId)
    {
        return new OrdineFornitore(orderId, orderNumber, fornitore, dataInserimento, dataPrevistaConsegna,
            rows, correlationId);
    }

    private OrdineFornitore(OrderId orderId, OrderNumber orderNumber, Fornitore fornitore,
        DataInserimento dataInserimento, DataPrevistaConsegna dataPrevistaConsegna, IEnumerable<OrderRow> rows,
        Guid correlationId)
    {
        RaiseEvent(new OrdineFornitoreInserito(orderId, correlationId, orderNumber, fornitore, dataInserimento,
            dataPrevistaConsegna, rows));
    }

    private void Apply(OrdineFornitoreInserito @event)
    {
        Id = @event.OrderId;

        _orderNumber = @event.OrderNumber;

        _fornitore = @event.Fornitore;

        _dataInserimento = @event.DataInserimento;
        _dataPrevistaConsegna = @event.DataPrevistaConsegna;

        _rows = @event.Rows;
    }
}