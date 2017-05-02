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

using Simple.TaskManagement.Queries.Tasks;

namespace Simple.TaskManagement.ViewModels
{
    public class TextSearchViewModel
    {
        private readonly IEventAggregator EventAggregator;


        public ReactiveProperty<bool> IsSearching { get; } = new ReactiveProperty<bool>(true);

        public TextSearchViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;



            // Notifier of network connecitng status/count
            var connect = new CountNotifier();
            // Notifier of network progress report
            var progress = new ScheduledNotifier<Tuple<long, long>>(); // current, total

            // skip initialValue on subscribe
            InputTerm = new ReactiveProperty<string>(mode: ReactivePropertyMode.DistinctUntilChanged);

            // Search asynchronous & result direct bind
            // if network error, use OnErroRetry
            // that catch exception and do action and resubscript.
            Term =
            InputTerm
            .Do(x => System.Diagnostics.Debug.WriteLine($"{nameof(InputTerm)}->[{x}]"))
                .Throttle(TimeSpan.FromMilliseconds(100))
                .Select(async term =>
                {
                    using (connect.Increment()) // network open
                    {

                        var query = Events.Search.Create(new TasksSearchOnCommentsQuery()
                        {
                            Reference = Guid.NewGuid().ToString("N"),
                            Query = term,
                        });

                        await Task.Run(()=>eventAggregator.Publish(query));

                        return query?.ToString();
                    }
                })
                .Switch() // flatten
                .OnErrorRetry((Exception ex) => ProgressStatus.Value = $"Error occured {ex?.Message}")
                .ToReactiveProperty()
                ;

            // CountChangedStatus : Increment(network open), Decrement(network close), Empty(all complete)
            SearchingStatus = connect
                .Select(x => (x != CountChangedStatus.Empty) ? "loading..." : "complete")
                .ToReactiveProperty()
                ;

            ProgressStatus = progress
                .Select(x => string.Format("{0}/{1} {2}%", x.Item1, x.Item2, ((double)x.Item1 / x.Item2) * 100))
                .ToReactiveProperty();


            Start.Subscribe(async _ =>
            {
                var term = InputTerm.Value;

                var query = Events.Search.Create(new TasksSearchOnCommentsQuery()
                {
                    Reference = Guid.NewGuid().ToString("N"),
                    Query = term,
                });

                await Task.Run(()=>eventAggregator.Publish(query));
            });


            Term.Subscribe(x =>
            {
                if(!String.IsNullOrWhiteSpace(x))
                {
                    IsSearching.Value = true;
                }

            });
            
            Cancel.Subscribe(x =>
            {
                IsSearching.Value = false;
            });
        }

        public ReactiveProperty<object> Keywords { get; } = new ReactiveProperty<object>();
        public ReactiveProperty<string> Term { get; }
        public ReactiveProperty<string> InputTerm { get; }
        public ReactiveProperty<string> SearchingStatus { get; }
        public ReactiveProperty<string> ProgressStatus { get; }
        public AsyncReactiveCommand Start { get; } = new AsyncReactiveCommand();
        public ReactiveCommand Cancel = new ReactiveCommand();
    }
}
