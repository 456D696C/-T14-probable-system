using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simple.Query;

namespace Simple.TaskManagement
{
    public class Contract
    {
    }

    namespace Commands.Tasks
    {
        public partial class AddOrUpdateTaskCommand { }
        public partial class AddPeopleToTaskCommand { }
        public partial class RemovePeopleFromTaskCommand { }
    }

    namespace Commands.Conacts
    {
        public partial class AddOrUpdateStaffMemberCommand { }
        public partial class DeleteStaffMemberCommand { }
    }

    namespace Commands.Comments
    {
        public partial class AddOrUpdateCommentCommand { }
        public partial class DeleteCommentCommand { }
    }

    namespace Queries.Time
    {
        public partial class TimeQuery : IQuery<Events.Time.TimeReport> { }
    }

    namespace Queries.Tasks
    {
        public partial class TasksQuery :IQuery<Events.Tasks.TasksReport> { }
        public partial class TasksSearchOnCommentsQuery : IQuery<Events.Tasks.TasksSearchOnCommentsReport> { }
        public partial class TaskStatusQuery : IQuery<Events.Tasks.TaskStatusReport> { }                

    }

    namespace Queries.Contacts
    {
        public partial class StaffStatusQuery : IQuery<Events.Contacts.StaffStatusReport> { }
    }

    namespace Queries.Comments
    {
        public partial class CommentStatusQuery : IQuery<Events.Comments.CommentStatusReport> { } 
    }

    namespace Events.Time
    {
        public partial class TimeReport
        {

        }
    }

    namespace Events.Tasks
    {
        public partial class TasksReport { }
        public partial class TasksSearchOnCommentsReport { }
        public partial class TaskStatusReport { }               


    }

    namespace Events.Contacts
    {
        public partial class StaffStatusReport { }

    }

    namespace Events.Comments
    {
        public partial class CommentStatusReport { }

    }
}
