using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.TaskManagement.DataTypes
{
    public class Comment
    {
        public DateTimeOffset? DateAdded { get; set; }
        public string Commentary { get; set; }
        public CommentType CommentType { get; set; }
        public DateTimeOffset? ReminderDate { get; set; }
        public string Number { get; set; }
        public string CommentId { get; set; }
        public string TaskId { get; set; }
    }
}
