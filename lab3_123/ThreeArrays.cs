using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class ThreeArrays
    {
        private int[,] array;
        public ThreeArrays(int n, int m)
        {
            array = new int[n, m];
            for (int j = m - 1; j >= 0; j--)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    Console.Write($"Введите элемент [{i},{j}]: ");
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        array[i, j] = value;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Элемент будет равен 0.");
                        array[i, j] = 0;
                    }
                }
            }
        }
        public ThreeArrays(int n)
        {
            array = new int[n, n];
            Random random = new Random();
            for (int j = 0; j < n; j++)
            {
                int prev = random.Next(100); //  Начальное значение
                for (int i = 0; i < n; i++)
                {
                    array[i, j] = prev + random.Next(1, 11); //Добавляем случайное число от 1 до 10
                    prev = array[i, j];
                }
            }
        }
        public ThreeArrays(int n, int m, int count = 2)
        {
            array = new int[n, n];
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    while (true)
                    {
                        if (ItsSimple(count))
                        {
                            array[i, j] = count;
                            count++;
                            break;
                        }
                        count++;
                    }

                }
            }
        }
        public ThreeArrays(int[,] array)
        {
            this.array = array;
        }

        public bool ItsSimple(int n)
        {
            if (((n % 2 == 0) & (n != 2) || (n % 3 == 0) & (n != 3) || (n % 5 == 0) & (n != 5) || (n % 7 == 0) & (n != 7)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Shkolniki()
        {
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
                double average = sum / array.GetLength(1);
                if (average > 4.5)
                {
                    Console.WriteLine($"Школьник №{i + 1} (среднее: {average})");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("В списке нет школьников, средняя оценка которых выше 4,5.");
            }
        }
        public void PrintArray()
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{array[i, j],6}");
                }
                Console.WriteLine();
            }
        }

        public static ThreeArrays operator ~(ThreeArrays matrix)
        {
            int rows = matrix.array.GetLength(0);
            int cols = matrix.array.GetLength(1);

            int[,] transposedData = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposedData[j, i] = matrix.array[i, j];
                }
            }

            return new ThreeArrays(transposedData);
        }
        // Перегрузка оператора сложения
        public static ThreeArrays operator +(ThreeArrays a, ThreeArrays b)
        {
            int rows = a.array.GetLength(1);
            int cols = a.array.GetLength(0);

            if (a.array.GetLength(0) != b.array.GetLength(0) || a.array.GetLength(1) != a.array.GetLength(1))
            {
                Console.WriteLine("Размерность матриц не одинакова. Выполнение операции невозможно");
                Environment.Exit(0);
            }

            int[,] result = new int[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result[i, j] = a.array[i,j] + b.array[i,j];
                }
            }
            return new ThreeArrays(result);
        }

        // Перегрузка оператора вычитания
        public static ThreeArrays operator -(ThreeArrays a, ThreeArrays b)
        {
            int rows = a.array.GetLength(1);
            int cols = a.array.GetLength(0);

            if (a.array.GetLength(0) != b.array.GetLength(0) || a.array.GetLength(1) != a.array.GetLength(1))
            {
                Console.WriteLine("Размерность матриц не одинакова. Выполнение операции невозможно");
                Environment.Exit(0);
            }


            int[,] result = new int[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result[i, j] = (a.array[i, j] - b.array[i, j]);
                }
            }
            return new ThreeArrays(result);
        }

        // Перегрузка оператора умножения на скаляр
        public static ThreeArrays operator *(int scalar, ThreeArrays a)
        {
            int rows = a.array.GetLength(1);
            int cols = a.array.GetLength(0);

            int[,] result = new int[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result[i, j] = a.array[i, j]*scalar;
                }
            }

            return new ThreeArrays(result);
        }

        // Перегрузка метода ToString для отображения матрицы
        public override string ToString()
        {

            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            var result = string.Empty;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += $"{array[i, j], 6} "; 
                }
                result += "\n"; 
            }
            return result;
        }
    }
}
