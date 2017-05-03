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
    public class NextCommentItem : INotifyPropertyChanged
    {
        public ReactiveProperty<string> InputCommentary { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<DataTypes.CommentType?> InputCommentType { get; } = new ReactiveProperty<DataTypes.CommentType?>();
        public ReactiveProperty<bool> HasErrors { get; }

        public NextCommentItem()
        {

            var query =
            from comment in InputCommentary
            from type in InputCommentType
            select String.IsNullOrWhiteSpace(comment) 

            ;

            HasErrors = query.ToReactiveProperty(mode:ReactivePropertyMode.RaiseLatestValueOnSubscribe);
                    
        }

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
