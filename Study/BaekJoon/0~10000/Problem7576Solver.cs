using System;
using System.Collections.Generic;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/7576
    // 토마토

    // FloodFill로 풀었는데 잘 안되서
    // BFS 형식으로 코드를 바꿔봤습니다.
    // 제발돼라

    internal class Problem7576Solver
    {
        static int[,] arr;
        static int rows;
        static int cols;
        static int[] dx = { 1, -1, 0, 0 };
        static int[] dy = { 0, 0, 1, -1 };

        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            String[] str = sr.ReadLine().Split(' ');

            rows = int.Parse(str[0]);
            cols = int.Parse(str[1]);

            arr = new int[cols, rows];
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

            for (int i = 0; i < cols; i++)
            {
                String[] line = sr.ReadLine().Split(' ');

                for (int j = 0; j < rows; j++)
                {
                    arr[i, j] = int.Parse(line[j]);

                    if (arr[i, j] == 1)
                    {
                        queue.Enqueue(new Tuple<int, int>(i, j));
                    }
                }
            }

            int days = BFS(queue);

            if (CheckAllRipe())
            {
                Console.Write(days);
            }
            else
            {
                Console.Write("-1");
            }

            Console.ReadKey();
        }

        static int BFS(Queue<Tuple<int, int>> queue)
        {
            int days = -1;

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    Tuple<int, int> tomato = queue.Dequeue();
                    int x = tomato.Item1;
                    int y = tomato.Item2;

                    for (int j = 0; j < 4; j++)
                    {
                        int nx = x + dx[j];
                        int ny = y + dy[j];

                        if (nx >= 0 && nx < cols && ny >= 0 && ny < rows && arr[nx, ny] == 0)
                        {
                            arr[nx, ny] = 1;
                            queue.Enqueue(new Tuple<int, int>(nx, ny));
                        }
                    }
                }

                days++;
            }

            return days;
        }

        static bool CheckAllRipe()
        {
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
