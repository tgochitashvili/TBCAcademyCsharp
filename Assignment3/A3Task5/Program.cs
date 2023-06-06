using System.Threading.Channels;

namespace A3Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool donePlaying = false;
            for(; !donePlaying ; )
            {
                Console.Clear();
                try
                {
                    int min = int.MinValue;
                    int max = int.MaxValue;
                    Console.WriteLine("Enter min");

                    for (; ;) //min prompt loop
                    {
                        try
                        {
                            string minStr = Console.ReadLine();
                            min = Convert.ToInt32(minStr);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Enter an integer!");
                            continue;
                        }
                    } 

                    for(; ;) //max prompt loop
                    {
                        try
                        {
                            string maxStr = Console.ReadLine();
                            max = Convert.ToInt32(maxStr);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Enter an integer!");
                            continue;
                        }
                    }
                    int randInt = random.Next(min, max);
                    bool isCorrect = false;
                    int numGuesses;
                    for(numGuesses = 0; !isCorrect ; numGuesses++ ) //guess loop
                    {
                        try
                        {
                            Console.WriteLine("Number of incorrect guesses: " + numGuesses);
                            Console.WriteLine("Enter your guess:");
                            string guessStr = Console.ReadLine();
                            int guessInt = Convert.ToInt32(guessStr);
                            if (guessInt == randInt)
                                isCorrect = true; //can also use an infinite loop with break;
                            Console.Clear();
                        }
                        catch
                        {
                            Console.Clear();
                            numGuesses--; // don't add a guess on incorrect input
                            Console.WriteLine("Enter an integer!");
                        }
                    }

                    Console.WriteLine("Number of guesses: " + numGuesses);
                    Console.WriteLine("The number was: " + randInt);

                    for(; ;) //continue prompt loop
                    {
                        Console.WriteLine("Try again? (yes/no)");
                        string answer = Console.ReadLine();
                        if (answer.ToLower() == "yes")
                            break;
                        else if (answer.ToLower() == "no")
                        {
                            donePlaying = true;
                            break;
                        }
                    }
                }
                catch
                {

                }
            }
        }
    }
}