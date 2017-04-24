using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Messages
{
    public class TaskCreated
    {
        public string TaskId { get; set; }
        public string AssignedTo { get; set; }
        public DateTimeOffset RequiredByDate { get; set; }
    }
}
