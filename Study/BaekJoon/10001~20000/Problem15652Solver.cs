using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/15652
    // N과 M (4)

    internal class Problem15652Solver
    {
        static int[] arr;

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);

            arr = new int[m];

            DFS(n, m, 0, 1);

            
        }

        static void DFS(int n, int m, int depth, int at)
        {
            if (depth == m)
            {
                foreach (var val in arr)
                {
                    Console.Write($"{val} ");
                }

                Console.Write("\n");
                return;
            }
            for (int i = at; i <= n; i++)
            {
                arr[depth] = i;
                DFS(n, m, depth + 1, i);
            }

            return;
        }
    }
}
