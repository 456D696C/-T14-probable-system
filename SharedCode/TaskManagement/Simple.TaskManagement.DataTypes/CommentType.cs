using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Simple.TaskManagement.DataTypes
{
    public enum CommentType
    {
        
        None,

        [Description("*\t")]
        SubTaks,

        [Description("i\t\t")]
        SubTaskItem,

        [Description("n\t")]
        Note
    }
}
