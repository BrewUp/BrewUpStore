using Muflone.Core;

namespace BrewUpStore.Modules.Store.Shared.CustomTypes;

public sealed class BatchId : DomainId
{
    public BatchId(Guid value) : base(value)
    {
    }
}