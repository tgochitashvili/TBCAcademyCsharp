namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                char[] arr = new char[5]; // ლისტი ჯობია
                int currItem = 0;
                for (; ; )
                {
                    try
                    {
                        Console.WriteLine("Add a char to the list (q! to stop)");
                        string inp = Console.ReadLine();

                        if (inp.ToLower() == "q!")
                            break;
                        else
                        {
                            if (currItem >= arr.Length)
                                ResizeArray(ref arr);
                            arr[currItem] = Convert.ToChar(inp);
                            currItem++;
                        }
                    }
                    catch (Exception x)
                    {
                        Console.WriteLine("Enter a valid char or 'q!' to stop");
                    }
                }
                Console.WriteLine(A5Task1.FormatThing(arr));
                for (; ; )
                {
                    try
                    {
                        Console.WriteLine("Enter a char to search for");
                        char element = Convert.ToChar(Console.ReadLine());
                        int count = CountElements(arr, element);

                        Console.WriteLine($"The element {element} appears {count} times");
                    }
                    catch(Exception x)
                    {
                        Console.WriteLine("Enter a valid char");
                    }
                }
            }
        }

        static void ResizeArray(ref char[] arr, double rate = 1.5)
        {
            char[] tempArr = new char[Convert.ToInt32(arr.Length * rate)];
            arr.CopyTo(tempArr, 0);
            arr = tempArr;
        }
        static int CountElements(char[] arr, char element)
        {
            int count = default;
            foreach (char item in arr)
            {
                if (item == element)
                    count++;
            }
            return count;
        }
    }
}