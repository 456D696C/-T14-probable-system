using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement
{
    namespace Commands.Conacts
    {
        public partial class AddOrUpdateStaffMemberCommand { }
        public partial class DeleteStaffMemberCommand { }
    }

    namespace Queries.Contacts
    {
        partial class ContactStatusQuery { }
        partial class ContactListQuery { }
    }

    namespace Events.Contacts
    {
        partial class ContactStatusReport { }
        partial class ContactListReport { }
    }
}
