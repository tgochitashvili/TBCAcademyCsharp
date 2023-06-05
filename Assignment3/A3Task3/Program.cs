namespace A3Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            double avg = 0;
            int count = 0;
            for(; ; )
            {
                try
                {
                    Console.WriteLine("Sum: " + sum + "\nAverage: " + avg + "\nCount: " + count);
                    Console.WriteLine("Enter a number");
                    string inputStr = Console.ReadLine();
                    int inputInt = Convert.ToInt32(inputStr);
                    if (inputInt > 0)
                    {
                        sum += inputInt;
                        count++;
                        avg = sum / (double) count;
                    }
                }
                catch
                {

                }
                finally
                {
                    Console.Clear();
                }
            }
        }
    }
}