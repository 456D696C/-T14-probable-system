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


namespace Simple.TaskManagement.ViewModels
{
    public class NextTaskManagerViewModel : INotifyPropertyChanged
    {
        public ReactiveProperty<DateTimeOffset?> RequiredByDate { get; set; }
        public ReactiveProperty<string> TaskDescription { get; set; }


        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
