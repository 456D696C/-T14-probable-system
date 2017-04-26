using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Simple.TaskManagement.DataTypes;

namespace Simple.TaskManagement.DataTypes.Mockups
{
    public class MockupTasks
    {

        public Simple.TaskManagement.DataTypes.Task[] TaskList => AdvancedTaskList();

        #region Simple task list
        Simple.TaskManagement.DataTypes.Task[] SimpleTaskList() => new DataTypes.Task[]
        {
                    new DataTypes.Task()
                    {
                        TaskId = "1",
                        TaskDescription = "Remember The Milk",


                        Comments = new Dictionary<string, Comment>()
                        {
                            { "1.1", new Comment() { Commentary="for simple task management without distraction"} }

                        },
                    },

                    new DataTypes.Task()
                    {
                        TaskId = "2",
                        TaskDescription = "Everyday",

                        Comments = new Dictionary<string, Comment>()
                        {
                            { "2.1", new Comment() {  Commentary="for quickly swiping through projects"} }

                        },
                    },
                    //Clear 	Clear 	simple, gesture-based interface
                    new DataTypes.Task()
                    {
                        TaskId = "3",
                        TaskDescription = "Clear",


                        Comments = new Dictionary<string, Comment>()
                        {
                            { "3.1", new Comment() {  Commentary="simple, gesture-based interface"} }

                        },
                    },
                    //Swipes 	Swipes 	snoozing your tasks until you're ready to do them
                    new DataTypes.Task()
                    {
                        TaskId = "4",
                        TaskDescription = "Swipes",

                        Comments = new Dictionary<string, Comment>()
                        {
                            { "4.1", new Comment() {   Commentary="snoozing your tasks until you're ready to do them"} }

                        },
                    }
        };
        #endregion

        #region Advanced task list

        Simple.TaskManagement.DataTypes.Task[] AdvancedTaskList() => new DataTypes.Task[]
        {
            Analysis,
            Research,
            Prototype,
            Develop,
            Market
        }
        .Select((x, n) => { x.TaskId = $"#{n}"; return x; })
        .ToArray();


        #region Analysis
        DataTypes.Task Analysis { get; } = new DataTypes.Task()
        {


            TaskType = TaskType.Analysis,

            RequiredByDate = DateTime.Parse("2017-01-01"),

            TaskDescription = "The concept of T14 was born",

            AssignedTo = new Dictionary<string, Contact>()
            {
                { "applicant@abv.bg", new Contact() }
            },

            Comments = new Dictionary<string, Comment>()
            {
                { "1.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = "Analyze the task."
                    }
                },

                 { "2.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = "Understand the problem area."
                    }
                },


                { "3.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = "Examine existing solutions."
                    }
                },

                { "4.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = "Evaluate available resources."
                    }
                },

                { "4.1", new Comment()
                    {
                        CommentType = CommentType.SubTaskItem,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = "such as time"
                    }
                },
                { "4.2", new Comment()
                    {
                        CommentType = CommentType.SubTaskItem,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = "such as time",
                    }
                },
            }

        };
        #endregion

        #region Research
        DataTypes.Task Research { get; } = new DataTypes.Task()
        {


            TaskType = TaskType.Analysis,

            RequiredByDate = DateTime.Parse("2017-01-01"),

            TaskDescription = "Research, Research, Research existing solutions.",

            AssignedTo = new Dictionary<string, Contact>()
            {
                { "applicant@abv.bg", new Contact() }
            },

            Comments = new Dictionary<string, Comment>()
            {
                { "1.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = @"Simple task management systems."
                    }
                },

                { "1.1", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = @"Simple task management systems i.e. 
                                       http://www.capterra.com/task-management-software/ 
                                     ."
                    }
                },

                { "1.2", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = @"Simple task management systems i.e. 
                                      https://xbsoftware.com/case-studies-webdev/project-management-tool-for-communications-portal/."
                    }
                },


                 { "2.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = "Cool 'TODO' apps at https://zapier.com/blog/best-todo-list-apps/"
                    }
                },

                 { "2.1", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = "Remember the milk https://zapier.com/blog/best-todo-list-apps/#remember"
                    }
                },

                 { "2.2", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = "Everyday https://zapier.com/blog/best-todo-list-apps/#everyday"
                    }
                },

            }

        };
        #endregion

        #region Prototype
        DataTypes.Task Prototype { get; } = new DataTypes.Task()
        {

            TaskType = TaskType.Prototype,

            RequiredByDate = DateTime.Parse("2017-01-01"),

            TaskDescription = "Developed prototypes.",

            AssignedTo = new Dictionary<string, Contact>()
            {
                { "applicant@abv.bg", new Contact() }
            },

            Comments = new Dictionary<string, Comment>()
            {
                { "1.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = @"Developed very first prototypes were developed."
                    }
                },

                { "1.1", new Comment()
                    {
                        CommentType = CommentType.Note,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = @"The very first prototypes were developed."
                    }
                },

            }

        };
        #endregion

        #region Develop
        DataTypes.Task Develop { get; } = new DataTypes.Task()
        {


            TaskType = TaskType.Develop,

            RequiredByDate = DateTime.Parse("2017-01-01"),

            TaskDescription = "Developed Project.",

            AssignedTo = new Dictionary<string, Contact>()
            {
                { "applicant@abv.bg", new Contact() }
            },

            Comments = new Dictionary<string, Comment>()
            {
                { "1.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = @"Developing some of the core software features."
                    }
                },

                { "2.", new Comment()
                    {
                        CommentType = CommentType.Note,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = @"Develop the rest."
                    }
                },

            }

        };
        #endregion

        #region Market
        DataTypes.Task Market { get; } = new DataTypes.Task()
        {

            TaskId = "C# Task#1",

            TaskType = TaskType.Market,

            RequiredByDate = DateTime.Parse("2017-01-01"),

            TaskDescription = "Invent a good name for the product.",

            AssignedTo = new Dictionary<string, Contact>()
            {
                { "applicant@abv.bg", new Contact() }
            },

            Comments = new Dictionary<string, Comment>()
            {
                { "1.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary =
                    @"The code name T14 comes from а game of words
                        Task for Task-ing
                        аnd
                        the popular T4 template feature.
                        The 'T14-probable-system' is the name automatically generated by git,
                        вhich began to appeal to me in time."
                    }
                },

                { "2.", new Comment()
                    {
                        CommentType = CommentType.SubTaks,
                        ReminderDate = DateTime.Now.AddDays(-3),
                        Commentary = @"Invent a good name for the product."
                    }
                },

            }

        };
        #endregion

        #endregion

    }
}
