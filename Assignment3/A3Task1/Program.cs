namespace TBCAcademyCsharp
{
    public class A3Task1
    {
        static void Main(string[] args)
        {
            
            for(; ; )
            {
                try
                {
                    Console.WriteLine("Enter an integer:");
                    string inputStr = Console.ReadLine();
                    int inputInt = Convert.ToInt32(inputStr);
                    Console.WriteLine(IsPrime(inputInt)?"Prime":"Not prime");
                }
                catch
                {
                    continue;
                }
            }
        }

        public static bool IsPrime(int num)
        {
            for(int i = 2; i <= num/2.0; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return num > 1 || num < -1;
        }
    }
}