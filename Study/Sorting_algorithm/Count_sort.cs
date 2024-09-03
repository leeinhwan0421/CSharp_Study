using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    internal class Count_sort
    {
        static public void Sort()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Count(arr);

            Console.ReadLine();
        }

        static private void Count(int[] arr)
        {
            int[] count = new int[arr.Max() + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i]]++;
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] != 0)
                {
                    Console.Write($"{i}\n");
                }
            }
        }
    }
}
