namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(; ; )
            {
                try
                {
                    Console.WriteLine("Enter number of elements in each array");
                    Console.WriteLine("Array 1:");
                    int arr0Length = Convert.ToInt32 (Console.ReadLine());
                    decimal[] arr0 = new decimal[arr0Length];
                    Console.WriteLine("Array 2:");
                    int arr1Length = Convert.ToInt32 (Console.ReadLine());
                    decimal[] arr1 = new decimal[arr1Length];
                    Console.WriteLine("Enter the elements for the first array (one per line)");
                    for(int i = 0; i < arr0.Length ; i++ )
                    {
                        try
                        {
                            arr0[i] = Convert.ToDecimal(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Enter a valid number");
                            i--;
                        }
                    }

                    Console.WriteLine("Enter the elements for the second array (one per line)");
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        try
                        {
                            arr1[i] = Convert.ToDecimal(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Enter a valid number");
                            i--;
                        }
                    }
                    bool asc = true;
                    for (; ; )
                    {
                        try
                        {
                            Console.WriteLine("asc or desc?");
                            string answer = Console.ReadLine().ToLower();
                            asc = answer == "asc" ? true : (answer == "desc" ? false : throw new Exception());
                            break;
                        }
                        catch
                        {

                        }
                    }
                    decimal[] mergedArray = arr0.Concat(arr1).ToArray();
                    Console.WriteLine("Unsorted: " + A4Task1.FormatArray(mergedArray));
                    A4Task1.BubbleSort(mergedArray, asc);
                    Console.WriteLine("Sorted: " + A4Task1.FormatArray(mergedArray));


                }
                catch
                {

                }
            }
        }
    }
}