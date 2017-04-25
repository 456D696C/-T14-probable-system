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
        public string TaskStatus { get; set; }
        public string TaskType { get; set; }
        public List<string> AssignedTo { get; set; }
        public Dictionary<string,Comment> Comments { get; set; }
        public string TaskId { get; set; }
        //public string NextActionDate { get; set; }
    }
}
