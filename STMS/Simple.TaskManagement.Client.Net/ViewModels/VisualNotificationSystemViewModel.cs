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
using MaterialDesignThemes.Wpf;

namespace Simple.TaskManagement.ViewModels
{
    public class VisualNotificationSystemViewModel : ISnackbarMessageQueue
    {
        private readonly IEventAggregator Events;
        public SnackbarMessageQueue Queue { get; } = new SnackbarMessageQueue();


        public VisualNotificationSystemViewModel(IEventAggregator events)
        {
            Events = events;
        }

        public void Enqueue(object content)
        {
            ((ISnackbarMessageQueue)Queue).Enqueue(content);
        }

        public void Enqueue(object content, bool neverConsiderToBeDuplicate)
        {
            ((ISnackbarMessageQueue)Queue).Enqueue(content, neverConsiderToBeDuplicate);
        }

        public void Enqueue(object content, object actionContent, Action actionHandler)
        {
            ((ISnackbarMessageQueue)Queue).Enqueue(content, actionContent, actionHandler);
        }

        public void Enqueue(object content, object actionContent, Action actionHandler, bool promote)
        {
            ((ISnackbarMessageQueue)Queue).Enqueue(content, actionContent, actionHandler, promote);
        }

        public void Enqueue<TArgument>(object content, object actionContent, Action<TArgument> actionHandler, TArgument actionArgument)
        {
            ((ISnackbarMessageQueue)Queue).Enqueue<TArgument>(content, actionContent, actionHandler, actionArgument);
        }

        public void Enqueue<TArgument>(object content, object actionContent, Action<TArgument> actionHandler, TArgument actionArgument, bool promote)
        {
            ((ISnackbarMessageQueue)Queue).Enqueue<TArgument>(content, actionContent, actionHandler, actionArgument, promote);
        }
    }
}
