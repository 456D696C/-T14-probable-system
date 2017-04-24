using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.TaskManagement.Common
{
    public static class Config
    {
        public class FileSystem
        {
            public const string BaseDirectory = @".\..\..\..\base";
            //public const string BaseDirectory = @".\base";

        }


        public class Queues
        {
            public const string FrontEnd = "front-end";
            public const string AuditFrontEnd = "audit-front-end";
            public const string MiddleEnd = "middle-end";
            public const string AuditMiddleEnd = "audit-middle-end";
            public const string BackEnd = "back-end";
            public const string AuditBackEnd = "audit-back-end";
        }
    }
}
