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
                    int arr0Size;
                    for(; ; )
                    {
                        try
                        {
                            Console.WriteLine("Enter the size for the first array:");
                            arr0Size = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {

                        }
                    }
                    string[] arr0 = new string[arr0Size];
                    int arr1Size;

                    for (; ; )
                    {
                        try
                        {
                            Console.WriteLine("Enter the size for the second array:");
                            arr1Size = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {

                        }
                    }
                    int[] arr1 = new int[arr1Size];
                    Console.WriteLine("Fill in the first array:");
                    for (int i = 0; i < arr0Size; i++) 
                    {
                        arr0[i] = Console.ReadLine();
                    }
                    Console.WriteLine("Fill in the second array (one integer per line):");

                    for (int i = 0; i < arr1Size; i++)
                    {
                        try
                        {
                            arr1[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Enter a valid integer");
                            i--;
                        }
                    }

                    string[] combinedArray = new string[Math.Max(arr0.Length, arr1.Length)];

                    for(int i = 0; i < combinedArray.Length; i++)
                    {
                        try
                        {
                            combinedArray[i] += arr0[i];
                            combinedArray[i] += " ";
                        }
                        catch { }
                        try
                        {
                            combinedArray[i] += arr1[i];
                        }
                        catch { } 
                    }

                    Console.WriteLine(A4Task1.FormatArray(combinedArray));


                }
                catch
                {

                }
            }
        }
    }
}