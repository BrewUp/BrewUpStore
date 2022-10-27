using BrewUpStore.Modules.Store.Abstracts;
using BrewUpStore.Modules.Store.Shared.CustomTypes;
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
}