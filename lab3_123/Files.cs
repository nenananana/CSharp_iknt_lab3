using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Files
    {
        private readonly Random _random = new Random();

        // Метод для заполнения файла случайными целыми числами
        public void FillFileWithRandomNumbers(string filePath, int count)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < count; i++)
                {
                    int randomNumber = _random.Next(1, 101); // Случайные числа от 1 до 100
                    writer.WriteLine(randomNumber);
                }
            }
        }

        // Метод для чтения из файла и нахождения среднего арифметического макс и мин элемента
        public double CalculateAverageOfMinMax(string filePath)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int count = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number))
                    {
                        if (number < min) min = number;
                        if (number > max) max = number;
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                Console.WriteLine($"Min:{min} Max:{max}");
                return (min + max) / 2.0; // Возращаем среднее арифметическое
            }
            else
            {
                throw new InvalidOperationException("Файл не содержит чисел.");
            }
        }
    }
}

