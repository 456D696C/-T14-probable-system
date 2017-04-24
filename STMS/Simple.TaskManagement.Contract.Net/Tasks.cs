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
        partial class AddPeopleToTaskCommand { }
        partial class RemovePeopleFromTaskCommand { }
    }

    namespace Queries.Tasks
    {
        partial class TasksQuery { }
        partial class TasksSearchOnCommentsQuery { }
        partial class TaskStatusQuery { }
    }

    namespace Events.Tasks
    {
        partial class TasksReport { }
        partial class TasksSearchOnCommentsReport { }
        partial class TasksStatusReport { }
    }
}
