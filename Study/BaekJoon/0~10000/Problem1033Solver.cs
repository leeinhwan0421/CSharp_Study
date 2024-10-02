using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1033
    // 칵테일

    using Item = System.ValueTuple<int, int, int>;

    internal class Problem1033Solver
    {
        static List<Item>[] A = new List<Item>[10];
        static long[] D = new long[10];
        static bool[] visited = new bool[10]; 

        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            long LCM = 1;

            for (int i = 0; i < A.Length; i++)
                A[i] = new List<Item>();

            for (int i = 0; i < n - 1; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                int a, b, p, q;

                a = int.Parse(inputs[0]);
                b = int.Parse(inputs[1]);
                p = int.Parse(inputs[2]);
                q = int.Parse(inputs[3]);

                A[a].Add((b, p, q));
                A[b].Add((a, q, p));

                LCM *= p * q / GCD(p, q);
            }

            D[0] = LCM;
            DFS(0);
            long mgcd = D[0];

            for (int i = 1; i < n; i++)
            {
                mgcd = GCD(mgcd, D[i]);
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{D[i] / mgcd} ");
            }

            
        }

        static public long GCD(long a, long b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }

        static public void DFS(int node)
        {
            visited[node] = true;

            foreach(var it in A[node])
            {
                int nxt = it.Item1;
                if (!visited[nxt])
                {
                    D[nxt] = D[node] * it.Item3 / it.Item2;
                    DFS(nxt);
                }
            }
        }
    }
}
