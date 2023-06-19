using System.Runtime.CompilerServices;

namespace A8Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetIter = 100;
            double error = 1e-3;

            Console.WriteLine("Powers: ");
            for (int num = -100; num < targetIter; num+=20)
            {
                for(int power = -100; power < targetIter; power+=20)
                {
                    double calcAnswer = Calculator.Pow(num, power);
                    double mathAnswer = Math.Pow(num, power);
                    if (Calculator.Abs(calcAnswer - mathAnswer) > Calculator.Abs(mathAnswer * error))
                        Console.WriteLine($"When num: {num}, power: {power} => Calculator: {calcAnswer}, Math: {mathAnswer}");
                }
            }

            Console.WriteLine("Square roots:");
            for (int num = 0; num < targetIter; num+=10)
            {
                double calcAnswer = Calculator.Sqrt(num);
                double mathAnswer = Math.Sqrt(num);
                if (Calculator.Abs(calcAnswer - mathAnswer) > Calculator.Abs(mathAnswer * error))
                    Console.WriteLine($"When num: {num} => Calculator: {calcAnswer}, Math: {mathAnswer}");
            }
        }

        public static class Calculator
        {
            public static double Add(double a, double b)
            {
                return a + b;
            }

            public static double Subtract(double a, double b)
            {
                return a - b;
            }

            public static double Multiply(double a, double b)
            {
                return a * b;
            }
            public static double Divide(double a, double b)
            {
                return a / b;
            }
            public static double Pow(double num, int power)
            {
                double answer = 1;
                Func<double, double, double> operation =
                    power >= 0 ?
                        (a, b) =>
                            {
                                return a * b;
                            }
                        :
                        (a, b) =>
                            {
                                return a / b;
                            };

                power = power > 0 ? power : -power;

                for(int i = 0; i < power; i++)
                {
                    answer = operation(answer, num);
                }
                
                return answer;
            }
            public static double Sqrt(double num, double error = 1e-9, int minIter = 10, int maxIter = 1000)
            {
                if(num < 0)
                {
                    throw new Exception("Undefined");
                }
                else if(num == 0)
                {
                    return 0;
                }
                double guess = num/2;
                double lastGuess;
                int i = 0;
                do
                {
                    lastGuess = num / guess;
                    guess = (guess + lastGuess) / 2.0;
                    i++;
                } while ((guess - lastGuess > error || i < minIter) && i < maxIter);

                return guess;
            }
            public static double Abs(double num)
            {
                return num > 0 ? num : -num;
            }
        }
    }
}