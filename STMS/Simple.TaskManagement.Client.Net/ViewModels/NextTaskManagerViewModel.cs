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

using Simple.TaskManagement;
using Simple.TaskManagement.Commands.Tasks;



namespace Simple.TaskManagement.ViewModels
{
    public class NextTaskManagerViewModel : INotifyPropertyChanged
    {
        private readonly IEventAggregator EventAggregator;

        public ReactiveProperty<DataTypes.Task> Current { get; }

        public AsyncReactiveCommand SaveAsyncCommand { get; }
        public AsyncReactiveCommand CancelAsyncCommand { get; }
        
        private ReactiveProperty<bool> ShareSource { get; } = new ReactiveProperty<bool>(true);


        public NextTaskManagerViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

            Current = new ReactiveProperty<DataTypes.Task>(new DataTypes.Task()
            {
                TaskId = "#next",
                TaskDescription = "<TaskDescription>",
                AssignedTo = new Dictionary<string, DataTypes.Contact>(),
                Comments = new Dictionary<string, DataTypes.Comment>(),
            });

            SaveAsyncCommand = this.ShareSource.ToAsyncReactiveCommand();
            SaveAsyncCommand.Subscribe(async _ =>
            {
                await Task.Run(() => EventAggregator.Publish(new AddOrUpdateTaskCommand()));
            });

            CancelAsyncCommand = ShareSource.ToAsyncReactiveCommand();
            CancelAsyncCommand.Subscribe(async _ =>
            {
                
                await Task.Run(() => EventAggregator.Publish(new AddOrUpdateTaskCommand()));
            });

        }

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
