using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1644
    // 소수의 연속합

    internal class Problem1644Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            // 에라토스테네스

            bool[] isPrime = new bool[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i] == false) continue;
                for (int j = i + i; j <= n; j += i)
                {
                    isPrime[j] = false;
                }
            }

            // 계산

            List<int> prime_list = new List<int>();

            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i] == true)
                    prime_list.Add(i);
            }

            int startIndex = 0;
            int endIndex = 0;
            int sum = 0;
            int cases = 0;

            while(true)
            {
                if (sum >= n)
                {
                    sum -= prime_list[startIndex++];
                }
                else if (endIndex >= prime_list.Count)
                {
                    break;
                }
                else
                {
                    sum += prime_list[endIndex++];
                }

                if (sum == n)
                {
                    cases++;
                }
            }

            Console.Write(cases);
            Console.ReadLine();
        }
    }
}
