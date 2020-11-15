using System;

namespace HomeWork_3
{
    class Program
    {
        public void Start()
        {
            TransformationArray();
            FillInTheArray();
        }

        private int[,] ArraySize()
        {
            int a = 0;
            int b = 0;
            string greeting = "Пожалуйста введите размер двумерного массива";
            string greeting1 = "Введите размер первого измерения массива: ";
            string greeting2 = "Введите размер второго измерения массива: ";

            bool isNumberOne = false;
            bool isNumberTwo = false;

            do
            {
                Console.WriteLine(greeting);
                Console.WriteLine();
                Console.Write(greeting1);

                isNumberOne = int.TryParse(Console.ReadLine(), out a);
                if (!isNumberOne || a <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Неправильное число введите еще раз");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                Console.WriteLine();
            } while (!isNumberOne || a <= 0);

            do
            {
                Console.Write(greeting2);

                isNumberTwo = int.TryParse(Console.ReadLine(), out b);
                if (!isNumberTwo || b <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Неправильное число введите еще раз");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            } while (!isNumberTwo || b <= 0);

            return new int[a, b];
        }

        private void TransformationArray()
        {
            int[,] array = ArraySize();

            int max = 0;
            int min = 10;
            int sum = 0;
            int averageSum = array.GetLength(0) * array.GetLength(1);

            string maximum = "Максимальное значение в массиве: ";
            string minimum = "Минимальное значение в массиве: ";
            string averageValue = "Среднее значение в массиве: "; 

            Random random = new Random();

            Console.WriteLine();

            for (int  i = 0;  i < array.GetLength(0);  i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(0, 100);

                    sum += array[i, j];
                    

                    if (array[i, j] > max )
                    {
                        max = array[i,j];
                    }

                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                    }

                    Console.Write($"{array[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"{maximum}{max}");
            Console.WriteLine();
            Console.WriteLine($"{minimum}{min}");
            Console.WriteLine();
            Console.WriteLine($"{averageValue}{sum / averageSum}");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        private void FillInTheArray()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            string greeting = "Давайте теперь сделаем другой массив!";
            Console.WriteLine(greeting);
            Console.ResetColor();
            Console.WriteLine();

            int[,] array = ArraySize();

            PerimeterArray(array);
            DiagonalArray(array);
            ReducedValuesToMiddle(array);

            Console.WriteLine();   
            
            Console.ReadKey();
        }

        private void ReducedValuesToMiddle(int[,] array)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Уменьшение массива:");
            Console.ResetColor();
            Console.WriteLine();

            int[,] temporary = array;

            int size = array.GetLength(0);

            var step = 0;
            for (int i = 0; i < size; i++)
            {
                var counter = 1;

                for (int j = 0; j < size; j++)
                {
                    if (j - step < 0 || j + step >= size)
                        continue;
                    array[i, j] = counter++;
                }

                step += i + 1 <= size * 0.5 ? 1 : -1;
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{array[i, j]}");
                    Console.Write($"  ");
                }
                Console.WriteLine();
            }
        }

        private void PerimeterArray(int[,] array)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Периметр массива:");
            Console.ResetColor();
            Console.WriteLine();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    if (i == 0 || k == 0)
                    {
                        array[i, k] = 1;
                    }

                    if (i == array.GetLength(0) - 1 || k == array.GetLength(1) - 1)
                    {
                        array[i, k] = 1;
                    }

                    Console.Write(array[i, k]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }

        private void DiagonalArray(int[,] array)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Диагональ массива:");
            Console.ResetColor();
            Console.WriteLine();
            int temp = array.GetLength(1);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                { 
                    if(i == k || k == temp-1)
                    {
                        array[i, k] = 1;
                    }

                    else
                    {
                        array[i, k] = 0;
                    }
 
                    Console.Write(array[i, k]);
                    Console.Write("  ");
                }
                Console.WriteLine();
                temp--;
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
    }
}