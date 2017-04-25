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

using Simple.TaskManagement.Events;
using Simple.TaskManagement.DataTypes;
using Simple.TaskManagement.Queries;
using Simple.TaskManagement.Events.Tasks;

namespace Simple.TaskManagement.ViewModels
{
    public class SearchResultViewModel
    {
        private readonly IEventAggregator EventAggregator;

        public SearchResultViewModel(IEventAggregator  eventAggregator)
        {
            EventAggregator = eventAggregator;


            SelectedItem = new ReactiveProperty<Object>(mode:
                           ReactivePropertyMode.DistinctUntilChanged//|ReactivePropertyMode.RaiseLatestValueOnSubscribe
                           );


            TaskList = EventAggregator.GetEvent<Result<TasksSearchOnCommentsReport>>()
                .ObserveOnDispatcher()
                .Select(found => found.Object.Tasks.OfType<DataTypes.Task>().ToArray())
                .ToReactiveProperty();


            SelectedTask =
            SelectedItem.Select(x => x as DataTypes.Task)
            .ToReadOnlyReactiveProperty();

            var disposable =
                SelectedTask
                .Subscribe(x => EventAggregator.Publish(new Events.Selection<DataTypes.Task>(x)));




            SelectedItem.Subscribe();
        }

        public ReactiveProperty<Object> SelectedItem { get; }
        public ReadOnlyReactiveProperty<DataTypes.Task> SelectedTask { get; }
        public ReactiveProperty<DataTypes.Task[]> TaskList { get; }


    }
}
