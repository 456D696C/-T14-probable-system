using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Simple.TaskManagement.DataTypes
{

    public enum TaskStatus
    {
        None,

        [Description("Task is completed")]
        InProgress,

        [Description("Task is completed")]
        Completed,

        [Description("Task is canceled")]
        Canceled,
    }
}
