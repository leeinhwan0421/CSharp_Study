using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11437
    // LCA

    internal class Problem11437Solver
    {
        static string[] inputs;

        static List<List<int>> tree = new List<List<int>>();
        static int[] depth = new int[0];
        static int[] parent = new int[0];
        static bool[] visited = new bool[0];

        static public void BFS(int x)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(x);
            visited[x] = true;

            int level = 1;
            int now_size = 1;
            int count = 0;

            while (q.Count != 0)
            {
                int cur = q.Dequeue();

                foreach (int it in tree[cur])
                {
                    if (visited[it] == false)
                    {
                        q.Enqueue(it);
                        visited[it] = true;
                        parent[it] = cur;
                        depth[it] = level;
                    }
                }

                count++;
                if (count == now_size)
                {
                    count = 0;
                    now_size = q.Count;
                    level++;
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

            while(depth[a] != depth[b])
            {
                a = parent[a];
            }

            while(a != b)
            {
                a = parent[a];
                b = parent[b];
            }

            return a;
        }

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            depth = new int[N + 1];
            parent = new int[N + 1];
            visited = new bool[N + 1];

            for (int i = 0; i <= N; i++)
                tree.Add(new List<int>());

            for (int i = 0; i < N - 1; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);

                tree[s].Add(e);
                tree[e].Add(s);
            }

            BFS(1);

            int M = int.Parse(Console.ReadLine());
        
            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);

                Console.Write($"{LCA(s, e)}\n");
            }

            Console.ReadKey();
        }
    }
}
