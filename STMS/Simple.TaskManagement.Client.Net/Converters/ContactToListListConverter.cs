using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Markup;
using System.Globalization;
using Simple.TaskManagement.DataTypes;


namespace Simple.TaskManagement.Converters
{
    
    public class ContactToListListConverter : MarkupExtension, IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null) return DependencyProperty.UnsetValue;


            if (typeof(IEnumerable<Contact>).IsAssignableFrom(value.GetType()))
                return (value as IEnumerable<Contact>)?.FirstOrDefault()?.Id??DependencyProperty.UnsetValue;

            if (typeof(IEnumerable<string>).IsAssignableFrom(value.GetType()))
                return (value as IEnumerable<string>)?.FirstOrDefault()??DependencyProperty.UnsetValue;


            return DependencyProperty.UnsetValue;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = value as string;

            if (id != null) return new List<Contact>(new Contact[] { new Contact() { Id = id } });

            return value;
        }


        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
