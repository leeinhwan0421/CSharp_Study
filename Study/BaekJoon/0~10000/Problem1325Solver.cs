using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1325
    // 효율적인 해킹

    internal class Problem1325Solver
    {
        static bool[] visited;
        static List<int>[] A;
        static int[] result;

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            long n = long.Parse(inputs[0]);
            long m = long.Parse(inputs[1]);

            A = new List<int>[n + 1];
            visited = new bool[n + 1];
            result = new int[n + 1];

            for (int i = 0; i < A.Length; i++)
                A[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);

                A[s].Add(e);
            }

            for (int i = 0; i <= n; i++)
            {
                visited = new bool[n + 1];
                BFS(i);
            }

            int max = 0;

            for (int i = 1; i <= n; i++)
            {
                max = Math.Max(max, result[i]);
            }

            for (int i = 1; i <= n; i++)
            {
                if (result[i] == max)
                    Console.Write($"{i} ");
            }

            
        }

        static private void BFS(int node)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;

            while(queue.Count > 0 )
            {
                int nw = queue.Dequeue();
                foreach (var it in A[nw])
                {
                    if (visited[it] == false)
                    {
                        visited[it] = true;
                        result[it]++;
                        queue.Enqueue(it);
                    }
                }
            }
        }
    }
}
