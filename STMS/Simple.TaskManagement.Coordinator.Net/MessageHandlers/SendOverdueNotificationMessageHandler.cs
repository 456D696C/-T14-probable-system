using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rebus.Bus;
using Rebus.Handlers;

using Simple.TaskManagement.Messages;


namespace Simple.TaskManagement.MessageHandlers
{
    class SendOverdueNotificationMessageHandler : IHandleMessages<SendOverdueNotificationMessageHandler>
    {
        private readonly IBus Bus;

        public SendOverdueNotificationMessageHandler(IBus bus)
        {
            Bus = bus;
        }

        public Task Handle(SendOverdueNotificationMessageHandler message)
        {
            throw new NotImplementedException();
        }
    }
}
