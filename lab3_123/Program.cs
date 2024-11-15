using System;
using System.Data;
using lab3;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static void Main()
    {
        string ex;

        Console.WriteLine("Выберете номер задания: \n\n" +
            "1.  Задание 1.\n" +
            "2.  Задание 2.\n" +
            "3.  Задание 3.\n" +
            
            "6.  Задание 6.\n" );
        ex = Console.ReadLine();
        switch (ex)
        {
            case "1":
                try
                {
                    Console.WriteLine("Первый массив размерность n x m заполняется данными, вводимыми с клавиатуры, так что заполнение ведется по столбцам от последних элементов столбца к первым");
                    Console.WriteLine("Кол-во строк в массиве: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Кол-во столбцов в массиве: ");
                    int m = Convert.ToInt32(Console.ReadLine());
                    ThreeArrays arr1 = new ThreeArrays(n, m);
                    arr1.PrintArray();

                    Console.WriteLine("\nВторой массив, размерностью n х n, заполняется случайными числами так, что в каждом столбце\r\nполучается возрастающая последовательность элементов.");
                    Console.WriteLine("Введите размерность массива: ");
                    int n2 = Convert.ToInt32(Console.ReadLine());
                    ThreeArrays arr2 = new ThreeArrays(n2);
                    arr2.PrintArray();

                    Console.WriteLine("\nТретий массив, размерностью n х n, заполняется последовательностью простых чисел, начиная с 2: ");
                    Console.WriteLine("Введите размерность массива: ");
                    int n3 = Convert.ToInt32(Console.ReadLine());
                    ThreeArrays arr3 = new ThreeArrays(n3, n3, 2);
                    arr3.PrintArray();
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }
                break;
            case "2":
                try
                {
                    Console.WriteLine("В двумерном массиве записаны по m оценок n школьников. Показывает номера школьников, средняя оценка которых больше 4.5.");
                    Console.WriteLine("Кол-во школьников: ");
                    int n4 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Кол-во оценок: ");
                    int m4 = Convert.ToInt32(Console.ReadLine());
                    Random random = new Random();
                    int[,] array4 = new int[n4, m4];

                    for (int i = 0; i < n4; i++)
                    {
                        for (int j = 0; j < m4; j++)
                        {
                            array4[i, j] = random.Next(2, 6); // Генерация числа от 2 до 5
                        }
                    }
                    ThreeArrays arr4 = new ThreeArrays(array4);
                    arr4.PrintArray();
                    arr4.Shkolniki();
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }
                break;
            case "3":
                Console.WriteLine("Значение матичного выражение А^т-В^т+2*С. ");

                Console.WriteLine("Кол-во строк в массиве А: ");
                int nA = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Кол-во столбцов в массиве А: ");
                int mA = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Кол-во строк в массиве В: ");
                int nB = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Кол-во столбцов в массиве В: ");
                int mB = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Кол-во строк в массиве С: ");
                int nC = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Кол-во столбцов в массиве С: ");
                int mC = Convert.ToInt32(Console.ReadLine());

                int[,] aArray = new int[nA, mA];
                int[,] bArray = new int[nB, mB];
                int[,] cArray = new int[nC, mC];
                Random rand = new Random();
                for (int i = 0; i < nA; i++)
                {

                    for (int j = 0; j < mA; j++)
                    {
                        aArray[i, j] = rand.Next(-10, 20);
                    }
                }
                for (int i = 0; i < nB; i++)
                {
                    for (int j = 0; j < mB; j++)
                    {
                        bArray[i, j] = rand.Next(-10, 20);
                    }
                }

                for (int i = 0; i < nC; i++)
                {
                    for (int j = 0; j < mC; j++)
                    {
                        cArray[i, j] = rand.Next(-10, 20);
                    }
                }
                ThreeArrays A = new ThreeArrays(aArray);
                ThreeArrays B = new ThreeArrays(bArray);
                ThreeArrays C = new ThreeArrays(cArray);
                Console.WriteLine("A: ");
                Console.WriteLine(A.ToString());
                Console.WriteLine("B: ");
                Console.WriteLine(B.ToString());
                Console.WriteLine("C: ");
                Console.WriteLine(C.ToString());


                Console.WriteLine("1: A^т");
                Console.WriteLine((~A).ToString() + "\n");
                Console.WriteLine("2: В^т");
                Console.WriteLine((~B).ToString() + "\n");
                Console.WriteLine("3: 2*С");
                Console.WriteLine((2*C).ToString() + "\n");
                Console.WriteLine("4: А^т-В^т");
                Console.WriteLine(((~A)-(~B)).ToString() + "\n");

                ThreeArrays result = (~A) - (~B) + (2 * C);

                Console.WriteLine("5: Результат матричного выражения А^т-В^т+2*С:");
                Console.WriteLine(result.ToString());
                break;
            case "6":
                string filePath = "numbers.txt";
                Files files = new Files();
                Console.WriteLine("Кол-во чисел в файле: ");
                int count = Convert.ToInt32(Console.ReadLine());
                // Заполнение файла случайными числами
                files.FillFileWithRandomNumbers(filePath, count);

                // Вычисление и вывод среднего арифметического max и min элементов
                try
                {
                    double average = files.CalculateAverageOfMinMax(filePath);
                    Console.WriteLine($"Среднее арифметическое максимального и минимального элементов: {average}");
                }
                catch 
                {
                    Console.WriteLine($"Ошибка.");
                }
                break;
            default:
                Console.WriteLine("Такого номера нет или вы нажали лишний раз на пробел.");
                break;

        } 
    }
}