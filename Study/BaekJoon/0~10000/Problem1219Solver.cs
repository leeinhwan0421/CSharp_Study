using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1219
    // 오민식의 고민

    internal class Problem1219Solver
    {
        static List<(int, int, int)> edges = new List<(int, int, int)>();
        static int N, M, start, end;
        static long[] distance = new long[0];
        static long[] cityWeight = new long[0];

        static string[] inputs = new string[0];

        static public void Solve()
        {
            inputs = Console.ReadLine().Split(' ');

            N       = int.Parse(inputs[0]);
            start   = int.Parse(inputs[1]);
            end     = int.Parse(inputs[2]);
            M       = int.Parse(inputs[3]);

            distance = new long[N];
            cityWeight = new long[N];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = long.MinValue;
            }

            for (int i = 0; i < M; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                int s = int.Parse(inputs[0]);
                int e = int.Parse(inputs[1]);
                int w = int.Parse(inputs[2]);

                edges.Add((s, e, w));
            }

            inputs = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++)
            {
                cityWeight[i] = long.Parse(inputs[i]);
            }

            distance[start] = cityWeight[start];

            for (int i = 0; i <= N + 50; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    var edge = edges[j];

                    int s = edge.Item1;
                    int e = edge.Item2;
                    int w = edge.Item3;

                    if (distance[s] == long.MinValue)
                    {
                        continue;
                    }
                    else if (distance[s] == long.MaxValue)
                    {
                        distance[e] = long.MaxValue; 
                    }
                    else if (distance[e] < distance[s] + cityWeight[e] - w)
                    {
                        distance[e] = distance[s] + cityWeight[e] - w;

                        if (i >= N - 1)
                        {
                            distance[e] = long.MaxValue;
                        }
                    }
                }
            }

            if (distance[end] == long.MinValue)
            {
                Console.Write("gg");
            }
            else if (distance[end] == long.MaxValue)
            {
                Console.Write("Gee");
            }
            else
            {
                Console.Write(distance[end]);
            }

            Console.ReadKey();
        }
    }
}
