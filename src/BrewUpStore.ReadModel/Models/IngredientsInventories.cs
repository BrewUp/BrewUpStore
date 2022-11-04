using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.ReadModel.Abstracts;

namespace BrewUpStore.ReadModel.Models;

public class IngredientsInventories : ModelBase
{
    public double Availability { get; private set; } = 0;
    public double Ordered { get; private set; } = 0;

    protected IngredientsInventories()
    {}


    public static IngredientsInventories CreateInventories(IngredientId ingredientId, Quantity availability, Quantity ordered) =>
        new(ingredientId.Value, availability.Value, ordered.Value);

    private IngredientsInventories(string ingredientId, double availability, double ordered)
    {
        Id = ingredientId;
        Availability = availability;
        Ordered = ordered;
    }

    public void UpdateOrderedQuantity(Quantity ordered)
    {
        Ordered = ordered.Value;
    }
}