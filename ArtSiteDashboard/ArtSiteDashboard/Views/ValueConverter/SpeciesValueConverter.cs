using System;
using System.Globalization;
using ArtSite.Data.Models;
using Avalonia.Data.Converters;

namespace ArtSiteDashboard.Views.ValueConverter; 

public class SpeciesValueConverter : IValueConverter{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        var species = value as SpeciesModel;
        return species == null ? "Species: Unknown" : $"Species: {species.Name}";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}