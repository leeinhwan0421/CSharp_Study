using System;
using System.Collections.Generic;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1697
    // 숨바꼭질

    internal class Problem1697Solver
    {
        static int max = 100001;
        static int n, k;

        static bool[] visited = new bool[max];
        static int[] path = new int[max];

        public static void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            n = int.Parse(inputs[0]);
            k = int.Parse(inputs[1]);

            if (n == k)
            {
                Console.WriteLine("0");
                return;
            }

            Console.WriteLine(BFS(n));
            Console.ReadLine();
        }

        static int BFS(int v)
        {
            visited[v] = true;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (current == k)
                {
                    return path[current];
                }

                if (current - 1 >= 0 && !visited[current - 1])
                {
                    visited[current - 1] = true;
                    path[current - 1] = path[current] + 1;
                    queue.Enqueue(current - 1);
                }

                if (current + 1 < max && !visited[current + 1])
                {
                    visited[current + 1] = true;
                    path[current + 1] = path[current] + 1;
                    queue.Enqueue(current + 1);
                }

                if (current * 2 < max && !visited[current * 2])
                {
                    visited[current * 2] = true;
                    path[current * 2] = path[current] + 1;
                    queue.Enqueue(current * 2);
                }
            }

            return -1;
        }
    }
}

