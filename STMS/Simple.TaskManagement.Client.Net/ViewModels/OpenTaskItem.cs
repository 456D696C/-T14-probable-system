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

using Simple.TaskManagement;
using Simple.TaskManagement.Commands.Tasks;
using Simple.TaskManagement.Events.Tasks;


namespace Simple.TaskManagement.ViewModels
{
    public class OpenTaskItem : INotifyPropertyChanged
    {
        private readonly IEventAggregator EventAggregator;

        public ReactiveProperty<DataTypes.Task> Task { get; } 

        public OpenTaskItem(IEventAggregator eventAggregator, DataTypes.Task task)
        {
            EventAggregator = eventAggregator;
            Task = new ReactiveProperty<DataTypes.Task>(task);
        }

        public override string ToString() => new {Task}.ToString();

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
