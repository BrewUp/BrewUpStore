namespace BrewUpStore.Modules.Store.Shared.Dtos;

public class OrdineFornitoreJson
{
    public string OrderId { get; set; } = string.Empty;
    public string OrderNumber { get; set; } = string.Empty;

    public FornitoreJson Fornitore { get; set; } = new();

    public DateTime DataInserimento { get; set; } = DateTime.UtcNow;
    public DateTime DataPrevistaConsegna { get; set; } = DateTime.MinValue;
}