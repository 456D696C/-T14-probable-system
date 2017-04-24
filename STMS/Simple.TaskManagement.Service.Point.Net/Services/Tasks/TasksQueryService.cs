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
    class TasksQueryService : IQueryHandler<TasksQuery, TasksReport>
    {
        private readonly ITaskStorage TaskStorage;

        public TasksQueryService(ITaskStorage taskStorage)
        {
            TaskStorage = taskStorage;
        }

        public TasksReport Handle(TasksQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
