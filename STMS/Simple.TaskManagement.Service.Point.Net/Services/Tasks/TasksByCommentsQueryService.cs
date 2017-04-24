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
    class TasksByCommentsQueryService : IQueryHandler<TasksSearchOnCommentsQuery,TasksSearchOnCommentsReport>
    {
        private readonly ITaskStorage TaskStorage;

        public TasksByCommentsQueryService(ITaskStorage taskStorage)
        {
            TaskStorage = taskStorage;
        }

        public TasksSearchOnCommentsReport Handle(TasksSearchOnCommentsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
