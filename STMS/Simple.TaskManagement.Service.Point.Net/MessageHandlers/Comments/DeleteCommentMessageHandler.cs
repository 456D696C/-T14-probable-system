using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Rebus.Bus;
using Rebus.Handlers;


using Simple.TaskManagement.Tasks;
using Simple.TaskManagement.Commands.Comments;
using Simple.TaskManagement.Events.Comments;

namespace Simple.TaskManagement.MessageHandlers.Comments
{
    class DeleteCommentMessageHandler : IHandleMessages<DeleteCommentCommand>
    {
        private readonly IBus Bus;
        private readonly ITaskStorage TaskStorage;

        public DeleteCommentMessageHandler(IBus bus, ITaskStorage taskStorage)
        {
            Bus = bus;
            TaskStorage = taskStorage;
        }

        public Task Handle(DeleteCommentCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
