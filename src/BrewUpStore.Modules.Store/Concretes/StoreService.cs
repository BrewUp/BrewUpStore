using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.Modules.Store.Shared.Dtos;
using BrewUpStore.ReadModel.Abstracts;
using BrewUpStore.ReadModel.Models;
using BrewUpStore.Shared.Concretes;
using Microsoft.Extensions.Logging;

namespace BrewUpStore.Modules.Store.Concretes;

public sealed class StoreService : StoreBaseService, IStoreService
{
    public StoreService(IPersister persister, ILoggerFactory loggerFactory)
        : base(persister, loggerFactory)
    {
    }

    public async Task CreateSupplierOrderAsync(OrderId orderId, OrderNumber orderNumber, Fornitore fornitore,
        DataInserimento dataInserimento, DataPrevistaConsegna dataPrevistaConsegna, IEnumerable<OrderRow> rows)
    {
        try
        {
            var supplierOrder = SupplierOrder.CreateSupplierOrder(orderId, orderNumber, fornitore, dataInserimento,
                dataPrevistaConsegna, rows);

            await Persister.InsertAsync(supplierOrder);
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }

    public async Task<IEnumerable<SupplierOrderJson>> GetSupplierOrdersAsync()
    {
        try
        {
            var orders = await Persister.FindAsync<SupplierOrder>();
            var ordersArray = orders as SupplierOrder[] ?? orders.ToArray();

            return ordersArray.Any()
                ? ordersArray.Select(o => o.ToJson())
                : Enumerable.Empty<SupplierOrderJson>();
        }
        catch (Exception ex)
        {
            Logger.LogError(CommonServices.GetDefaultErrorTrace(ex));
            throw;
        }
    }
}