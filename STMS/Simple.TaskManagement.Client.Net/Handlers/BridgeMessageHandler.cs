using System;
using System.Threading.Tasks;
using Reactive.EventAggregator;
using Rebus.Handlers;

namespace Simple.TaskManagement.Handlers
{
    class BridgeMessageHandler<T> : IHandleMessages<T>
    {
        private readonly IEventAggregator EventAggregator;

        public BridgeMessageHandler(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public Task Handle(T message)
        {
            return Task.Run(() => EventAggregator.Publish(message));
        }
    }
}
