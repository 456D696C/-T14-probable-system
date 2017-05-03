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

            SelectedItem = new ReactiveProperty<Object>(mode:
                          ReactivePropertyMode.DistinctUntilChanged//|ReactivePropertyMode.RaiseLatestValueOnSubscribe
                          );

            SelectedTask =
            SelectedItem.Select(x => x as DataTypes.Task)
            .ToReadOnlyReactiveProperty()
            ;

            var disposable =
               SelectedTask
               .Subscribe(x => EventAggregator.Publish(new Events.Selection<DataTypes.Task>(x)));


            SelectedItem.Do(x =>
            {
                Console.WriteLine($"SELECTED ITEM:{x}");
            });

            SelectedItem.Subscribe(x =>
            {
                Console.WriteLine($"SUBSCRIBE SELECTED ITEM:{x}");
            });

            Tasks = EventAggregator.GetEvent<TasksReport>()
                .Do(x=>Console.WriteLine($"Received:{x}"))
                .ObserveOnDispatcher()
                .Select(found => found?.Tasks.OfType<DataTypes.Task>().ToArray())
                .ToReactiveProperty();



        }

        public ReactiveProperty<Object> SelectedItem { get; }
        public ReadOnlyReactiveProperty<DataTypes.Task> SelectedTask { get; }
        public ReactiveProperty<DataTypes.Task[]> Tasks { get; }


      
    }
}
