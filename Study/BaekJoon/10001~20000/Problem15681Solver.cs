using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/15681
    // 트리와 쿼리

    internal class Problem15681Solver
    {
        static List<int>[] tree;
        static int[] subTree;
        static bool[] visited;

        static public int DFS(int n)
        {
            visited[n] = true;
            subTree[n] = 1;

            foreach (var it in tree[n])
            {
                if (!visited[it])
                {
                    subTree[n] += DFS(it);
                }
            }

            return subTree[n];
        }
        
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int R = int.Parse(inputs[1]);
            int Q = int.Parse(inputs[2]);

            tree = new List<int>[N + 1];
            subTree = new int[N + 1];
            visited = new bool[N + 1];

            for (int i = 1; i <= N; i++)
            {
                tree[i] = new List<int>();
            }

            for (int i = 0; i < N - 1; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int u = int.Parse(inputs[0]);
                int v = int.Parse(inputs[1]);

                tree[u].Add(v);
                tree[v].Add(u);
            }

            subTree[R] = DFS(R);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Q; i++)
            {
                int query = int.Parse(Console.ReadLine());
                sb.AppendLine($"{subTree[query]}");
            }

            Console.Write(sb.ToString());
            Console.ReadKey();
        }
    }
}
