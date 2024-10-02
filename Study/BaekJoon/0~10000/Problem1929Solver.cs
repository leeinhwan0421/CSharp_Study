using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1929
    // 소수 구하기

    internal class Problem1929Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');
            
            int M = int.Parse(inputs[0]);
            int N = int.Parse(inputs[1]);

            bool[] isPrime = new bool[N + 1];

            for (int i = 2; i <= N; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i <= Math.Sqrt(N); i++)
            {
                if (isPrime[i])
                {
                    for (int j = i + i; j <= N; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            for (int i = M; i <= N; i++)
            {
                if (isPrime[i])
                {
                    Console.Write($"{i}\n");
                }
            }

            
        }
    }
}
