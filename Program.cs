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
        static int[][] task(int size, ref int[,] arr)
        {
            int[][] row = new int[size][];

            for (int i = 0; i < size; i++)
            {
                int currentStartIndex = -1;
                int maxStartIndex = -1;
                int count = 0;
                int maxcount = 0;
                bool flag = true;

                for (int j = 0; j < size; j++)
                {
                    if (arr[i, j] > 0)
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


                if (maxcount > 0)
                {
                    row[i] = new int[maxcount];
                    for (int k = 0; k < maxcount; k++)
                    {
                        row[i][k] = arr[i, maxStartIndex + k];
                    }
                }
                else
                {
                    row[i] = new int[0];
                }


                flag = true;
                maxcount = 0;
                maxStartIndex = -1;
            }

            return row;
        }

        static void Main(string[] args)
        {

            Console.Write("Введите размер n матрицы nxn: ");

            int n;
            int.TryParse(Console.ReadLine(), out n);

            int[][] row = new int[n][];
            int[,] arr = new int[n, n];
            fill_matrix(n, arr);
            Console.WriteLine("\nПроизвольно заданная матрица: ");
            print_matrix(n, arr);

            row = task(n, ref arr);

            Console.WriteLine("\nМатрица с положительными последовательностями: ");
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i].Length > 0) 
                {
                    for (int j = 0; j < row[i].Length; j++)
                    {
                        Console.Write(row[i][j] + " ");
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