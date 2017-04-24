using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Reactive.Linq;
using System.Reactive.Threading;
using System.Reactive.Concurrency;
using Reactive.EventAggregator;
using Reactive.Bindings;
using Reactive.Bindings.Notifiers;
using Reactive.Bindings.Extensions;


namespace Simple.TaskManagement.ViewModels
{
    public class TextSearchViewModel
    {
        private readonly IEventAggregator EventAggregator;

        public TextSearchViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public ReactiveProperty<object> Keywords { get; } = new ReactiveProperty<object>();
        public ReactiveProperty<string> Term { get; }
        public ReactiveProperty<string> InputTerm { get; }
        public ReactiveProperty<string> SearchingStatus { get; }
        public ReactiveProperty<string> ProgressStatus { get; }
        public AsyncReactiveCommand Start { get; } = new AsyncReactiveCommand();
    }
}
