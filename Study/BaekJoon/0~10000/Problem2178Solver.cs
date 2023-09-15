using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2178
    // 미로 탐색

    // 시간 제한이 크지 않아, BFS, FloodFill 알고리즘을 통해 쉽게 맞출 수 있습니다.
    // 저는 FloodFill 대신 BFS로 푸는 방식을 선택하겠습니다.

    internal class Problem2178Solver
    {
        static int[] dx = { 0, 1, 0, -1 };
        static int[] dy = { 1, 0, -1, 0 };

        static int[,] a = new int[101, 101];
        static bool[,] visited = new bool[101, 101];

        static int N, M;

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            N = int.Parse(inputs[0]);
            M = int.Parse(inputs[1]);

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < M; j++)
                {
                    a[i, j] = int.Parse(line[j].ToString());
                }
            }

            BFS(0, 0);
            Console.Write(a[N - 1, M - 1]);
            Console.ReadKey();
        }

        static public void BFS(int i, int j)
        {
            Queue<(int, int)> myQueue = new Queue<(int, int)>();
            myQueue.Enqueue((i, j));

            while (myQueue.Count > 0)
            {
                int[] nw = new int[2];

                nw[0] = myQueue.First().Item1;
                nw[1] = myQueue.First().Item2;
                myQueue.Dequeue();

                visited[i, j] = true;

                for (int p = 0; p < 4; p++)
                {
                    int x = nw[0] + dx[p];
                    int y = nw[1] + dy[p];

                    if (x >= 0 && y >= 0 && x < N && y < M)
                    {
                        if (a[x, y] != 0 && !visited[x, y])
                        {
                            visited[x, y] = true;
                            a[x, y] = a[nw[0], nw[1]] + 1;
                            myQueue.Enqueue((x, y));
                        }
                    }
                }
            }
        }
    }
}
