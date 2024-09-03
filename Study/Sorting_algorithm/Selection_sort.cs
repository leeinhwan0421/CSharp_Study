using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    internal class Selection_sort
    {
        static public void Sort()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Selection(arr);

            foreach (int it in arr)
            {
                Console.WriteLine(it);
            }

            Console.ReadLine();
        }

        static private void Selection(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (arr[i] > arr[min])
                {
                    int tmp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = tmp;
                }
            }
        }
    }
}