using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    internal class Radix_sort
    {
        static public void Sort()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Radix(arr);

            foreach (int it in arr)
            {
                Console.WriteLine(it);
            }

            Console.ReadLine();
        }

        static private void Radix(int[] arr)
        {
            int max = arr.Max();

            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(arr, exp);
            }
        }

        static private void CountingSort(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
            {
                int digit = (arr[i] / exp) % 10;
                count[digit]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int digit = (arr[i] / exp) % 10;
                output[count[digit] - 1] = arr[i];
                count[digit]--;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }
    }
}