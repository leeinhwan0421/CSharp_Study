using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2470
    // 두 용액

    internal class Problem2470Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            Array.Sort(arr);

            int startIndex = 0;
            int endIndex = n - 1;

            int min = arr[startIndex];
            int max = arr[endIndex];
            int diff = Math.Abs(arr[startIndex] + arr[endIndex]); 

            while (startIndex != endIndex)
            {
                int n_diff = arr[startIndex] + arr[endIndex];

                if (Math.Abs(n_diff) < diff)
                {
                    diff = Math.Abs(n_diff);
                    min = arr[startIndex];
                    max = arr[endIndex];

                    if (n_diff == 0)
                    {
                        break;
                    }
                }

                if (n_diff < 0)
                {
                    startIndex++;
                }
                else
                {
                    endIndex--;
                }
            }

            Console.Write($"{min} {max}");
            Console.ReadLine();
        }
    }
}
