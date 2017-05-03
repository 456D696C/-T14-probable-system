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

using MaterialDesignThemes;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;

using Simple.TaskManagement.DataTypes;
using Simple.TaskManagement.Converters.Extensions;


namespace Simple.TaskManagement.Converters
{
    class EnumConverters
    {
        MaterialDesignThemes.Wpf.PackIconKind _Icon;
    }

    /// <summary>
    /// Converter to show description of an enum, and convert back to enum value on selecting an item from combo box in wpf.
    /// </summary>
    /// <see cref="http://stackoverflow.com/a/36987113"/>
    public class EnumToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = value as Enum;

            return enumValue == null ? DependencyProperty.UnsetValue : enumValue.GetDescriptionFromEnumValue();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }


        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }


    public class CommentTypeToPackIconKindConverter : MarkupExtension, IValueConverter
    {
        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var commentType = value as CommentType?;
  
            switch(commentType)
            {
                case CommentType.Item:return PackIconKind.Note;
                case CommentType.Note:return PackIconKind.Comment;
                
                default:return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }


        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
