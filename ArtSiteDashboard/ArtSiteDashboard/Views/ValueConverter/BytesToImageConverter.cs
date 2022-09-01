using System;
using System.Globalization;
using System.IO;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace ArtSiteDashboard.Views.ValueConverter; 

public class BytesToImageConverter : IValueConverter{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        if (value is null) return default;
        
        var data = (byte[]) value;

        using (var stream = new MemoryStream(data)) {
            var bitmap = new Bitmap(stream);
            return bitmap;
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}