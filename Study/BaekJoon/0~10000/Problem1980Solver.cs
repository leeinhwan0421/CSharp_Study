using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1980
    // 주몽

    internal class Problem1980Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            string[] inputs = Console.ReadLine().Split(' ');

            int[] arr = new int[n];
            for (int i = 0; i < inputs.Length; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            Array.Sort(arr);

            int startIndex = 0;
            int endIndex = arr.Length - 1;
            int result = 0;

            while (endIndex != startIndex)
            {
                int sum = arr[startIndex] + arr[endIndex];

                if (sum == m)
                {
                    result++;
                    startIndex++;
                }
                else if (sum > m)
                {
                    endIndex--;
                }
                else
                {
                    startIndex++;
                }
            }

            Console.Write(result);
            Console.ReadLine();
        }
    }
}
