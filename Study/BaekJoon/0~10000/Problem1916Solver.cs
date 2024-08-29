using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Item = System.ValueTuple<int, int>;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1916
    // 최소비용 구하기

    /// <summary>
    /// 다익스트라 알고리즘 사용합니다.
    /// </summary>

    internal class Problem1916Solver
    {
        static string[] inputs;

        static int N; 
        static int M;

        static int[] dist;
        static bool[] visited;
        static List<List<Item>> list = new List<List<Item>>();

        static public void Solve()
        {
            N = int.Parse(Console.ReadLine());
            M = int.Parse(Console.ReadLine());

            dist = new int[N + 1];
            visited = new bool[N + 1];

            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = int.MaxValue;
                list.Add(new List<Item>());
            }

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int start   = int.Parse(inputs[0]);
                int end     = int.Parse(inputs[1]);
                int weight  = int.Parse(inputs[2]);

                list[start].Add((end, weight));
            }

            inputs = Console.ReadLine().Split(' ');

            int start_idx   = int.Parse(inputs[0]);
            int end_idx     = int.Parse(inputs[1]);

            int result = Dijkstra(start_idx, end_idx);

            Console.Write(result);
            Console.ReadKey();
        }

        static public int Dijkstra(int start, int end)
        {
            var priorityQueue = new SortedSet<(int, int)>();
            priorityQueue.Add((0, start));
            dist[start] = 0;

            while (priorityQueue.Count > 0)
            {
                var current = priorityQueue.Min;
                priorityQueue.Remove(current);
                int currentCost = current.Item1;
                int currentNode = current.Item2;

                if (visited[currentNode])
                    continue;

                visited[currentNode] = true;

                foreach (var neighbor in list[currentNode])
                {
                    int nextNode = neighbor.Item1;
                    int weight = neighbor.Item2;

                    if (dist[nextNode] > currentCost + weight)
                    {
                        dist[nextNode] = currentCost + weight;
                        priorityQueue.Add((dist[nextNode], nextNode));
                    }
                }
            }

            return dist[end];
        }
    }
}
