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

        

        public ReactiveProperty<String> InputTaskDescription { get; }
        public ReactiveProperty<DataTypes.TaskType?> InputTaskType { get; }
        public ReactiveCollection<DataTypes.Comment> InputComments { get; } = new ReactiveCollection<DataTypes.Comment>();
        public ReactiveProperty<NextCommentItem> InputNextComment { get; } 
        public ReactiveCommand AddCommentCommand { get; } 

        public OpenTaskItem(IEventAggregator eventAggregator, DataTypes.Task task)
        {
            EventAggregator = eventAggregator;
            Task = new ReactiveProperty<DataTypes.Task>(task);


            InputTaskType = ReactiveProperty.FromObject(task,x=>x.TaskType);
            InputTaskDescription = ReactiveProperty.FromObject(task, x => x.TaskDescription);
            InputComments.AddRangeOnScheduler(task.Comments);

            

            InputNextComment = new ReactiveProperty<NextCommentItem>(
                initialValue: new NextCommentItem(),
                mode:ReactivePropertyMode.DistinctUntilChanged | ReactivePropertyMode.RaiseLatestValueOnSubscribe
                );


            InputTaskType.Do(x => Console.WriteLine($"INPUT TASK TYPE:{x}"));
            InputTaskDescription.Do(x => Console.WriteLine($"INPUT TASK DESCRIPTION:{x}"));


            AddCommentCommand = new ReactiveCommand();
            AddCommentCommand
                .Subscribe(x =>
                {
                    InputComments.Add(new DataTypes.Comment()
                    {
                        CommentType = InputNextComment.Value.InputCommentType.Value,
                        Commentary = InputNextComment.Value.InputCommentary.Value,
                    });

                    InputNextComment.Value = new NextCommentItem();
                });



            var query =
                from comment in InputNextComment.Value.InputCommentary
                from type in InputNextComment.Value.InputCommentType
                select new DataTypes.Comment()
                {
                    Commentary = comment,
                    CommentType = type,
                };


            query.Subscribe(x=>Console.WriteLine($"NEXT COMMENT:{x}"));
            
        }

        #region Comment Types

        public IEnumerable<DataTypes.CommentType> CommentTypes
        {
            get
            {
                return Enum.GetValues(typeof(DataTypes.CommentType))
                    .OfType<DataTypes.CommentType>().Where(x=>0 < x );
            }
        }

        #endregion


        public override string ToString() => new {Task}.ToString();

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
