using System;
using System.Collections.Generic;

namespace HomeWork_2
{
    class Program
    {
        public void Init()
        {
            NumberDivision();
            CaclulatorAdvanced();
        }

        private void CaclulatorAdvanced()
        {
            string greeting = "Теперь мы в калькуляторе. Введите два числа: ";
            string oneGreeting = "Первое число: ";
            string twoGreeting = "Второе число: ";
            string InputOne = "";
            string InputTwo = "";
            string sign = "";
            string operation = "Выберите операцию: (+) (-) (*) (/)";
            string operation2 = "А также корень первого числа, нажмите цифру [1] (√)";
            string operation3 = "Или первое число возведенное в степень второго , нажмите цифру [2] (^)";
            string yourAnswer = "Ваш ответ: ";
            string restart = "";

            double one = 0;
            double two = 0;
            double answer = 0;

            bool isCorrectNumberOne = false;
            bool isCorrectNumberTwo = false;
            bool isCorrectOperation = false;
            bool isRestartApplication = false;
            bool isContinue = false;

            Console.WriteLine(greeting);
            Console.WriteLine();
            do
            {
                do
                {
                    if (!isContinue)
                    {
                        do
                        {
                            Console.Write(oneGreeting);
                            InputOne = Console.ReadLine();
                            isCorrectNumberOne = double.TryParse(InputOne, out one);
                        }
                        while (!isCorrectNumberOne);
                    }

                    else
                    {
                        Console.WriteLine($"Первое число: {answer}");
                        one = answer;
                    }

                    do
                    {
                        Console.WriteLine();
                        Console.Write(twoGreeting);
                        InputTwo = Console.ReadLine();
                        isCorrectNumberTwo = double.TryParse(InputTwo, out two);
                    }
                    while (!isCorrectNumberTwo);

                    Console.WriteLine();
                    Console.WriteLine(operation);
                    Console.WriteLine();
                    Console.WriteLine(operation2);
                    Console.WriteLine();
                    Console.WriteLine(operation3);
                    sign = Console.ReadLine();

                    switch (sign)
                    {
                        case "+":
                            answer = one + two;
                            isCorrectOperation = true;
                            break;
                        case "-":
                            answer = one - two;
                            isCorrectOperation = true;
                            break;
                        case "*":
                            answer = one * two;
                            isCorrectOperation = true;
                            break;
                        case "/":
                            if (two == 0)
                            {
                                Console.WriteLine("делить на ноль нельзя!!");
                                Console.WriteLine();
                                isCorrectOperation = false;
                                break;
                            }

                            else
                            {
                                answer = one / two;
                                isCorrectOperation = true;
                            }
                            break;
                        case "1":
                            {
                                answer = Math.Sqrt(one);
                                isCorrectOperation = true;
                            }
                            break;
                        case "2":
                            {
                                answer = Math.Pow(one, two);
                                isCorrectOperation = true;
                            }
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"{yourAnswer}{answer}");
                    Console.WriteLine();
                    Console.WriteLine("Что вы хотите делать дальше?");
                    Console.WriteLine();
                    Console.WriteLine("Нажмите [1] для повторного вычисления");
                    Console.WriteLine("Нажмите [2] для продолжения");
                    Console.WriteLine("Нажмите любую другую клавишу для выхода");

                    restart = Console.ReadLine();
                    switch (restart)
                    {
                        case "1":
                            isCorrectOperation = false;
                            isContinue = false;
                            Console.Clear();
                            break;
                        case "2":
                            isCorrectOperation = false;
                            one = answer;
                            isContinue = true;
                            Console.Clear();
                            break;
                        default:
                            isRestartApplication = true;
                            break;
                    }
                }
                while (!isCorrectOperation);
            }
            while (!isRestartApplication);
        }

        private int[] SliceValueToArray(int number)
        {
            List<int> array = new List<int>();

            while (number > 0)
            {
                array.Add(number % 10);
                number /= 10;
            }

            return array.ToArray();
        }

        private void NumberDivision()
        {
            string greeting = "Введите пятизначное число: ";
            string userInput = "";
            string numberGreeintg = " цифра равна: ";
            string numberMax = "самая большая цифра: ";
            string numberMin = "самая маленькая цифра: ";

            int userInputValue = 0;
            int min = 10;
            int max = 0;

            int[] numberCount = new int[5];

            bool isNumber;
            bool isFiveNumber;
            bool isCompleted;

            do
            {
                Console.WriteLine(greeting);
                userInput = Console.ReadLine();
                Console.WriteLine();

                isFiveNumber = userInput.Length == 5;
                isNumber = int.TryParse(userInput, out userInputValue);
                isCompleted = isFiveNumber && isNumber;

                numberCount = SliceValueToArray(userInputValue);

                if (isNumber && isFiveNumber)
                {
                    for (int i = 0; i < userInput.Length; i++)
                    {
                        Console.Write($"{i + 1}{numberGreeintg}{userInput[i]}");
                        Console.WriteLine();
                    }

                    for (int i = 0; i < numberCount.Length; i++)
                    {
                        if(numberCount[i]>= max)
                        {
                            max = numberCount[i];
                        }

                        else if(numberCount[i]<= min)
                        {
                            min = numberCount[i];
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine($"{numberMax}{max}");
                    Console.WriteLine($"{numberMin}{min}");
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine("Not correct value, try again");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (!isCompleted);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Init();
        }
    }
}