using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Rebus.Handlers;
using Reactive.EventAggregator;
using Simple.TaskManagement.Events.Tasks;
using Simple.TaskManagement.Events;


namespace Simple.TaskManagement.Handlers.Tasks
{
    class TasksSearchOnCommentsReportMessageHandler: IHandleMessages<TasksSearchOnCommentsReport>
    {
        private readonly IEventAggregator EventAggregator;

        public TasksSearchOnCommentsReportMessageHandler(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public Task Handle(TasksSearchOnCommentsReport message)
        {
            return Task.Run(()=> EventAggregator.Publish(Selection.Create(message)));
        }
    }
}
