using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Reactive.Bindings.Helpers;
using System.ComponentModel;
using System.Reactive.Linq;
using Reactive.EventAggregator;
using Reactive.Bindings.Notifiers;


using System.ComponentModel.DataAnnotations;

using Simple.TaskManagement;
using Simple.TaskManagement.Commands.Tasks;
using Simple.TaskManagement.Events.Tasks;


namespace Simple.TaskManagement.ViewModels
{
    public class TaskManagerViewModel : INotifyPropertyChanged
    {
        private readonly IEventAggregator EventAggregator;

        public ReactiveProperty<NextTaskItem> InputNextTaskItem { get; }
        public ReactiveCollection<DataTypes.Task> TaskList { get; } = new ReactiveCollection<DataTypes.Task>();


    


        public ReactiveCommand AddTodoItemCommand { get; }
        public AsyncReactiveCommand StartItemCommand { get; }
        public AsyncReactiveCommand CancelAsyncCommand { get; }
        private ReactiveProperty<bool> ShareSource { get; } = new ReactiveProperty<bool>(true);

        public TaskManagerViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

           
            InputNextTaskItem = new ReactiveProperty<NextTaskItem>(
                initialValue:new NextTaskItem(),
                mode:ReactivePropertyMode.DistinctUntilChanged|ReactivePropertyMode.RaiseLatestValueOnSubscribe
                );

            this.AddTodoItemCommand = this.InputNextTaskItem
               .Select(x => x.HasErrors)
               .Switch()
               .Select(x => !x)
               .ToReactiveCommand();
            this.AddTodoItemCommand
                .Select(_ => this.InputNextTaskItem.Value)
                .Subscribe(x =>
                {
                    var type = x.InputTaskType.Value;
                    var desctiption = x.InputTaskDescription.Value;

                    var task = new DataTypes.Task()
                    {
                        TaskDescription = desctiption,
                        TaskType = type,

                        Comments = new List<DataTypes.Comment>()
                        {
                            new DataTypes.Comment()
                        },
                        AssignedTo = new List<DataTypes.Contact>()
                        {
                            new DataTypes.Contact()
                        },

                    };


                    EventAggregator.Publish(Commands.Open.Create(task));


                    InputNextTaskItem.Value = new NextTaskItem();
                });



            var selection =
               EventAggregator.GetEvent<Events.Selection<DataTypes.Task>>()
               .Do(x => Console.WriteLine($"{new { x, Object = this }}"))
               .ToReactiveProperty();

            selection.Subscribe(x =>
            {
                EventAggregator.Publish(Commands.Open.Create(x?.Object));
            });

#if DEBUG


            var report = new TasksReport()
            {
                Tasks = new DataTypes.Mockups.MockupTasks().TaskList.ToList()

            };

            EventAggregator.Publish(report);
#endif
           
        }



        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
