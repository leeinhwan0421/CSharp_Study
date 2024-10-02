using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/14889
    // 스타트와 링크

    internal class Problem14889Solver
    {
        static int N;
        static int[,] arr;
        static bool[] visited;

        static int result = int.MaxValue;

        static public void Solve()
        {
            N = int.Parse(Console.ReadLine());

            arr = new int[N, N];
            visited = new bool[N];

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                for (int j = 0; j < N; j++)
                    arr[i, j] = int.Parse(inputs[j]);
            }

            DFS(0, 1);

            Console.Write(result);

            
        }

        static void DFS(int x, int ps)
        {
            if (x == N / 2)
            {
                int start = 0;
                int link = 0;

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (visited[i] && visited[j])
                            start += arr[i, j];
                        if (!visited[i] && !visited[j])
                            link += arr[i, j];
                    }
                }

                int temp = Math.Abs(start - link);

                if (result > temp)
                    result = temp;

                return;
            }

            for (int i = ps; i < N; i++)
            {
                visited[i] = true;
                DFS(x + 1, i + 1);
                visited[i] = false;
            }
        }
    }
}