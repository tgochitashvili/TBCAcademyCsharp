using System.Text;

namespace A3Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(; ; )
            {
                try
                {
                    Console.WriteLine("Enter a number");
                    string inputStr = Console.ReadLine();
                    int inputInt = Convert.ToInt32(inputStr);
                    Console.WriteLine(Stars(inputInt));
                }
                catch
                {
                }
            }
        }


        static string Stars(int num)
        {
            if(num <= 0)
            {
                return "";
            }
            string output = "";
            for (int i = 1; i <= num; i++)
            {
                output += new StringBuilder().Insert(0, " ", (num-i+1)).ToString();
                output += new StringBuilder().Insert(0, "*", (i*2)-1).ToString() + "\n";
            }
            return output;
        }
    }
}