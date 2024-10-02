using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/16439
    // 치킨치킨치킨

    internal class Problem16439Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            int[,] arr = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                var preference = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < M; j++)
                {
                    arr[i, j] = preference[j];
                }
            }

            int max = 0;

            for (int i = 0; i < M; i++)
            {
                for (int j = i + 1; j < M; j++)
                {
                    for (int k = j + 1; k < M; k++)
                    {
                        int cur = 0;

                        for (int member = 0; member < N; member++)
                        {
                            cur += Math.Max(arr[member, i], Math.Max(arr[member, j], arr[member, k]));
                        }

                        if (cur > max)
                        {
                            max = cur;
                        }
                    }
                }
            }

            Console.Write(max);
            
        }
    }
}
