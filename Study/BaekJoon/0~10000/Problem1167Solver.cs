using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1167
    // 트리의 지름

    using edge = System.ValueTuple<int, int>;

    internal class Problem1167Solver
    {
        static List<List<edge>> A = new List<List<edge>>();
        static bool[] visited;
        static int[] distance;

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N + 1; i++)
                A.Add(new List<edge>());

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int s = int.Parse(inputs[0]);

                for (int j = 1; j < inputs.Length - 1; j+=2)
                {
                    int e, v;
                    e = int.Parse(inputs[j]);

                    if (e == -1)
                        break;

                    v = int.Parse(inputs[j+1]);
                    A[s].Add(new edge(e, v));
                }
            }

            visited = new bool[N + 1];
            distance = new int[N + 1];

            BFS(1);

            int max = 1;

            for (int i = 2; i <= N; i++)
            {
                if (distance[max] < distance[i])
                    max = i;
            }

            distance = new int[N + 1];
            visited = new bool[N + 1];

            BFS(max);

            Array.Sort(distance);

            Console.Write(distance[N]);
            
        }

        static public void BFS(int node)
        {
            Queue<int> m_queue = new Queue<int>();
            m_queue.Enqueue(node);
            visited[node] = true;

            while(m_queue.Count > 0)
            {
                int nw = m_queue.Dequeue();

                foreach (var i in A[nw])
                {
                    if (!visited[i.Item1])
                    {
                        visited[i.Item1] = true;
                        m_queue.Enqueue(i.Item1);
                        distance[i.Item1] = distance[nw] + i.Item2;
                    }
                }
            }
        }
    }
}
