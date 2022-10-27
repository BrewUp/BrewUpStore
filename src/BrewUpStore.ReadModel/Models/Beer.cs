using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.Modules.Store.Shared.Dtos;
using BrewUpStore.ReadModel.Abstracts;

namespace BrewUpStore.ReadModel.Models;

public class Beer : ModelBase
{
    public string BeerType { get; private set; } = string.Empty;
    public double Quantity { get; private set; } = 0;

    protected Beer()
    {}

    public static Beer CreateBeer(BeerId beerId, BeerType beerType, BatchId batchId) =>
        new(beerId.Value, beerType.Value);

    public void UpdateQuantity(Quantity quantity) => Quantity = quantity.Value;

    private Beer(Guid beerId, string beerType)
    {
        Id = beerId.ToString();
        BeerType = beerType;
    }

    public BeerJson ToJson() => new()
    {
        BeerId = Id,
        BeerType = BeerType,
        Quantity = Quantity
    };
}