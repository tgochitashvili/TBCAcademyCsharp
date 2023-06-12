using System.Collections;
using System.Text;

namespace Assignment5
{
    public class A5Task1
    {
        static void Main(string[] args)
        {
            for(; ; )
            {
                int[] arr = new int[5]; // ლისტი ჯობია
                int currItem = 0;
                for(; ; )
                {
                    try
                    {
                        Console.WriteLine("Add an integer to the list (q to stop)");
                        string inp = Console.ReadLine();

                        if (inp.ToLower() == "q")
                            break;
                        else
                        {
                            if (currItem >= arr.Length)
                                ResizeArray(ref arr);
                            arr[currItem] = Convert.ToInt32(inp);
                            currItem++;
                        }
                    }
                    catch (Exception x) 
                    {
                        Console.WriteLine(x.Message);
                        Console.WriteLine(x.StackTrace);
                    }
                }
                Console.WriteLine("Array: " + FormatThing(arr));
                for(; ; )
                {
                    try
                    {
                        Console.WriteLine("Enter an index to sum an element's digits (q to stop)");
                        string inp = Console.ReadLine();
                        if (inp.ToLower() == "q")
                            break;
                        else
                        {
                            int element = arr[Convert.ToInt32(inp)];
                            Console.WriteLine($"Sum of {element}'s digits: {SumOfDigits(element)}");
                        }

                    }
                    catch { }
                }
            }

        }
        public static string FormatThing(dynamic arr)
        {
            if (arr.Length == 0)
                return "";
            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.Insert(0, "[");
            foreach (dynamic d in arr)
            {
                outputBuilder.Append(d + ", ");
            }

            outputBuilder.Remove(outputBuilder.Length - 2, 2);
            outputBuilder.Append("]");

            return outputBuilder.ToString();
        }
        public static void ResizeArray(ref int[] arr, double rate = 1.5)
        {
            int[] tempArr = new int[Convert.ToInt32(arr.Length * rate)];
            arr.CopyTo(tempArr, 0);
            arr = tempArr;
        }
        public static int SumOfDigits(int n)
        {
            int sum = 0;
            for(int i = 0; i < n.ToString().Length; i++)
            {
                sum += (n / (int)Math.Pow(10, i)) % 10;
            }
            return sum;
        }
    }
}