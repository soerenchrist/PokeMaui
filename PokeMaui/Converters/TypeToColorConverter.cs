using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMaui.Converters;

public class TypeToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string str)
        {
            return str.ToLower() switch
            {
                "grass" => Color.FromArgb("#78C850"),
                "water" => Color.FromArgb("#6890F0"),
                "fighting" => Color.FromArgb("#C03028"),
                "electric" => Color.FromArgb("#F8D030"),
                "fire" => Color.FromArgb("#F08030"),
                "ice" => Color.FromArgb("#98D8D8"),
                "poison" => Color.FromArgb("#A040A0"),
                "ground" => Color.FromArgb("#E0C068"),
                "flying" => Color.FromArgb("#A890F0"),
                "psychic" => Color.FromArgb("#F85888"),
                "bug" => Color.FromArgb("#A8B820"),
                "rock" => Color.FromArgb("#B8A038"),
                "ghost" => Color.FromArgb("#705898"),
                "dark" => Color.FromArgb("#705848"),
                "dragon" => Color.FromArgb("#7038F8"),
                "steel" => Color.FromArgb("#B8B8D0"),
                "fairy" => Color.FromArgb("#F0B6BC"),
                "normal" => Color.FromArgb("#A8A878"),
                _ => Colors.Transparent,
            };
        }

        return Colors.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
