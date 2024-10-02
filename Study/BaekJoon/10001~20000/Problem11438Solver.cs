using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11438
    // LCA 2

    internal class Problem11438Solver
    {
        static string[] inputs;
        static List<List<int>> tree = new List<List<int>>();
        static int[] depth;
        static int[,] parent;
        static int kmax;
        static bool[] visited;

        static public void BFS(int x)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(x);
            visited[x] = true;
            depth[x] = 0;

            while (q.Count != 0)
            {
                int cur = q.Dequeue();

                foreach (int it in tree[cur])
                {
                    if (!visited[it])
                    {
                        q.Enqueue(it);
                        visited[it] = true;
                        parent[0, it] = cur;
                        depth[it] = depth[cur] + 1;
                    }
                }
            }
        }

        static public int LCA(int a, int b)
        {
            if (depth[a] < depth[b])
            {
                int temp = a;
                a = b;
                b = temp;
            }

            for (int k = kmax; k >= 0; k--)
            {
                if ((depth[a] - depth[b]) >= (1 << k))
                {
                    a = parent[k, a];
                }
            }

            if (a == b)
                return a;

            for (int k = kmax; k >= 0; k--)
            {
                if (parent[k, a] != parent[k, b])
                {
                    a = parent[k, a];
                    b = parent[k, b];
                }
            }

            return parent[0, a];
        }

        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());

            depth = new int[N + 1];
            visited = new bool[N + 1];
            int temp = 1;
            kmax = 0;

            while (temp <= N)
            {
                temp <<= 1;
                kmax++;
            }

            parent = new int[kmax + 1, N + 1];

            for (int i = 0; i <= N; i++)
                tree.Add(new List<int>());

            for (int i = 0; i < N - 1; i++)
            {
                inputs = sr.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);

                tree[s].Add(e);
                tree[e].Add(s);
            }

            BFS(1);

            for (int k = 1; k <= kmax; k++)
            {
                for (int n = 1; n <= N; n++)
                {
                    if (parent[k - 1, n] != -1)
                    {
                        parent[k, n] = parent[k - 1, parent[k - 1, n]];
                    }
                }
            }

            int M = int.Parse(sr.ReadLine());

            for (int i = 0; i < M; i++)
            {
                inputs = sr.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);

                sw.Write($"{LCA(s, e)}\n");
            }

            sw.Flush();

            
        }
    }
}
