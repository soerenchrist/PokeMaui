using System.Drawing;

namespace PokeMaui.Util;

public static class StringExtensions
{
    public static string Capitalize(this string value)
    {
        if (value.Length == 0)
            return value;
        if (value.Length == 1)
            return value.ToUpper();
        return value[0].ToString().ToUpper() + value[1..];
    }
}
