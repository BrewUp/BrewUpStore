using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.Modules.Store.Shared.Dtos;

namespace BrewUpStore.Modules.Store.Abstracts;

public interface IStoreService
{
    Task CreateSupplierOrderAsync(OrderId orderId, OrderNumber orderNumber, Fornitore fornitore,
        DataInserimento dataInserimento, DataPrevistaConsegna dataPrevistaConsegna, IEnumerable<OrderRow> rows);

    Task<IEnumerable<SupplierOrderJson>> GetSupplierOrdersAsync();
}