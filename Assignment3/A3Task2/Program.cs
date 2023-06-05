namespace TBCAcademyCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                try
                {
                    Console.WriteLine("Enter a number");
                    string inputStr = Console.ReadLine();
                    int inputInt = Convert.ToInt32(inputStr);

                    Console.WriteLine("There are " + Divisors(inputInt) + " divisors for " + inputInt);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("There are infinite divisors for 0");
                }

                catch
                {

                }
            }
        }

        static int Divisors(int num)
        {
            int sum = 1;

            if (num == 0)
                throw new DivideByZeroException();

            if ((num <= 1 && num >= -1) || A3Task1.IsPrime(num))
            {
                return sum;
            }
            else
            {
                for(int i = 2; i <= num / 2.0; i++)
                {
                    sum += num % i == 0 ? 1 : 0;
                }
                sum += 1;
            }



            return sum;
            
        }
    }
}