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
        public ReactiveProperty<string> InputCommentary { get; }
        public ReactiveProperty<DataTypes.CommentType> InputCommentType { get; }
        public ReactiveProperty<bool> HasErrors { get; }

        public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };
    }
}
