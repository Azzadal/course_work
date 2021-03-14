using System;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Kursovaya
{
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Style st = new Style();
            st.Setters.Add(new Setter { Property = FrameworkElement.MarginProperty, Value = new Thickness(4) });
            st.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Eras Light ITC") });
            st.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 16.0 });
            st.Setters.Add(new Setter { Property = TextBlock.TextAlignmentProperty, Value = TextAlignment.Center });

            int col = MainWindow.col;
            DataGridCell cell = value as DataGridCell;
            if (cell == null) return null;
            
            cell.Style = st;
            DataRowView drv = cell.DataContext as DataRowView;
            if (drv == null) return null;

            for (int i = 0; i < col; i++)
            {
                try
                {
                    Cell dataCell = null;
                    string valueOfCell = "0";
                    SolidColorBrush colorOfCell = null;
                    if (drv != null)
                    {
                        dataCell = (Cell)drv.Row[i];
                        valueOfCell = dataCell.Value;
                        colorOfCell = dataCell.Color;
                    }
                    //если значение ячейки простое число
                    if (Table.IsPrime(Int32.Parse(valueOfCell)))
                    {
                        dataCell.Color = Brushes.LightSkyBlue;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            return drv.Row[cell.Column.SortMemberPath];
        }
        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
