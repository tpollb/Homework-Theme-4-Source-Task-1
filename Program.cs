using System;
using System.Linq;

namespace Homework_Theme_4_Source_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            int MinValue = 0;
            int MaxValue = 5;
            int rows = 12;
            int cols = 4;
            int NumberOfProfitMonth = 0;
            
            int[] WorthMonth = new int[rows];
            int[] WorthMonthSorted = new int[rows + 1];
            int[] Profit = new int[rows];
            int[,] table = new int[rows, cols];
            string[] Month = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

            Random rand = new Random();

            Console.WriteLine("   Месяц   |Доход, т.р. |Расход, т.р |Прибыль, т.р|");
            for (i = 0; i < rows ; i++)
            {
                for (j = 0; j < cols; j++)
                {
                    table[i, j] = rand.Next(MinValue, MaxValue); //можно точно так же заполнить из 2х одномерных массивов, с заранее определёнными данными, но суть не меняет
                    //первый столбец с номерами месяцев
                    int ii = i;
                    table[i, 0] = ii + 1;

                    //последний столбец с прибылью (сумма 2 и 3 столбца)
                    table[i, cols - 1] = table[i, cols - 3] - table[i, cols - 2];
                    Profit[i] = table[i, cols - 1];

                    Console.Write($"{table[i, j],10} | ");
                }
                //определение количества прибыльных
                if (table[i, cols - 1] > 0)
                {
                    NumberOfProfitMonth++;
                } else
                {
                    WorthMonth[i] = table[i, cols - 1];
                    WorthMonthSorted[i] = table[i, cols - 1];
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Количество прибыльных месяцев: {NumberOfProfitMonth}");
            Console.WriteLine();

            //Три худших показателя:
            Console.WriteLine($"Три худших месяца:");
            Array.Sort(WorthMonthSorted);

            k = 0;

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < rows; j++)
                {
                    if (WorthMonthSorted[i] == Profit[j])
                    {
                        if (k == 3) break;
                        Console.Write($"{Month[j]}: {WorthMonthSorted[i]}  ");
                        k++;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            for (i = 0; i < rows; i++)
            {
                for (j = i + 1; j < rows; j++)
                {
                    if (Profit[i] == Profit[j])
                    {
                        Console.WriteLine($"Месяц {Month[i]} с прибылью {Profit[i]} равен месяцу {Month[j]} с прибылью {Profit[j]}");
                    }
                }
            }

            /*
            //вывод прибыли
            for (i = 0; i < rows; i++)
            {
                Console.Write($"{Profit[i]}  ");
            }
            */

                Console.ReadKey();
        }
    }
}
