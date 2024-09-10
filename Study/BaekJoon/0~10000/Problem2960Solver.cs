using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2960
    // 에라토스테네스의 체

    internal class Problem2960Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int K = int.Parse(inputs[1]);

            bool[] isPrime = new bool[N + 1];

            for (int i = 2; i <= N; i++)
            {
                isPrime[i] = true;
            }

            int cnt = 0;
            for (int i = 2; i <= N; i++)
            {
                if (isPrime[i] == false) continue;

                for (int j = i; j <= N; j += i)
                {
                    if (isPrime[j] == false) continue;

                    isPrime[j] = false;

                    cnt++;
                    if (cnt == K)
                    {
                        Console.Write(j);

                        Console.ReadKey();

                        return;
                    }
                }
            }
        }
    }
}
