using System;
using System.Globalization;
using ArtSite.Data.Models;
using Avalonia.Data.Converters;

namespace ArtSiteDashboard.Views.ValueConverter; 

public class OriginalDesignerConverter : IValueConverter {
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        var designer = value as ArtistModel;
        return designer == null ? "Designer: Unknown" : $"Designer: {designer.Name}";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}