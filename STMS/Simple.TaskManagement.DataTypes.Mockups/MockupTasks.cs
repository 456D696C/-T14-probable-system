using System;
using System.Collections.Generic;
using System.Text;


using Simple.TaskManagement.DataTypes;

namespace Simple.TaskManagement.DataTypes.Mockups
{
    public class MockupTasks
    {
        public Simple.TaskManagement.DataTypes.Task[] Tasks { get; } = new DataTypes.Task[]
                {
                    new DataTypes.Task()
                    {
                        TaskId = "1",
                        TaskDescription = "Remember The Milk",
                        

                        Comments = new Dictionary<string, Comment>()
                        {
                            { "1.1", new Comment() { ReminderDate = "2017-05-01",  Commentary="for simple task management without distraction"} }

                        },
                    },

                    new DataTypes.Task()
                    {
                        TaskId = "2",
                        TaskDescription = "Everyday",
                        
                        Comments = new Dictionary<string, Comment>()
                        {
                            { "2.1", new Comment() { ReminderDate = "2017-05-05",  Commentary="for quickly swiping through projects"} }

                        },
                    },
                    //Clear 	Clear 	simple, gesture-based interface
                    new DataTypes.Task()
                    {
                        TaskId = "3",
                        TaskDescription = "Clear",
                        

                        Comments = new Dictionary<string, Comment>()
                        {
                            { "3.1", new Comment() { ReminderDate = "2017-05-01",  Commentary="simple, gesture-based interface"} }

                        },
                    },
                    //Swipes 	Swipes 	snoozing your tasks until you're ready to do them
                    new DataTypes.Task()
                    {
                        TaskId = "4",
                        TaskDescription = "Swipes",
                       
                        Comments = new Dictionary<string, Comment>()
                        {
                            { "4.1", new Comment() { ReminderDate = "2017-05-05",  Commentary="snoozing your tasks until you're ready to do them"} }

                        },
                    }
                };


       
    }
}
