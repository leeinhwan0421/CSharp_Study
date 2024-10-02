using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11657
    // 타임머신

    internal class Problem11657Solver
    {
        static public void Solve()
        {
            // start, end, weight
            List<(int, int, int)> node = new List<(int, int, int)>();
            long[] distance = new long[0];

            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            distance = new long[N + 1];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
            }

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int a = int.Parse(inputs[0]);
                int b = int.Parse(inputs[1]);
                int c = int.Parse(inputs[2]);

                node.Add((a, b, c));
            }

            distance[1] = 0;

            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    var current = node[j];

                    int s = current.Item1; // start
                    int e = current.Item2; // end
                    int w = current.Item3; // weight

                    if (distance[s] != int.MaxValue && distance[e] > distance[s] + w)
                    {
                        distance[e] = distance[s] + w;
                    }
                }
            }

            bool negativeCycle = false;

            for (int i = 0; i < M; i++)
            {
                var current = node[i];

                int s = current.Item1; // start
                int e = current.Item2; // end
                int w = current.Item3; // weight

                if (distance[s] != int.MaxValue && distance[e] > distance[s] + w)
                {
                    negativeCycle = true;
                    break;
                }
            }

            if (!negativeCycle)
            {
                for (int i = 2; i <= N; i++)
                {
                    if (distance[i] == int.MaxValue)
                    {
                        Console.Write("-1\n");
                    }
                    else
                    {
                        Console.Write($"{distance[i]}\n");
                    }
                }
            }
            else
            {
                Console.Write("-1\n");
            }

            
        }
    }
}
