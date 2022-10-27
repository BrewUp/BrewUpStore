using Muflone.Core;

namespace BrewUpStore.Modules.Store.Shared.CustomTypes;

public sealed class OrderId : DomainId
{
    public OrderId(Guid value) : base(value)
    {
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}