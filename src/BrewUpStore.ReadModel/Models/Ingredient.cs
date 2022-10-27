using BrewUpStore.Modules.Store.Shared.CustomTypes;
using BrewUpStore.Modules.Store.Shared.Dtos;
using BrewUpStore.ReadModel.Abstracts;

namespace BrewUpStore.ReadModel.Models;

public class Ingredient : ModelBase
{
    public string Name { get; private set; } = string.Empty;

    protected Ingredient()
    { }

    public static Ingredient CreateIngredient(IngredientId ingredientId, IngredientName name) =>
        new(ingredientId.Value, name.Value);

    private Ingredient(string ingredientId, string ingredientName)
    {
        Id = ingredientId;
        Name = ingredientName;
    }

    public IngredientJson ToJson() => new()
    {
        Id = Id,
        Name = Name
    };
}