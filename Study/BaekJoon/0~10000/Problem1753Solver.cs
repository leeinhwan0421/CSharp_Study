using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    internal class Problem1753Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int V = int.Parse(inputs[0]);
            int E = int.Parse(inputs[1]);

            int K = int.Parse(Console.ReadLine());

            List<List<(int, int)>> adjList = new List<List<(int, int)>>(V + 1);
            for (int i = 0; i <= V; i++)
            {
                adjList.Add(new List<(int, int)>());
            }

            for (int i = 0; i < E; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int u = int.Parse(inputs[0]);
                int v = int.Parse(inputs[1]);
                int w = int.Parse(inputs[2]);

                adjList[u].Add((v, w));
            }

            int[] distance = new int[V + 1];
            for (int i = 0; i <= V; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[K] = 0;

            SortedSet<(int, int)> pq = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) =>
            {
                if (a.Item1 == b.Item1) return a.Item2.CompareTo(b.Item2);
                return a.Item1.CompareTo(b.Item1);
            }));

            pq.Add((0, K));

            while (pq.Count > 0)
            {
                var current = pq.Min;
                pq.Remove(current);
                int distU = current.Item1;
                int u = current.Item2;

                if (distU > distance[u]) continue;

                foreach (var neighbor in adjList[u])
                {
                    int v = neighbor.Item1;
                    int weight = neighbor.Item2;

                    if (distance[u] + weight < distance[v])
                    {
                        if (distance[v] != int.MaxValue)
                        {
                            pq.Remove((distance[v], v));
                        }

                        distance[v] = distance[u] + weight;
                        pq.Add((distance[v], v));
                    }
                }
            }

            // 결과 출력
            for (int i = 1; i <= V; i++)
            {
                if (distance[i] == int.MaxValue)
                    Console.WriteLine("INF");
                else
                    Console.WriteLine(distance[i]);
            }

            Console.ReadKey();
        }
    }
}
