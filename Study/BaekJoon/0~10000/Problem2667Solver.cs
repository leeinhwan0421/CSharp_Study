using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2667
    // 단지번호붙이기

    internal class Problem2667Solver
    {
        static int N = 0;
        static int[,] map = new int[0, 0];
        static bool[,] visited = new bool[0, 0];

        static public void Solve()
        {
            N = int.Parse(Console.ReadLine());

            map = new int[N, N];
            visited = new bool[N, N];
            
            List<int> answer = new List<int>();

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < N; j++)
                {
                    map[i, j] = int.Parse(line[j].ToString());
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (visited[i, j])
                        continue;

                    if (map[i, j] != 0)
                        answer.Add(BFS(i, j));
                }
            }


            answer.Sort();

            Console.Write($"{answer.Count}\n");

            for (int i = 0; i < answer.Count; i++)
            {
                Console.Write($"{answer[i]}\n");
            }

            Console.ReadKey();
        }

        static public int BFS(int x, int y)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();

            q.Enqueue((x, y));
            visited[x, y] = true;
            int cnt = 1;

            while (q.Count != 0)
            {
                var nw = q.Dequeue();

                if (nw.Item1 > 0 && map[nw.Item1 - 1, nw.Item2] != 0 && visited[nw.Item1 - 1, nw.Item2] == false)
                {
                    q.Enqueue((nw.Item1 - 1, nw.Item2));
                    visited[nw.Item1 - 1, nw.Item2] = true;
                    cnt++;
                }

                if (nw.Item2 > 0 && map[nw.Item1, nw.Item2 - 1] != 0 && visited[nw.Item1, nw.Item2 - 1] == false)
                {
                    q.Enqueue((nw.Item1, nw.Item2 - 1));
                    visited[nw.Item1, nw.Item2 - 1] = true;
                    cnt++;
                }

                if (nw.Item1 < N - 1 && map[nw.Item1 + 1, nw.Item2] != 0 && visited[nw.Item1 + 1, nw.Item2] == false)
                {
                    q.Enqueue((nw.Item1 + 1, nw.Item2));
                    visited[nw.Item1 + 1, nw.Item2] = true;
                    cnt++;
                }

                if (nw.Item2 < N - 1 && map[nw.Item1, nw.Item2 + 1] != 0 && visited[nw.Item1, nw.Item2 + 1] == false)
                {
                    q.Enqueue((nw.Item1, nw.Item2 + 1));
                    visited[nw.Item1, nw.Item2 + 1] = true;
                    cnt++;
                }
            }

            return cnt;
        }
    }
}
