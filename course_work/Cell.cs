using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Kursovaya
{
    class Cell
    {
        public string Value { get; set; }
        public SolidColorBrush Color { get; set; }

        public Cell(string value, SolidColorBrush color)
        {
            Value = value;
            Color = color;
        }
    }
}
