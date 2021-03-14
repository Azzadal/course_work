using System.Data;

namespace Kursovaya
{
    static class Table
    {
        // проверка на простое число
        public static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // получение DataTable из массива
        public static DataTable CreateDataTable(int[,] matrix)
        {
            var res = new DataTable();

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col " + i);
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }
                res.Rows.Add(row);
            }
            return res;
        }
    }
}
