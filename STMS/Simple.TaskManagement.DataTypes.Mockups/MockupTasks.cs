using System;
using System.Collections.Generic;
using System.Text;


using Simple.TaskManagement.DataTypes;

namespace Simple.TaskManagement.DataTypes.Mockups
{
    public class MockupTasks
    {
        public Simple.TaskManagement.DataTypes.Task[] Tasks { get; } = new Simple.TaskManagement.DataTypes.Task[]
        {

            new Simple.TaskManagement.DataTypes.Task()
            {
               TaskDescription ="",
               TaskId = "1"
            },

        };
    }
}
