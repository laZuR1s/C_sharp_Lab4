using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace С_sharp_Lab4
{
    internal class Program
    {
        static void fill_zero_row(int size, int[] row)
        {

            for (int i = 0; i < size; i++)
                row[i] = 0;
        }
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
        static int[] task(int size, int[,] arr)
        {
            int[] row = new int[size];
            fill_zero_row(size, row);
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (arr[i, j] > 0)
                    {
                        count++;
                    }
                    else
                    {
                        if (row[i] < count)
                            row[i] = count;
                        count = 0;
                    }
                }
                if (row[i] < count)
                    row[i] = count;
                count = 0;
            }


            return row;
        }

        static void Main(string[] args)
        {

            Console.Write("Введите размер n матрицы nxn: ");

            int n;
            int.TryParse(Console.ReadLine(), out n);

            int[] row = new int[n];
            int[,] arr = new int[n, n];

            fill_matrix(n, arr);

            Console.WriteLine("\nПроизвольно заданная матрица: ");
            print_matrix(n, arr);

            row = task(n, arr);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Серия положительных в " + (i+1) + " строке: " + row[i]);
            }
        }
    }
}
