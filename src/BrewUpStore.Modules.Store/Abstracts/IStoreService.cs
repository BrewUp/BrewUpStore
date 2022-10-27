using BrewUpStore.Modules.Store.Shared.CustomTypes;

namespace BrewUpStore.Modules.Store.Abstracts;

public interface IStoreService
{
    Task CreateSupplierOrderAsync(OrderId orderId, OrderNumber orderNumber, Fornitore fornitore,
        DataInserimento dataInserimento, DataPrevistaConsegna dataPrevistaConsegna, IEnumerable<OrderRow> rows);
}