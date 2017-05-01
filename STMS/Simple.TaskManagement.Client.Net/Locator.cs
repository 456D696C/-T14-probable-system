using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Practices.Unity;

using Simple.TaskManagement.ViewModels;



namespace Simple.TaskManagement
{
    public class Locator
    {
        public AboutThisViewModel AboutThis { get; }
        public ApplicationSessionViewModel Session { get; }
        public TaskListViewModel TaskList { get; }
        public TextSearchViewModel TextSearch { get; }
        public SearchResultViewModel SearchResult { get; }
        public NextTaskFactoryViewModel Factory { get; }
        public VisualNotificationSystemViewModel VisualNotifications { get; }

        public Locator()
        {
            var container = Bootstrapper.RegisterTypes(new UnityContainer());

            AboutThis = container.Resolve<AboutThisViewModel>();
            Session = container.Resolve<ApplicationSessionViewModel>();
            TaskList = container.Resolve<TaskListViewModel>();
            TextSearch = container.Resolve<TextSearchViewModel>();
            SearchResult = container.Resolve<SearchResultViewModel>();
            Factory = container.Resolve<NextTaskFactoryViewModel>();
            VisualNotifications = container.Resolve<VisualNotificationSystemViewModel>();


            container.Resolve<IClientService>().StartAsync().Wait();
  
        }


        #region Task Types
        public IEnumerable<DataTypes.TaskType> TaskTypes
        {
            get
            {
                return Enum.GetValues(typeof(DataTypes.TaskType))
                    .OfType<DataTypes.TaskType>();
            }
        }

        public IEnumerable<DataTypes.TaskType> NewTaskTypes
        {
            get
            {
                return Enum.GetValues(typeof(DataTypes.TaskType))
                    .OfType<DataTypes.TaskType>().Where(x=>x>0);
            }
        }

        #endregion

        #region Task Statuses
        public IEnumerable<DataTypes.TaskStatus> TaskStatuses
        {
            get
            {
                return Enum.GetValues(typeof(DataTypes.TaskStatus))
                    .OfType<DataTypes.TaskStatus>();
            }
        }

        public IEnumerable<DataTypes.TaskStatus> TaskNewStatuses
        {
            get
            {
                return Enum.GetValues(typeof(DataTypes.TaskStatus))
                    .OfType<DataTypes.TaskStatus>().Where(x=>x > 0);
            }
        }

        #endregion


        public IEnumerable<string> Contacts
        {
            get
            {
                yield return "applicant@abv.bg";
                yield return "bill@abv.bg";
                yield return "will@abv.bg";
                yield return "hill@abv.bg";
            }
        }
    }
}
