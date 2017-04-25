using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Simple.TaskManagement
{
    namespace Commands.Tasks
    {
        partial class AddOrUpdateTaskCommand { }
        partial class AssignContactToTaskCommand { }
        
    }

    namespace Queries.Tasks
    {
        partial class TasksQuery { }
        partial class TasksSearchOnCommentsQuery
        {
            public string Reference { get; set; }
            public string Query { get; set; }
            public override string ToString() => new { Query, Reference }.ToString();
          
        }
        partial class TaskStatusQuery { }
    }

    namespace Events.Tasks
    {
        partial class TasksReport { }
        partial class TasksSearchOnCommentsReport
        {
            public string Reference { get; set; }
            public string Query { get; set; }
            public List<DataTypes.Task> Tasks { get; set; }
            public override string ToString() => new { Query, Reference, Tasks.Count }.ToString();

        }
        partial class TasksStatusReport { }
    }
}
