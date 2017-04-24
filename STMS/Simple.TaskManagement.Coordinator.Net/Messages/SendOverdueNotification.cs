using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Messages
{
    class SendOverdueNotification
    {
        public string TaskId { get; set; }
    }
}
