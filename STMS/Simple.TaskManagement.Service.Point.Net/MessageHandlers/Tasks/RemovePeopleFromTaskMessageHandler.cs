using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rebus.Bus;
using Rebus.Handlers;

using Simple.TaskManagement.Tasks;
using Simple.TaskManagement.Commands.Tasks;
using Simple.TaskManagement.Events.Tasks;

namespace Simple.TaskManagement.MessageHandlers.Tasks
{
    class RemovePeopleFromTaskMessageHandler : IHandleMessages<RemovePeopleFromTaskCommand>
    {
        private readonly IBus Bus;
        private readonly ITaskStorage TaskStorage;

        public RemovePeopleFromTaskMessageHandler(IBus bus, ITaskStorage taskStorage)
        {
            Bus = bus;
            TaskStorage = taskStorage;
        }

        public Task Handle(RemovePeopleFromTaskCommand message)
        {
            return Bus.SendLocal(new AddOrUpdateTaskCommand());
        }
    }
}
