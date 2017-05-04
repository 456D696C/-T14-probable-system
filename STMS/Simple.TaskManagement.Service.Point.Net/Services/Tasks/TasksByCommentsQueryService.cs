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
            var all = TaskStorage.Get().Result;

            var comparison = StringComparison.InvariantCultureIgnoreCase;

            var rename = from item in all
                           where item?.Comments?.Any(c=>c?.Commentary?.IndexOf(query.Query, comparison)>=0)==true
                            |query?.Query?.Split(new char[] { ' ' }).Select(x=>x??"").Select(x=>x?.Trim())
                                .Any(i=>item.Comments.Any(c=>c?.Commentary?.IndexOf(i)>=0))==true
                                 |string.IsNullOrWhiteSpace(query.Query)
                           select item;



            rename = rename.ToArray();

            return new TasksSearchOnCommentsReport()
            {
                Query = query.Query,
                Reference = query.Reference,
                Tasks = all.ToList(),
            };
        }
    }
}
