using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Simple.TaskManagement.DataTypes
{
    public enum CommentType
    {
        
        None,

        [Description("Work Item")]
        Item,

        [Description("Note")]
        Note
    }
}
