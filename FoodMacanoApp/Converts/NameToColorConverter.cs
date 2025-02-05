using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoApp.Converts
{
    public class NameToColorConverter : IValueConverter
    {
        // Lista predefinida de colores agradables
        private static readonly Color[] Colors = new[]
        {
            Color.FromArgb("#FF5733"), // Coral
            Color.FromArgb("#33A1FF"), // Azul claro
            Color.FromArgb("#FF33A1"), // Rosa
            Color.FromArgb("#33FF57"), // Verde menta
            Color.FromArgb("#A133FF"), // Púrpura
            Color.FromArgb("#FF9233"), // Naranja
            Color.FromArgb("#3357FF"), // Azul real
            Color.FromArgb("#FF3357"), // Rojo rosado
            Color.FromArgb("#33FFA1"), // Turquesa
            Color.FromArgb("#A1FF33")  // Verde lima
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name && !string.IsNullOrEmpty(name))
            {
                // Usar el nombre para generar un índice consistente
                int hashCode = name.GetHashCode();
                int colorIndex = Math.Abs(hashCode) % Colors.Length;

                return Colors[colorIndex];
            }

            // Color por defecto si no hay nombre
            return Colors[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
