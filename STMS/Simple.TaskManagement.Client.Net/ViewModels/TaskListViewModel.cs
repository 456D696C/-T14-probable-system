using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;


using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.PlatformServices;
using System.Reactive.Threading;
using System.Reactive.Joins;
using System.Reactive.Linq;
using Reactive.EventAggregator;
using Reactive.Bindings;
using Reactive.Bindings.Notifiers;
using Reactive.Bindings.Extensions;

using Simple.TaskManagement.DataTypes;
using Simple.TaskManagement.Events.Tasks;

namespace Simple.TaskManagement.ViewModels
{
    public class TaskListViewModel
    {
        private readonly IEventAggregator EventAggregator;

        public TaskListViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;



            Tasks = EventAggregator.GetEvent<TasksReport>()
                .ObserveOnDispatcher()
                .Select(found => found?.Tasks.OfType<DataTypes.Task>().ToArray())
                .ToReactiveProperty(new DataTypes.Mockups.MockupTasks().TaskList);

        }

        public ReactiveProperty<DataTypes.Task[]> Tasks { get; }
    }
}
