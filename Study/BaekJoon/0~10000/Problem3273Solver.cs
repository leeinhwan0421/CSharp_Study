using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/3273
    // 두 수의 합

    internal class Problem3273Solver
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

            int x = int.Parse(Console.ReadLine());
            int result = 0;
            int sum = 0;
            int startIndex = 0;
            int endIndex = n - 1;

            while(startIndex != endIndex)
            {
                sum = arr[startIndex] + arr[endIndex];

                if (sum == x)
                {
                    startIndex++;
                    result++;
                }
                else if (sum > x)
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
