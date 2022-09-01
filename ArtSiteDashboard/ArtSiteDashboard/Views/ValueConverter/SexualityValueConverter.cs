using System;
using System.Globalization;
using ArtSite.Data.Enums;
using Avalonia.Data.Converters;

namespace ArtSiteDashboard.Views;

public class SexualityValueConverter : IValueConverter {
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        switch (value) {
            case Sexuality.Heterosexual:
                return "Sexuality: Heterosexual";
            case Sexuality.Bisexual:
                return "Sexuality: Bisexual";
            case Sexuality.Homosexual:
                return "Sexuality: Homosexual";
            case Sexuality.Asexual:
                return "Sexuality: Asexual";
        }

        return "Sexuality: Unknown";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}