using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2473
    // 세 용액

    internal class Problem2473Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            long[] arr = Console.ReadLine().Split().Select(long.Parse).ToArray();

            Array.Sort(arr);

            long bestSum = long.MaxValue;
            long[] result = new long[3];

            for (int i = 0; i < N - 2; i++)
            {
                int left = i + 1;
                int right = N - 1;

                while (left < right)
                {
                    long sum = arr[i] + arr[left] + arr[right];

                    if (Math.Abs(sum) < Math.Abs(bestSum))
                    {
                        bestSum = sum;
                        result[0] = arr[i];
                        result[1] = arr[left];
                        result[2] = arr[right];
                    }

                    if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            Array.Sort(result);
            Console.Write($"{result[0]} {result[1]} {result[2]}");
            
        }
    }
}
