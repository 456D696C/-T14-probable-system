using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using Reactive.Bindings;
using System.ComponentModel;
using System.Reactive.Linq;
using Reactive.EventAggregator;
using Reactive.Bindings.Notifiers;
using Reactive.Bindings.Extensions;

namespace Simple.TaskManagement.ViewModels
{
    public class ApplicationSessionViewModel
    {
        private readonly IEventAggregator EventAggregator;
        private ReactiveProperty<bool> ShareSource { get; } = new ReactiveProperty<bool>(true);

        public ApplicationSessionViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

            PowerOfAsyncCommand = ShareSource.ToAsyncReactiveCommand();

            PowerOfAsyncCommand.Subscribe(async _ =>
            {
                await Task.Factory.StartNew(() =>
                {
                    //
                    // Summary:
                    //     Closes a process that has a user interface by sending a close message to its
                    //     main window.
                    //
                    // Returns:
                    //     true if the close message was successfully sent; false if the associated process
                    //     does not have a main window or if the main window is disabled (for example if
                    //     a modal dialog is being shown).
                    //
                    return Process.GetCurrentProcess().CloseMainWindow();
                }).ContinueWith(t =>
                {
                    //TODO: Issue clossing notification, 
                }, TaskScheduler.FromCurrentSynchronizationContext());
            });

        }

        public AsyncReactiveCommand PowerOfAsyncCommand { get; }

    }
}
