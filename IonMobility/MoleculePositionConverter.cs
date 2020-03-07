using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IonMobility
{
    public class MoleculePositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var relativePosition = (double)values[0];
            var canvasSize = (double)values[1];
            var diameter = (double)values[2];

            if (double.IsNaN(canvasSize))
            {
                return 0.0;
            }

            var canvasPosition = (canvasSize * relativePosition) - (diameter / 2.0);

            return canvasPosition;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
