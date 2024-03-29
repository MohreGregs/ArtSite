using System;
using System.Globalization;
using System.Text;
using Avalonia.Data.Converters;

namespace ArtSiteDashboard.Views.ValueConverter {
    public class BytesToTextConverter : IValueConverter {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
            if (value == null ) {
                return "";
            }

            if (value is string) 
                return value;
            
            var unconvertedText = value as byte[];

            return Encoding.UTF8.GetString(unconvertedText);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
            if (value == null) {
                return Array.Empty<byte>();
            }

            if (value is byte[]) 
                return value;
            
            var unconvertedText = value as string;

            return Encoding.UTF8.GetBytes(unconvertedText);
        }
    }
}