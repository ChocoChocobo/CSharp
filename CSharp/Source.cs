using System;

namespace CSharp
{
    class Source
    {
        static void Main(string[] args)
        {
            int[,] array2D = new int[5,5];
            // 0 0 0 0 0
            // 0 0 0 0 0
            // 0 0 0 0 0
            // 0 0 0 0 0
            // 0 0 0 0 0
            // приставка u говорит о беззнаковом типе данных
            uint[,] intArray2D =
            {
                {5, 6, 7, 8, 9 },
                {1, 2, 3, 4, 5 },
                {1, 2, 3, 4, 5 },
                {1, 2, 3, 4, 5 },
                {1, 2, 3, 4, 5 },
            };

            /*for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = j * 2;
                    Console.WriteLine($"({i},{j}). {array2D[i, j]}");
                }
            }*/

            for (int i = 0; i < intArray2D.GetLength(0); i++)
            {
                for (int j = 0; j < intArray2D.GetLength(1); j++)
                {
                    Console.Write($"({i},{j}). {intArray2D[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}

//      Практика
// В двумерном массиве найти максимальный элемент для каждой строки
// Работать со следующим массивом или сгенерировать такой самостоятельно:
/*          uint[,] intArray2D =
            {
                {5, 6, 7, 8, 9 },
                {70, 2, 3, 4, 5 },
                {1, 80, 3, 4, 5 },
                {1, 40, 3, 4, 5 },
                {1, 2, 25, 4, 5 },
            };*/