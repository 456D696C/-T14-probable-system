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

    public class VisualNotificationSystemViewModel
    {
        private readonly IEventAggregator EventAggregator;

        public VisualNotificationSystemViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

            EventAggregator.GetEvent<Events.Alert>()
                .Subscribe(aller =>
                {
                    Main.Enqueue((aller?.ToString() ?? "Something goes completely wrong").ToUpper());
                });

        }

        public VisualNotificationQueue Main { get; } = new VisualNotificationQueue();
        public VisualNotificationQueue TaskEditor { get; } = new VisualNotificationQueue();
    }
 
}
