using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace ArtSiteDashboard.Views.ValueConverter; 

public class ColorConverter : IValueConverter{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        if (value is null) return default;
        var colorString = value.ToString();
        var transparency = int.Parse(colorString.Substring(0, 2), NumberStyles.HexNumber);
        var red = int.Parse(colorString.Substring(2, 2), NumberStyles.HexNumber);
        var green = int.Parse(colorString.Substring(4, 2), NumberStyles.HexNumber);
        var blue = int.Parse(colorString.Substring(6, 2), NumberStyles.HexNumber);
        var color = Color.FromArgb((byte)transparency, (byte)red, (byte)green,(byte) blue);
        return new SolidColorBrush(color);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}