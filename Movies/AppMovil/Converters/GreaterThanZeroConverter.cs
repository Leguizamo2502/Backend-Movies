using System.Globalization;

namespace AppMovil.Converters
{
    public sealed class GreaterThanZeroConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is null) return false;

            return value switch
            {
                sbyte v => v > 0,
                byte v => v > 0,
                short v => v > 0,
                ushort v => v > 0,
                int v => v > 0,
                uint v => v > 0,
                long v => v > 0,
                ulong v => v > 0,
                string s => long.TryParse(s, out var n) && n > 0,
                _ => false
            };
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
