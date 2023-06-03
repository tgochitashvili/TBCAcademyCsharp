using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCAcademyCsharp.Assignment_02
{
    public class Task02
    {
        public void Main(String[] args)
        {
            Run();
        }
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                try
                {
                    Console.WriteLine("გთხოვთ, შეიყვანოთ ტემპერატურა");
                    string input = Console.ReadLine();
                    int inpInt = Convert.ToInt32(input);

                    if (inpInt < 0)
                        Console.WriteLine("ყინავს");
                    else if (inpInt > 30)
                        Console.WriteLine("ცხელა");
                    else
                        Console.WriteLine("კარგი ამინდია");
                }
                catch
                {
                    Console.WriteLine("გთხოვთ, შეიყვანოთ მთელი რიცხვი");
                }
            }
        }
    }
}
