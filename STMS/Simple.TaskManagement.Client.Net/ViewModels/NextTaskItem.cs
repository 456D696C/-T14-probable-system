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
    public class NextTaskItem :INotifyPropertyChanged
    {
        
        public ReactiveProperty<string> InputTaskDescription { get; } 
        public ReactiveProperty<DataTypes.TaskType?> InputTaskType { get; }
        public ReactiveProperty<bool> HasErrors { get; }

        public NextTaskItem()
        {

            InputTaskDescription = new ReactiveProperty<string>();
            InputTaskType = new ReactiveProperty<DataTypes.TaskType?>();
            HasErrors = new ReactiveProperty<bool>(false);
        }

        public override string ToString()=>new { InputTaskDescription, InputTaskType}.ToString();

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

    }
}
