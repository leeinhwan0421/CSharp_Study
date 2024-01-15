using System;
using System.Collections.Generic;
using System.IO;

namespace Study.BaekJoon
{
    internal class Problem14940Solver
    {
        static int[,] field;
        static int[,] distances;
        static bool[,] visited;

        static int n;
        static int m;

        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string[] inputs = sr.ReadLine().Split(' ');

            n = int.Parse(inputs[0]);
            m = int.Parse(inputs[1]);

            field = new int[1001, 1001];
            distances = new int[1001, 1001]; // Initialize distances to -1
            visited = new bool[1001, 1001];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    distances[i, j] = -1;
                }
            }

            (int, int) start = (0, 0);

            for (int i = 0; i < n; i++)
            {
                inputs = sr.ReadLine().Split(' ');

                for (int j = 0; j < m; j++)
                {
                    field[i, j] = int.Parse(inputs[j]);

                    if (field[i, j] == 2)
                        start = (i, j);
                }
            }

            BFS(start.Item1, start.Item2);

            PrintResult(sw);

            sw.Flush();
        }

        static public void BFS(int startX, int startY)
        {
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((startX, startY));
            visited[startX, startY] = true;
            distances[startX, startY] = 0;

            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int x = current.Item1;
                int y = current.Item2;

                for (int i = 0; i < 4; i++)
                {
                    int newX = x + dx[i];
                    int newY = y + dy[i];

                    if (newX >= 0 && newX < n && newY >= 0 && newY < m && !visited[newX, newY] && field[newX, newY] == 1)
                    {
                        distances[newX, newY] = distances[x, y] + 1;
                        visited[newX, newY] = true;
                        queue.Enqueue((newX, newY));
                    }
                }
            }
        }

        static public void PrintResult(StreamWriter sw)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (field[i, j] == 0)
                        sw.Write($"0 ");
                    else if (visited[i, j])
                        sw.Write($"{distances[i, j]} ");
                    else
                        sw.Write($"-1 ");
                }

                sw.WriteLine();
            }
        }
    }
}
