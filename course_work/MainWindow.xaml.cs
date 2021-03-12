using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int str;
        private Random random = new Random();
        public DataTable InputTable { get; set; }
        public DataTable Table { get; set; }
        public static int col;
        BackgroundWorker bw;

        public MainWindow()
        {
            InitializeComponent(); 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(strField.Text, out str))
            {
                MessageBox.Show("Неверное значение строк");
                return;
            }
            if (!Int32.TryParse(colField.Text, out col))
            {
                MessageBox.Show("Неверное значение колонок");
                return;
            }

            ValueOfMatrix valueOfMatrix = new ValueOfMatrix(str, col);
            //некоторые свойства для сетки
            matrix2.CanUserSortColumns = false;
            if (str < 20) matrix2.EnableRowVirtualization = false;
            matrix2.HorizontalContentAlignment = new HorizontalAlignment();
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += BW_RunWorkerCompleted;
            bw.RunWorkerAsync(valueOfMatrix);
        }

        void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ValueOfMatrix input = (ValueOfMatrix)e.Argument;
            int str = input.Str;
            int col = input.Col;
            int[,] arr = new int[str, col];

            //заполнение двумерного массива случайными числами
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arr[i, j] = random.Next(1, 150);
                }
            }
            //заполнение DataTable данными из массива
            InputTable = CreateTable.ToDataTable(arr);
            Table = new DataTable();
            int b = 0;
            //создание DataTable на основе исходной, с пользовательским типом данных
            foreach (DataColumn column in InputTable.Columns)
            {
                ++b;
                Table.Columns.Add("c" + b, typeof(Cell));
            }
            //заполнение Table
            for (int i = 0; i < InputTable.Rows.Count; i++)
            {
                var row = Table.NewRow();
                var values = InputTable.Rows[i].ItemArray;
                SolidColorBrush colors = Brushes.Salmon;

                for (int j = 0; j < InputTable.Columns.Count; j++)
                {
                    Cell cell = new Cell(values[j] as string, colors);
                    row[j] = cell;
                }
                Table.Rows.Add(row);
            }
            e.Result = Table;
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //Ошибка была сгенерирована обработчиком события DoWork
                MessageBox.Show(e.Error.Message, "Произошла ошибка");
            }
            else
            {
                DataTable dt = e.Result as DataTable;
                matrix2.ItemsSource = dt.DefaultView;
            }
        }

        void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataTemplate dt = null;

            if (e.PropertyType == typeof(Cell))
                dt = (DataTemplate)Resources["GridCell"];

            if (dt != null)
            {
                DataGridTemplateColumn c = new DataGridTemplateColumn()
                {
                    CellTemplate = dt,
                    Header = e.Column.Header,
                    HeaderTemplate = e.Column.HeaderTemplate,
                    HeaderStringFormat = e.Column.HeaderStringFormat,
                    SortMemberPath = e.PropertyName
                };
                e.Column = c;
            }
        }
        private void SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            (sender as DataGrid).SelectionUnit = DataGridSelectionUnit.Cell;
            (sender as DataGrid).SelectedCells.Clear();
        }
    }
}