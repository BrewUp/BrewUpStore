using BrewUpStore.Modules.Store.Shared.Events;
using Microsoft.Extensions.Logging;
using Muflone.Factories;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace BrewUpStore.Modules.Store.Consumers;

public sealed class OrdineFornitoreInseritoConsumer : DomainEventConsumerBase<OrdineFornitoreInserito>
{
    protected override IEnumerable<IDomainEventHandlerAsync<OrdineFornitoreInserito>> HandlersAsync { get; }

    public OrdineFornitoreInseritoConsumer(IDomainEventHandlerFactoryAsync domainEventHandlerFactoryAsync,
        AzureServiceBusConfiguration azureServiceBusConfiguration, ILoggerFactory loggerFactory,
        ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration, loggerFactory, messageSerializer)
    {
        HandlersAsync = domainEventHandlerFactoryAsync.CreateDomainEventHandlersAsync<OrdineFornitoreInserito>();
    }
}