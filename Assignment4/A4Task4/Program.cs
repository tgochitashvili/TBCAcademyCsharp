using Assignment4;
using System.ComponentModel.DataAnnotations;

namespace A4Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrSize = 0;
            for (; ; )
            {
                try
                {
                    Console.WriteLine("Enter size");
                    arrSize = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch { }
            }
            int[] arr = new int[arrSize];
            Console.WriteLine("Enter some numbers (one per line)");
            for(int i = 0; i < arrSize; i++) 
            {
                try
                {
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Enter a valid number");
                    i--;
                }
            }
            Console.WriteLine(A4Task1.FormatArray(GetLongestAscSequence(arr)));
        }

        static int[] GetLongestAscSequence(int[] arr)
        {
            int startIndex = 0;
            int length = 1;
            int[] largestSequence = new int[] { arr[0] };

            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i] > arr[i - 1])
                {
                    length++;
                }
                else
                {
                    if(length > largestSequence.Length)
                    {
                        largestSequence = new int[length];
                        Array.Copy(arr, startIndex, largestSequence, 0, length);
                        startIndex = i;
                        length = 1;
                    }
                }
            }
            if(length > largestSequence.Length)
            {
                largestSequence = new int[length];
                        Array.Copy(arr, startIndex, largestSequence, 0, length);
            }
            return largestSequence;
        }
    }
}