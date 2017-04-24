using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.TaskManagement.DataTypes
{
    public class Comment
    {
        public string DateAdded { get; set; }
        public string Commentary { get; set; }
        public string CommentType { get; set; }
        public string ReminderDate { get; set; }
        public string CommentId { get; set; }
        public string TaskId { get; set; }
    }
}
