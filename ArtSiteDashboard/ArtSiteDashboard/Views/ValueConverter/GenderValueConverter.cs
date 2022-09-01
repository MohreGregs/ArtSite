using System;
using System.Globalization;
using ArtSite.Data.Enums;
using Avalonia.Data.Converters;

namespace ArtSiteDashboard.Views;

public class GenderValueConverter : IValueConverter {
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        switch (value) {
            case Gender.Female:
                return "Gender: Female";
            case Gender.Male:
                return "Gender: Male";
        }

        return "Gender: Unknown";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}