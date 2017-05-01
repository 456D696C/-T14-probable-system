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


namespace Simple.TaskManagement.Converters
{
    public class DateTimeOffsetToDateTimeConverter: MarkupExtension, IValueConverter
    {
        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;

            if (targetType.IsAssignableFrom(typeof(DateTime)))
            {
                if (value == null) return DependencyProperty.UnsetValue;
                if( value is string & $"{value}".Trim()=="") return DependencyProperty.UnsetValue;
                if (value is string) return DateTime.ParseExact($"{value}", DataTypes.Constant.DateTimeFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AssumeUniversal);
            }

            if (targetType == typeof(string))
                if (value is string) return value;

#if DEBUG
            throw new NotImplementedException($"I don't understend {new { value, @typeof = value?.GetType() }} to {new { targetType }} conversion");
#else
            return value;
#endif
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string))
                return value;

            if(value == null) return (string)null;
            if(value == DependencyProperty.UnsetValue) return (string)null;

            if (value.GetType().IsAssignableFrom(typeof(DateTime)))
                return (value as DateTime?)?.ToUniversalTime().ToString(DataTypes.Constant.DateTimeFormat, DateTimeFormatInfo.InvariantInfo);

            return value;
        }


        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }


  

}
