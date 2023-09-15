using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/18110
    // solved.ac

    internal class Problem18110Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int banned = (int)Math.Round(n * 0.15, MidpointRounding.AwayFromZero);

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());

            Array.Sort(arr);

            int sum = 0;
            for (int i = banned; i < arr.Length - banned; i++)
            {
                sum += arr[i];
            }

            double a = (double)sum / (n - (banned * 2));

            Console.Write(Math.Round(a, MidpointRounding.AwayFromZero));
            Console.ReadKey();
        }
    }
}
