using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/29634
    // Hotel

    internal class Problem29634Solver
    {
        static char[,] hotel;
        static bool[,] visited;
        static int result = 0;
        static int n, m;

        static public void FloodFill(int x, int y, int cnt)
        {
            if (x < 0 || y < 0 || x >= n || y >= m)
                return;

            if (hotel[x, y] == '*' || visited[x, y])
                return;

            if (result < cnt)
                result = cnt;

            visited[x, y] = true;

            FloodFill(x + 1, y, cnt+ 1);
            FloodFill(x - 1, y, cnt + 1);
            FloodFill(x, y + 1, cnt + 1);
            FloodFill(x, y - 1, cnt + 1);
        }

        static public void Solve()
        {
            string[] arr = Console.ReadLine().Split(' ');

            n = int.Parse(arr[0]);
            m = int.Parse(arr[1]);

            hotel = new char[n, m];
            visited = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < m; j++)
                {
                    hotel[i, j] = line[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (hotel[i, j] == '.' && !visited[i, j])
                    {
                        FloodFill(i, j, 1);
                    }
                }
            }

            Console.Write(result == 0 ? "-1" : $"{result}");
            Console.ReadKey();
        }
    }
}
