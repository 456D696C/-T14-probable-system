using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Reactive.Bindings;
using System.ComponentModel;
using System.Reactive.Linq;
using Reactive.EventAggregator;
using Reactive.Bindings.Notifiers;
using Reactive.Bindings.Extensions;

namespace Simple.TaskManagement.ViewModels
{
    public class TaskEditorViewModel : INotifyPropertyChanged
    {
        private readonly IEventAggregator EventAggregator;

        public ReactiveCollection<DataTypes.Task> OpenTaskList { get; } = new ReactiveCollection<DataTypes.Task>();


        public ReactiveProperty<DataTypes.Task> Current { get; }

        public AsyncReactiveCommand SaveAsyncCommand { get; }
        public AsyncReactiveCommand CancelAsyncCommand { get; }

        private ReactiveProperty<bool> ShareSource { get; } = new ReactiveProperty<bool>(true);

        public TaskEditorViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

            var open =
               EventAggregator.GetEvent<Commands.Open<DataTypes.Task>>()
               .Do(x => Console.WriteLine($"{new { x, Object = this }}"))
               .ToReactiveProperty();

            open.Subscribe(x =>
            {
                var task = x?.Object;

                OpenTaskList.ClearOnScheduler();

                if(null != task)
                {
                    OpenTaskList.AddOnScheduler(task);
                }
            });
        }

        
        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
