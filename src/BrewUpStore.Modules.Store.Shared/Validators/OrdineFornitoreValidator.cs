using BrewUpStore.Modules.Store.Shared.Dtos;
using FluentValidation;

namespace BrewUpStore.Modules.Store.Shared.Validators;

public class OrdineFornitoreValidator : AbstractValidator<OrdineFornitoreJson>
{
    public OrdineFornitoreValidator()
    {
        RuleFor(v => v.OrderNumber).NotEmpty();

        RuleFor(h => h.Fornitore.FornitoreId).NotEmpty();
        RuleFor(h => h.Fornitore.Denominazione).NotEmpty();

        RuleFor(h => h.DataInserimento).GreaterThan(DateTime.MinValue);
    }
}