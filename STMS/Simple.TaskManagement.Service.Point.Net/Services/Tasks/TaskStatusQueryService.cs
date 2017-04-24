using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simple.Query;
using Simple.TaskManagement.Tasks;
using Simple.TaskManagement.Queries.Tasks;
using Simple.TaskManagement.Events.Tasks;

namespace Simple.TaskManagement.Services.Tasks
{
    class TaskStatusQueryService : IQueryHandler<TaskStatusQuery,TaskStatusReport>
    {
        private readonly ITaskStorage TaskStorage;

        public TaskStatusQueryService(ITaskStorage taskStorage)
        {
            TaskStorage = taskStorage;
        }

        public TaskStatusReport Handle(TaskStatusQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
