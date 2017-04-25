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
using Simple.TaskManagement.DataTypes;

namespace Simple.TaskManagement.ViewModels
{
    public class NextTaskManagerViewModel : INotifyPropertyChanged
    {
        public ReactiveProperty<DataTypes.Task> Task { get; }


        public NextTaskManagerViewModel()
        {
            Task = new ReactiveProperty<DataTypes.Task>(new DataTypes.Task()
            {
                TaskId = "#next",
                AssignedTo = new Dictionary<string, Contact>(),
                Comments = new Dictionary<string, Comment>(),
            });
        }

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
