using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;



using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Threading;
using System.Reactive.Disposables;




using Reactive.EventAggregator;




using Rebus.Bus;
using Rebus.Messages;
using Rebus.Handlers;
using Rebus.Auditing.Messages;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.Unity;
using Rebus.Subscriptions;
using Rebus.Sagas;
using Rebus.Persistence.InMem;
using Rebus.Persistence.FileSystem;
using Rebus.Transport.FileSystem;

using Simple.TaskManagement.Queries.Tasks;
using Simple.TaskManagement.Events.Tasks;

using Simple.TaskManagement.Commands.Tasks;

using Simple.TaskManagement.Commands.Comments;

using Simple.TaskManagement.Commands.Conacts;
using Simple.TaskManagement.Events.Contacts;

using Simple.TaskManagement.Events;

namespace Simple.TaskManagement
{
    class ClientService : IClientService
    {
        private readonly IEventAggregator Events;
        private readonly IBus Bus;
        private readonly IUnityContainer Container;

        public ClientService(IEventAggregator events, IBus bus, IUnityContainer container)
        {
            Events = events;
            Bus = bus;
            Container = container;

            #region Commands processing

            Events.GetEvent<AddOrUpdateTaskCommand>()
              .Select(async command => await Bus.Send(command))
              .Subscribe();

            Events.GetEvent<AssignContactToTaskCommand>()
             .Select(async command => await Bus.Send(command))
             .Subscribe();

            Events.GetEvent<UnassignContactFromTaskCommand>()
            .Select(async command => await Bus.Send(command))
            .Subscribe();

            Events.GetEvent<AddOrUpdateCommentCommand>()
            .Select(async command => await Bus.Send(command))
            .Subscribe();

            Events.GetEvent<DeleteCommentCommand>()
            .Select(async command => await Bus.Send(command))
            .Subscribe();


            Events.GetEvent<AddOrUpdateContactCommand>()
            .Select(async command => await Bus.Send(command))
            .Subscribe();

            Events.GetEvent<DeleteContactCommand>()
            .Select(async command => await Bus.Send(command))
            .Subscribe();

            #endregion

            #region Text searh 
            Events.GetEvent<Search<TasksSearchOnCommentsQuery>>()
                   .Select(q =>
                   {
                       var result = Events.GetEvent<Result<TasksSearchOnCommentsReport>>()
                            .Where(selection => selection.Object?.Reference == q.Object?.Reference)
                            .Timeout(TimeSpan.FromSeconds(7))
                            .Do(_=> { },exception=>
                            {
                                Events.Publish(Alert.Create($"{exception.Message}"));
                                Console.WriteLine(exception);
                            })
                            .Catch<Result<TasksSearchOnCommentsReport>,Exception>(exception=>
                            {
                                return Observable.Return(Result.Create(new TasksSearchOnCommentsReport()
                                {
                                    Query = q?.Object?.Query,
                                    Reference = q?.Object?.Reference,
                                    Tasks = new List<DataTypes.Task>()
                                }));
                            })
                            .FirstAsync()
                            .Publish()
                            .RefCount()
                            ;

                       Bus.Send(q.Object).Wait();

                       return result;
                   })
                   .Switch()
                   .Select(item =>
                      Observable.Defer(() =>
                         Observable.Start(() =>
                         {
                             Events.Publish(item);
                             return item;
                         })
                         .Catch(Observable.Empty<Result<TasksSearchOnCommentsReport>>())
                      )).Concat()
                   .Subscribe();
            #endregion          
        }

        public Task StartAsync()
        {
            return  Bus.Send(new TasksQuery());
        }
    }
}
