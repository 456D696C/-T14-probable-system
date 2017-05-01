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
    public class TaskEditor
    {
        private readonly IEventAggregator EventAggregator;

        public ReactiveProperty<DataTypes.Task> Current { get; }

        public AsyncReactiveCommand SaveAsyncCommand { get; }
        public AsyncReactiveCommand CancelAsyncCommand { get; }

        private ReactiveProperty<bool> ShareSource { get; } = new ReactiveProperty<bool>(true);

        public TaskEditor(IEventAggregator eventAggregator, DataTypes.Task task)
        {
            EventAggregator = eventAggregator;
            Current = new ReactiveProperty<DataTypes.Task>(task);
        }

        
    }
}
