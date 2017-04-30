using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.TaskManagement.DataTypes
{
    public class Task
    {
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? RequiredByDate { get; set; }
        public string TaskDescription { get; set; }
        public TaskStatus? TaskStatus { get; set; }
        public TaskType? TaskType { get; set; }
        public List<Contact> AssignedTo { get; set; }
        public List<Comment> Comments { get; set; }
        public string TaskNumber { get; set; }
        public string TaskId { get; set; }
        public DateTimeOffset NextActionDate { get; set; }
    }
}
