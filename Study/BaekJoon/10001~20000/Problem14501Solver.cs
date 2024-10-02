using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/14501
    // 퇴사

    internal class Problem14501Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            int[] T = new int[N + 1];
            int[] P = new int[N + 1];
            int[] DP = new int[N + 1];

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                T[i] = int.Parse(inputs[0]);
                P[i] = int.Parse(inputs[1]);
            }

            int max = 0;

            for (int i = 0; i <= N; i++)
            {
                DP[i] = Math.Max(max, DP[i]);

                if (T[i] + i <= N)
                {
                    DP[T[i] + i] = Math.Max(DP[T[i] + i], P[i] + DP[i]);
                }

                max = Math.Max(max, DP[i]);
            }

            Console.Write(max);
            
        }
    }
}
