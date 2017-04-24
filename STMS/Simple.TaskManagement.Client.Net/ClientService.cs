using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;


using Rebus.Bus;

using Reactive.EventAggregator;


namespace Simple.TaskManagement
{
    class ClientService : IClientService
    {
        private readonly IEventAggregator Events;
        private readonly IBus Bus;
        private readonly IUnityContainer Container;

        public ClientService(IEventAggregator events, IBus bus, IUnityContainer container)
        {
            Events = events;
            Bus = bus;
            Container = container;
        }

        public Task StartAsync()
        {
            return Task.CompletedTask;
        }
    }
}
