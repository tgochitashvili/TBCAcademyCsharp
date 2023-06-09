using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assignment4
{
    public class A4Task5
    {
        static void Main(string[] args)
        {
            for(; ;)
            {
                try
                {
                    int x, y;
                    for (; ; )
                    {
                        try
                        {
                            Console.WriteLine("Enter x:");
                            x = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {

                        }
                    }

                    for (; ; )
                    {
                        try
                        {
                            Console.WriteLine("Enter y:");
                            y = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {

                        }
                    }
                    Console.WriteLine("Random array: ");
                    int[,] mat = GetRandom2DArrayOfSize(x, y);
                    Console.WriteLine("A \n\n= \n\n" + Format2DArray(mat));
                    Console.WriteLine("Det(A) = " + Det(mat));

                }
                catch (NotImplementedException)
                {
                    Console.WriteLine("Only 2x2 and 3x3 matrices are supported");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            

        }

        public static double Det(int[,] mat)
        {
            if(mat.GetLength(0) == 2 && mat.GetLength(1) == 2)
            {
                return Det2By2(mat);
            }
            else if(mat.GetLength(0) == 3 && mat.GetLength(1) == 3)
            {
                int det = 0;
                for(int i = 0; i < mat.GetLength(0); i++)
                {
                    int a = mat[0, i];
                    int[,] subMat = new int[2, 2];
                    for(int i0 = 0; i0 < subMat.GetLength(1); i0++)
                    {
                        for(int j0 = 0; j0 < subMat.GetLength(0); j0++)
                        {
                            if (i == 0)
                            {
                                subMat[i0,j0] = mat[i0+1, j0+1];
                            }
                            else if(i == 1)
                            {
                                if (j0 == 0)
                                {
                                    subMat[i0, j0] = mat[i0 + 1, j0];
                                }
                                else if(j0 == 1)
                                {
                                    subMat[i0, j0] = mat[i0 + 1, j0 + 1];
                                }
                            }
                            else
                            {
                                subMat[i0, j0] = mat[i0 + 1, j0];
                            }
                        }
                    }
                    det += (int)Math.Pow(-1, i) * a * Det2By2(subMat);
                }
                return det;
            }
            //მეზარება
            throw new NotImplementedException(); 
        }

        public static int Det2By2(int[,] mat)
        {
            int det = mat[0,0] * mat[1,1] - mat[0,1] * mat[1,0];
            return det;
        }

        public static int[,] GetRandom2DArrayOfSize(int x, int y, int seed = 0)
        {
            Random random;
            if(seed == 0)
            {
                random = new Random();
            }
            else
            {
                random = new Random(seed);
            }
            int[,] mat = new int[x, y];

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = random.Next(10, 99);
                }
            }
            return mat;
        }

        public static string Format2DArray(int[,] arr)
        {
            StringBuilder outputBuilder = new StringBuilder();

            for(int i = 0; i < arr.GetLength(0); i++)
            {
                outputBuilder.Append("[");
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    outputBuilder.Append(arr[i, j].ToString());
                    if(j < arr.GetLength(1) - 1)
                        outputBuilder.Append(",");
                }
                outputBuilder.Append("]\n");
            }

            return outputBuilder.ToString();
        }
    }
}