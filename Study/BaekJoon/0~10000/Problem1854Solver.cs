using System;
using System.Collections.Generic;

/*
    https://www.acmicpc.net/problem/1854
    K번째 최단 경로 찾기

    C#으로 다익스트라를 구현하는 것은 너무나도 힘들고 지치는 일입니다.... 저를 부디 구제해주세요...

    C++로 풀 예정입니다.
 */

namespace Problem_1854
{
    // 위 부분의 구현은 외부 소스코드에서 퍼왔습니다.

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data; // private to public

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1;
            while (ci > 0)
            {
                int pi = (ci - 1) / 2;
                if (data[ci].CompareTo(data[pi]) >= 0) break;
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            int li = data.Count - 1;
            T frontItem = data[0];
            data[0] = data[li];
            data.RemoveAt(li);

            --li;
            int pi = 0;
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li) break;
                int rc = ci + 1;
                if (rc <= li && data[rc].CompareTo(data[ci]) < 0)
                    ci = rc;
                if (data[pi].CompareTo(data[ci]) <= 0) break;
                T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp;
                pi = ci;
            }
            return frontItem;
        }

        public int Count
        {
            get { return data.Count; }
        }
    }
}

namespace Study.BaekJoon
{
    using Problem_1854;

    internal class Problem1854Solver
    {
        public static void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);
            int k = int.Parse(inputs[2]);

            List<(int, int)>[] adj = new List<(int, int)>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                adj[i] = new List<(int, int)>();
            }

            for (int i = 0; i < m; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int a = int.Parse(inputs[0]);
                int b = int.Parse(inputs[1]);
                int c = int.Parse(inputs[2]);
                adj[a].Add((b, c));
            }

            List<SortedSet<int>> dist = new List<SortedSet<int>>();
            for (int i = 0; i <= n; i++)
            {
                dist.Add(new SortedSet<int>());
            }

            PriorityQueue<(int, int)> pq = new PriorityQueue<(int, int)>();
            pq.Enqueue((1, 0));

            while (pq.Count > 0)
            {
                var (currentNode, currentCost) = pq.Dequeue();

                if (dist[currentNode].Count == k && currentCost >= dist[currentNode].Max) continue;

                if (dist[currentNode].Count < k)
                    dist[currentNode].Add(currentCost);
                else if (dist[currentNode].Max > currentCost)
                {
                    dist[currentNode].Remove(dist[currentNode].Max);
                    dist[currentNode].Add(currentCost);
                }

                foreach (var (nextNode, nextCost) in adj[currentNode])
                {
                    int newCost = currentCost + nextCost;
                    if (dist[nextNode].Count < k || dist[nextNode].Max > newCost)
                    {
                        pq.Enqueue((nextNode, newCost));
                    }
                }
            }

            for (int i = 1; i <= n; i++)
            {
                if (dist[i].Count == k)
                {
                    Console.WriteLine(dist[i].Max);
                }
                else
                {
                    Console.WriteLine(-1);
                }
            }

            Console.ReadKey();
        }
    }
}
