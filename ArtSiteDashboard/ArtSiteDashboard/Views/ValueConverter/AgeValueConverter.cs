using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace ArtSiteDashboard.Views;

public class AgeValueConverter : IValueConverter {
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        return $"Age: {value}";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}