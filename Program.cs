using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace С_sharp_Lab4
{
    internal class Program
    {

        static void fill_matrix(int size, int[,] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    arr[i, j] = rnd.Next(-10, 10);
        }
        static void print_matrix(int size, int[,] arr)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static int[] task(int i, int size, ref int[] arr, out int maxStartIndex, out int maxcount)
        {



            int currentStartIndex = -1;
            maxStartIndex = -1;
            int count = 0;
            maxcount = 0;
            bool flag = true;
            for (int j = 0; j < size; j++)
            {
                if (arr[j] > 0)
                {
                    count++;
                    if (flag)
                    {
                        currentStartIndex = j;
                        flag = false;
                    }
                }
                else
                {

                    if (count > maxcount)
                    {
                        maxcount = count;
                        maxStartIndex = currentStartIndex;
                    }

                    count = 0;
                    currentStartIndex = -1;
                    flag = true;
                }
            }

            if (count > maxcount)
            {
                maxcount = count;
                maxStartIndex = currentStartIndex;
            }

            int[] outRow = new int[size];

            if (maxcount > 0)
            {
                outRow = new int[maxcount];
                for (int k = 0; k < maxcount; k++)
                {
                    outRow[k] = arr[maxStartIndex + k];
                }
            }
            else
            {
                outRow = new int[0];
            }

            return outRow;
        }

        static int[] GetRow(int[,] matrix, int rowIndex)
        {
            int columns = matrix.GetLength(1);
            int[] row = new int[columns];

            for (int j = 0; j < columns; j++)
            {
                row[j] = matrix[rowIndex, j];
            }

            return row;
        }

        static void Main(string[] args)
        {

            Console.Write("Введите размер n матрицы nxn: ");

            int n;
            int.TryParse(Console.ReadLine(), out n);
            int[] row;
            int[] row1;
            int[][] matrix2 = new int[n][]; ;
            int[,] matrix = new int[n, n];

            fill_matrix(n, matrix);
            Console.WriteLine("\nПроизвольно заданная матрица: ");
            print_matrix(n, matrix);

            for (int i = 0; i < n; ++i)
            {
                int maxStartIndex;
                int maxcount;
                row = GetRow(matrix, i);

                row1 = task(i, n, ref row, out maxStartIndex, out maxcount);
                if (maxcount > 0)
                {
                    matrix2[i] = new int[maxcount];
                    for (int k = 0; k < maxcount; k++)
                    {
                        matrix2[i][k] = row1[k];
                    }
                }
                else
                {
                    matrix2[i] = new int[0];
                }

            }

            Console.WriteLine("\nМатрица с положительными последовательностями: ");
            for (int i = 0; i < matrix2.Length; i++)
            {
                if (matrix2[i].Length > 0)
                {
                    for (int j = 0; j < matrix2[i].Length; j++)
                    {
                        Console.Write(matrix2[i][j] + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                }

            }
        }

    }
}