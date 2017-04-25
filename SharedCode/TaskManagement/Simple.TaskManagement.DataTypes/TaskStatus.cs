using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Simple.TaskManagement.DataTypes
{

    public enum TaskStatus
    {
        None,

        [Description("Task is canceled")]
        Canceled,

        [Description("Task is completed")]
        Completed,
    }
}
