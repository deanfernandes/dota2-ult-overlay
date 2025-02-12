﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DeanFernandes.Dota2UltOverlay.Views
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanInverterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return !booleanValue;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
