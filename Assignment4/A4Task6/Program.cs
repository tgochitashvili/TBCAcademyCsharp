namespace Assignment4
{
    internal class A4Task6
    {
        static void Main(string[] args)
        {
            for(; ; )
            {
                try
                {
                    int x, y;
                    int[,] arr0, arr1;
                    for(; ; )
                    {
                        try
                        {
                            Console.WriteLine("Enter x for the first array: ");
                            x = Convert.ToInt32 (Console.ReadLine());
                            Console.WriteLine("Enter y for the first array: ");
                            y = Convert.ToInt32 (Console.ReadLine());   
                            arr0 = A4Task5.GetRandom2DArrayOfSize(y, x);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Enter valid integers");
                        }
                    }
                    for (; ; )
                    {
                        try
                        {
                            Console.WriteLine("Enter x for the second array: ");
                            x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter y for the second array: ");
                            y = Convert.ToInt32(Console.ReadLine());
                            arr1 = A4Task5.GetRandom2DArrayOfSize(y, x);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Enter valid integers");
                        }
                    }
                    Console.WriteLine("Random arrays: ");
                    Console.WriteLine("A \n= \n" + A4Task5.Format2DArray(arr0));
                    Console.WriteLine("B \n= \n" + A4Task5.Format2DArray(arr1));

                    if(arr0.GetLength(1) != arr1.GetLength(0))
                    {
                        Console.WriteLine("Mismatched dimensions");
                        throw new Exception();
                    }
                    Console.WriteLine("A x B \n= \n" + A4Task5.Format2DArray(Multiply(arr0, arr1)));

                }

                catch
                {

                }
            }

        }
        static int[,] Multiply(int[,] arr0, int[,] arr1)
        {
            if (arr0.GetLength(1) != arr1.GetLength(0))
                throw new InvalidOperationException();
            int[,] output = new int[arr0.GetLength(0), arr1.GetLength(1)];
            for(int i = 0; i < arr0.GetLength(0); i++)
            {
                for(int j = 0;  j < arr1.GetLength(1); j++)
                {
                    for(int k = 0; k < arr0.GetLength(1); k++)
                    {
                        output[i, j] += arr0[i, k] * arr1[k, j];
                    }
                }
            }
            return output;
        }


    }
}