using System;

namespace HomeWork_1
{
    class Program
    {
        public string EnteredName()
        {
            string name = null;
            var enterName = "Please enter your name to start: ";

            Console.Write($"{enterName}{name}");

             return name = Console.ReadLine();
        }

        public void WelcomeGreetings(string name)
        {
            Console.WriteLine();

            string welcome = "Welcome to your first homework assignment ";

            var colorGreen = ConsoleColor.Green;
            var colorBlue = ConsoleColor.Blue;

            Console.ForegroundColor = colorGreen;

            Console.Write($"{welcome}");
            
            Console.ForegroundColor = colorBlue;

            Console.WriteLine($"{name}");

            Console.ResetColor();
            Console.WriteLine();

            QuadraticEquation();
            CalculateHypatenuse();
        }

        private void QuadraticEquation()
        {
            string enterNumber = "Now you can find square solution, please enter 3 number: ";

            string[] counter = new string[3] { "First number: ", "Second number: ", "Third number: " };
            string[] number = new string[3] { "", "", "" };

            string number1 = null;
            string number2 = null;
            string number3 = null;

            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;

            bool succes1 = false;
            bool succes2 = false;
            bool succes3 = false;
            bool wrongCurrentValue = true;

            while (wrongCurrentValue)
            {
                var colorYellow = ConsoleColor.Yellow;
                Console.ForegroundColor = colorYellow;

                Console.WriteLine($"{enterNumber}");
                Console.WriteLine();
                Console.ResetColor();

                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{counter[i]}");
                    number[i] = Console.ReadLine();
                    Console.WriteLine();
                }

                succes1 = double.TryParse(number[0], out a);
                succes2 = double.TryParse(number[1], out b);
                succes3 = double.TryParse(number[2], out c);

                if (succes1 && succes2 && succes3)
                {
                    d = b * b - 4 * a * c;

                    if (d < 0)
                    {
                        wrongCurrentValue = false;

                        var colorRed = ConsoleColor.Red;
                        Console.ForegroundColor = colorRed;

                        Console.WriteLine("Discriminant less than zero. No roots.");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Press any key");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    
                    if(d == 0)
                    {
                        wrongCurrentValue = false;

                        double x = (-b / (2 * a));

                        var colorGreen = ConsoleColor.Green;
                        Console.ForegroundColor = colorGreen;

                        Console.WriteLine($"Discriminant equals: (0). The root is equal: ({x})");

                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Press any key");
                        Console.ReadKey();
                    }

                    if (d > 0)
                    {
                        wrongCurrentValue = false;

                        double x1 = ((-b - Math.Sqrt(d)) / (2 * a));
                        double x2 = ((-b + Math.Sqrt(d)) / (2 * a));

                        var colorGreen = ConsoleColor.Green;
                        Console.ForegroundColor = colorGreen;

                        Console.WriteLine($"Discriminant equals: ({d}), The first root is equal: ({x1}), The second root is equal: ({x2})");

                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Press any key");
                        Console.ReadKey();
                    }
                    
                }

                else
                {
                    var colorRed = ConsoleColor.Red;
                    Console.ForegroundColor = colorRed;

                    Console.WriteLine("Sorry, not correct value try again");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void CalculateHypatenuse()
        {
            Console.Clear();

            string greeting = "Well, now let's calculate the length of the hypotenuse, and find all angles in triangle";
            string enterNumber = "Please enter 2 cathetus: ";

            string[] counter = new string[2] { "First cathetus: ", "Second cathetus: " };
            string[] number = new string[2] { "", "" };

            double a = 0;
            double b = 0;
            double c = 0;

            double a_angle = 0;
            double b_angle = 0;
            double c_angle = 90;

            bool succes1 = false;
            bool succes2 = false;

            var colorYellow = ConsoleColor.Yellow;
            Console.ForegroundColor = colorYellow;

            Console.WriteLine($"{greeting}");
            Console.ResetColor();
            Console.WriteLine();

            bool wrongCurrentValue = true;

            while (wrongCurrentValue)
            {
                Console.WriteLine($"{enterNumber}");
                Console.WriteLine();

                for (int i = 0; i < 2; i++)
                {
                    Console.Write($"{counter[i]}");
                    number[i] = Console.ReadLine();
                    Console.WriteLine();
                }

                succes1 = double.TryParse(number[0], out a);
                succes2 = double.TryParse(number[1], out b);

                if (succes1 && succes2)
                {
                    wrongCurrentValue = false;
                    c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

                    a_angle = Math.Tan(a / b) * 180/Math.PI;
                    b_angle = 180 - c_angle - a_angle;

                    var colorGreen = ConsoleColor.Green;
                    Console.ForegroundColor = colorGreen;

                    Console.WriteLine($"Hypotenuse length equal: ({c})");
                    
                    Console.WriteLine();

                    Console.WriteLine($"Triangle angles equels: a = ({a_angle}), b = ({b_angle}), c = ({c_angle}) ");
                    
                    Console.WriteLine();

                    var colorBlue = ConsoleColor.Blue;
                    Console.ForegroundColor = colorBlue;
                    
                    Console.WriteLine("Thank you for using our application");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to exit application");
                    Console.ReadKey();
                }

                else
                {
                    var colorRed = ConsoleColor.Red;
                    Console.ForegroundColor = colorRed;

                    Console.WriteLine("Sorry, not correct value try again");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            string name = program.EnteredName();

            program.WelcomeGreetings(name);
        }
    }
}
