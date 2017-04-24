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
    class SendCompletionNotificationMessageHandler : IHandleMessages<SendCompletionNotification>
    {
        private readonly IBus Bus;

        public SendCompletionNotificationMessageHandler(IBus bus)
        {
            Bus = bus;
        }

        public Task Handle(SendCompletionNotification message)
        {
            throw new NotImplementedException();
        }
    }
}
