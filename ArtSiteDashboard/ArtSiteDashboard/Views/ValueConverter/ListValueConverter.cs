using System;
using System.Collections.Generic;
using System.Globalization;
using ArtSite.Data.Models;
using Avalonia.Data.Converters;

namespace ArtSiteDashboard.Views.ValueConverter; 

public class ListValueConverter : IValueConverter {
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        var list = value as HashSet<BaseNameModel>;
        
        if (list is null) return default;

        var listString = "";
        
        foreach (var item in list) {
            listString += $"- {item.Name} \r\n";
        }

        return listString;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}