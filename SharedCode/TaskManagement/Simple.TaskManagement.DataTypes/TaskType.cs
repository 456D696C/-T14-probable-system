using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Simple.TaskManagement.DataTypes
{
    public enum TaskType
    {
        [Description("None")]
        None,

        [Description("Idea")]
        Idea,

        //ANALYSIS

        [Description("Problem analysis")]
        Analysis,

        [Description("Concept")]
        Concept,

        [Description("Brainstorm")]
        Brainstorm,

        [Description("Research")]
        Research,

        [Description("Prototype")]
        Prototype,

        [Description("Project Development")]
        Develop,

        [Description("The Marketing Strategy")]
        Market,
    }
}
