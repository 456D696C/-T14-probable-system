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


namespace Simple.TaskManagement.ViewModels
{
    public class TaskManagerViewModel : INotifyPropertyChanged
    {
        private readonly IEventAggregator EventAggregator;

        public ReactiveProperty<DataTypes.Task[]> Editor { get; }
        

        public TaskManagerViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

            var selection =
                EventAggregator.GetEvent<Events.Selection<DataTypes.Task>>()
                .Do(x=>Console.WriteLine($"{new { x , Object = this}}"))
                .ToReactiveProperty();

            Editor = selection.Where(x=>x?.Object != null).Select(x => new DataTypes.Task[]
            {
                x.Object

            })
            .Do(x => Console.WriteLine($"{new { x, Object = this }}"))
            .ToReactiveProperty();

            selection.Subscribe(x=>Console.WriteLine($"SUBSCRIBE:{new { x, Object = this }}"));
        }



        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
