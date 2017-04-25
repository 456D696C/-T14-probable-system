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
    public class NextTaskFactoryViewModel  : INotifyPropertyChanged
    {
        private readonly IEventAggregator EventAggregator;

        public ReadOnlyReactiveProperty<IEnumerable<NextTaskManagerViewModel>> Next { get; }
        public AsyncReactiveCommand StartAsyncCommand { get; }


        public NextTaskFactoryViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

       

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
