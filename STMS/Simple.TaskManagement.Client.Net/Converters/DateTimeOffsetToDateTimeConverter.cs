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
            var dateTimeOffsetValue = value as DateTimeOffset?;

            return dateTimeOffsetValue == null ? DependencyProperty.UnsetValue : dateTimeOffsetValue.Value.UtcDateTime.Date;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value as string;


            DateTime date; 
            if (stringValue!=null && (stringValue = $"{stringValue}").Trim() != "" &&
                    DateTime.TryParseExact(stringValue, "dd-MMM-yyyy",DateTimeFormatInfo.InvariantInfo,DateTimeStyles.AssumeUniversal,out date))
                    return (DateTimeOffset)date.ToUniversalTime();

            if (stringValue == "") return (DateTimeOffset?)null;

            var dateTimeValue = value as DateTime?;
   
            if (null != dateTimeValue) return (DateTimeOffset)dateTimeValue.Value.ToUniversalTime();

            return value;
        }


        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }


  

}
