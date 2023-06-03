using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCAcademyCsharp.Assignment_02
{
    internal class Task04
    {
        public static void Run()
        {
            //could be done with ChineseLunisolarCalendar
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your birth year:");
                    string yearStr = Console.ReadLine();
                    int year = Convert.ToInt32(yearStr);
                    Console.WriteLine("You were born in the year of the " + GetAnimal(year));
                }
                catch
                {
                    continue;
                }
            }
        }

        public static string GetAnimal(int year)
        {
            switch ((year-4) % 12) //won't work under 5 AD
                
                
            {
                //can be replaced with a dictionary 
                case 0:
                    return "Rat";
                case 1:
                    return "Ox";
                case 2:
                    return "Tiger";
                case 3:
                    return "Rabbit";
                case 4:
                    return "Dragon";
                case 5:
                    return "Snake";
                case 6:
                    return "Horse";
                case 7:
                    return "Goat";
                case 8:
                    return "Monkey";
                case 9:
                    return "Rooster";
                case 10:
                    return "Dog";
                default: //11
                    return "Pig";
            }
        }
    }
}
