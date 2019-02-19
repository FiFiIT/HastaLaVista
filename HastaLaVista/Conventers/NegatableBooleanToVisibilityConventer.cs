﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace HastaLaVista.Conventers
{
    public class NegatableBooleanToVisibilityConventer : MarkupExtension, IValueConverter
    {
        public bool Negate { get; set; }
        public Visibility FalseVisibility { get; set; }

        public NegatableBooleanToVisibilityConventer()
        {
            FalseVisibility = Visibility.Collapsed;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bVal;
            bool result = Boolean.TryParse(value.ToString(), out bVal);

            if (!result) return value;

            if (bVal && !Negate || !bVal && Negate) return Visibility.Visible;

            return FalseVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
