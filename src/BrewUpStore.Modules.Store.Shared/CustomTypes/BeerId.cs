using Muflone.Core;

namespace BrewUpStore.Modules.Store.Shared.CustomTypes;

public class BeerId : DomainId
{
    public BeerId(Guid value) : base(value)
    {
    }
}