using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DigitalClock
{
    public class ColorChooser
    {
        static Random r = new Random((int)DateTime.Now.Ticks);
        public static SolidColorBrush GetRandomColor()
        {
            return new SolidColorBrush(Color.FromRgb(
                (byte)(r.Next(0, 56) + 200),
                (byte)(r.Next(0, 56) + 200),
                (byte)(r.Next(0, 56) + 200)));
        }
    }
}
