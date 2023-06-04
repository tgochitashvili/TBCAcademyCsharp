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
        public static void Main(String[] args)
        {
            Run();
        }

        enum ChineseZodiac
        {
            Rat = 1,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Goat,
            Monkey,
            Rooster,
            Dog,
            Pig
        }
        public static void Run()
        {
            ChineseLunisolarCalendar chLuniCal = new ChineseLunisolarCalendar();
            for(; ;)
            {
                try
                {
                    Console.WriteLine("Enter your birth year:");
                    string yearStr = Console.ReadLine();
                    int year = Convert.ToInt32(yearStr);

                    DateTime dateTime = chLuniCal.ToDateTime(year, 1, 1, 0, 0, 0, 0); //ჩინურ ახალ წელს რომ დაემთხვეს, 
                    int sexagenaryYear = chLuniCal.GetSexagenaryYear(dateTime);
                    int terrestrialBranch = chLuniCal.GetTerrestrialBranch(sexagenaryYear);

                    Console.WriteLine("You were born in the year of the " + ((ChineseZodiac) terrestrialBranch).ToString());
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Only years between 1901 and 2100 are supported.");
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
