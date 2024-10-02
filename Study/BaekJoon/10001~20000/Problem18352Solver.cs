using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/18352
    // 특정 거리의 도시 찾기

    internal class Problem18352Solver
    {
        static List<List<int>> A = new List<List<int>>();
        static List<int> ans = new List<int>();
        static int[] visited;

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            long n = long.Parse(inputs[0]);
            long m = long.Parse(inputs[1]);
            long k = long.Parse(inputs[2]);
            long x = long.Parse(inputs[3]);

            for (int i = 0; i <= n; i++)
                A.Add(new List<int>());

            visited = new int[n + 1];

            for (int i = 0; i < m; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);

                A[s].Add(e);
            }

            for (int i = 0; i <= n; i++)
            {
                visited[i] = -1;
            }

            BFS((int)x);

            for (int i = 0; i <= n; i++)
            {
                if (visited[i] == k)
                {
                    ans.Add(i);
                }
            }

            if (ans.Count == 0)
            {
                Console.Write("-1");
            }
            else
            {
                ans.Sort();
                foreach(var tmp in ans)
                {
                    Console.Write($"{tmp}\n");
                }
            }

            
        }

        static public void BFS(int node)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node]++;

            while(queue.Count != 0)
            {
                int nw = queue.Dequeue();

                foreach(var i in A[nw])
                {
                    if (visited[i] == -1)
                    {
                        visited[i] = visited[nw] + 1;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
