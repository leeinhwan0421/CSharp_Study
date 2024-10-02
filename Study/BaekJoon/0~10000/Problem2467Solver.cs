using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2467
    // 용액

    internal class Problem2467Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');

            long[] arr = new long[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            int left = 0;
            int right = N - 1;

            long res = Math.Abs(arr[left] + arr[right]);
            long res1 = arr[left];
            long res2 = arr[right];

            while (left < right)
            {
                long tempRes = Math.Abs(arr[left] + arr[right]);
                long dir = arr[left] + arr[right];

                if (tempRes < res)
                {
                    res = tempRes;
                    res1 = arr[left];
                    res2 = arr[right];
                }

                if (dir < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            Console.Write($"{res1} {res2}");
            
        }
    }
}
