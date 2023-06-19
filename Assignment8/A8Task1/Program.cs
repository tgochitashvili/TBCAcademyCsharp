using System.Runtime.CompilerServices;

namespace A8Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
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
            public static double Sqrt(double num, double error = 1e-15, int minIter = 10)
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
                } while (guess - lastGuess > error || i < minIter);

                return guess;
            }

        }
    }
}