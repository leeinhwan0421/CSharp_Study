using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/15965
    // K번째 소수

    internal class Problem15965Solver
    {
        static public void Solve()
        {
            int K = int.Parse(Console.ReadLine());

            bool[] isPrime = new bool[10000001];

            for (int i = 2; i < 10000001; i++)
            {
                isPrime[i] = true;
            }

            int cnt = 0;

            for (int i = 2; i < 10000001; i++)
            {
                if (isPrime[i] == false) continue;

                cnt++;

                if (cnt == K)
                {
                    Console.Write(i);
                    
                    return;
                }

                for (int j = i + i; j < 10000001; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }
    }
}
