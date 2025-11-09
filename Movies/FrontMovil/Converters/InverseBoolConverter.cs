using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace FrontMovil.Converters;

public class InverseBoolConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolean)
        {
            return !boolean;
        }

        return true;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
