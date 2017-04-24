using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Messages
{
    public class TaskSagaTimeout
    {
        public string TaskId { get; set; }
    }
}
