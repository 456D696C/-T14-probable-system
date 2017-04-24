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
    public class AddOrUpdateTaskMessageHandler : IHandleMessages<AddOrUpdateTaskCommand>
    {
        private readonly IBus Bus;
        private readonly ITaskStorage TaskStorage;

        public AddOrUpdateTaskMessageHandler(IBus bus, ITaskStorage taskStorage)
        {
            Bus = bus;
            TaskStorage = taskStorage;
        }

        public Task Handle(AddOrUpdateTaskCommand message)
        {
            TaskStorage.AddOrUpdate(new DataTypes.Task() { TaskId = Guid.NewGuid().ToString() }).Wait();

            return Bus.Reply(new TaskStatusReport() { });
        }
    }
}
