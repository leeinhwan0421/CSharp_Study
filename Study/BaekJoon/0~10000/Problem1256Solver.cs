using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1256
    // 사전

    internal class Problem1256Solver
    {
        static public void Solve()
        {
            long[,] D = new long[202, 202];

            string[] inputs = Console.ReadLine().Split(' ');
        
            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);
            int K = int.Parse(inputs[2]);

            for (int i = 0; i <= 200; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        D[i, j] = 1;
                    }
                    else
                    {
                        D[i, j] = D[i - 1, j - 1] + D[i - 1, j];

                        if (D[i, j] > 1000000000)
                        {
                            D[i, j] = 1000000001;
                        }
                    }
                }
            }

            if (D[N + M, M] < K)
            {
                Console.Write("-1");
            }
            else
            {
                while(!(N == 0 && M == 0))
                {
                    if (D[N - 1 + M, M] >= K)
                    {
                        Console.Write("a");
                        N--;
                    }
                    else
                    {
                        Console.Write("z");
                        K = (int)(K - D[N - 1 + M, M]);
                        M--;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
