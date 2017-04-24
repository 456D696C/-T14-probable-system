using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Simple.TaskManagement.ViewModels
{
    public class AboutThisViewModel
    {
        public string Title => GetType().Assembly
            .GetCustomAttributes(typeof(AssemblyTitleAttribute), false)
            .OfType<AssemblyTitleAttribute>()
            .FirstOrDefault()
            .Title
            ;
    }
}
