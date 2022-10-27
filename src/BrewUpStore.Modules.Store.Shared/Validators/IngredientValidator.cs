using BrewUpStore.Modules.Store.Shared.Dtos;
using FluentValidation;

namespace BrewUpStore.Modules.Store.Shared.Validators;

public class IngredientValidator : AbstractValidator<IngredientJson>
{
    public IngredientValidator()
    {
        RuleFor(v => v.Name).NotEmpty();
    }
}