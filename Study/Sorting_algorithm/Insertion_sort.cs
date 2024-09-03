using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Sorting_algorithm
{
    internal class Insertion_sort
    {
        static public void Sort()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Insertion(arr);

            foreach (int it in arr)
            {
                Console.WriteLine(it);
            }

            Console.ReadLine();
        }

        static private void Insertion(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int insert_point = i;
                int insert_val = arr[insert_point];

                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] < arr[i])
                    {
                        insert_point = j + 1;
                        break;
                    }
                    if (j == 0)
                    {
                        insert_point = 0;
                    }
                }

                for (int j = i; j > insert_point; j--)
                {
                    arr[j] = arr[j - 1];
                }

                arr[insert_point] = insert_val;
            }
        }
    }
}
