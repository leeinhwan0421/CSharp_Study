using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1722
    // 순열의 순서

    internal class Problem1722Solver
    {
        static int N;
        static int Q;

        static ulong[] F = new ulong[21];
        static int[] S = new int[21];

        static bool[] visited = new bool[21];

        static public void Solve()
        {
            N = int.Parse(Console.ReadLine());

            F[0] = 1;

            for (int i = 1; i <= N; i++)
            {
                F[i] = F[i - 1] * (ulong)i;
            }

            string[] inputs = Console.ReadLine().Split(' ');

            Q = int.Parse(inputs[0]);

            if (Q == 1)
            {
                ulong K = ulong.Parse(inputs[1]);

                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1, cnt = 1; j <= N; j++)
                    {
                        if (visited[j]) continue;

                        if (K <= (ulong)cnt * F[N - i])
                        {
                            K -= (ulong)(cnt - 1) * F[N - i];
                            S[i] = j;
                            visited[j] = true;
                            break;
                        }

                        cnt++;
                    }
                }

                for (int i = 1; i <= N; i++)
                {
                    Console.Write($"{S[i]} ");
                }
            }
            else
            {
                ulong K = 1;

                for (int i = 1; i <= N; i++)
                {
                    S[i] = int.Parse(inputs[i]);

                    ulong cnt = 0;

                    for (int j = 1; j < S[i]; j++)
                    {
                        if (visited[j] == false)
                        {
                            cnt++;
                        }
                    }

                    K += cnt * F[N - i];
                    visited[S[i]] = true;
                }

                Console.Write(K);
            }

            Console.ReadKey();
        }
    }
}
