using System.Text;

namespace Assignment4
{
    public class A4Task1
    {
        static void Main(string[] args)
        {
            for(; ; )
            {
                try
                {
                    Console.WriteLine("How many numbers do you want to enter?");
                    int numsCountInt = Convert.ToInt32(Console.ReadLine());
                    if(numsCountInt <= 0 )
                    {
                        throw new Exception();
                    }
                    Console.WriteLine("Enter your numbers, one per line");
                    decimal[] nums = new decimal[numsCountInt];

                    for (int i = 0; i < numsCountInt; i++)
                    {
                        try
                        {
                            nums[i] = Convert.ToDecimal(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Enter a valid number!");
                            i--;
                        }
                    }
                    BubbleSort(nums);

                    Console.WriteLine(FormatArray(nums));
                }
                catch
                {
                    Console.WriteLine("Enter a valid number!");
                }
            }
        }

        public static void BubbleSort(decimal[] arr, bool asc = true)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i + 1 < arr.Length)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            swapped = true;
                            (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                        }
                    }
                }
            } while (swapped);

            if (asc)
                return;
            Array.Reverse(arr);
        }

        public static string FormatArray(dynamic arr)
        {
            if (arr.Length == 0)
                return "";
            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.Insert(0, "[");
            foreach(dynamic d in arr)
            {
                outputBuilder.Append(d + ", ");
            }

            outputBuilder.Remove(outputBuilder.Length - 2, 2);
            outputBuilder.Append("]");

            return outputBuilder.ToString();
        }
    }
}