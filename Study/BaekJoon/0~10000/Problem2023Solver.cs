using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2023
    // 신기한 소수

    internal class Problem2023Solver
    {
        static int N;
        static StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

        static public bool isPrime(int x)
        {
            if (x == 1) 
                return false;

            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                    return false;
            }

            return true;
        }

        static public void Solve()
        {
            N = int.Parse(Console.ReadLine());

            DFS(2, 1);
            DFS(3, 1);
            DFS(5, 1);
            DFS(7, 1);

            sw.Flush();
            Console.ReadKey();
        }

        static public void DFS(int num, int digit)
        {
            if (digit == N)
            {
                if (isPrime(num))
                    sw.Write($"{num}\n");

                return;
            }

            for (int i = 1; i <= 9; i++)
            {
                if (i % 2 == 0)
                    continue;

                if (isPrime(num * 10 + i))
                {
                    DFS(num * 10 + i, digit + 1);
                }
            }
        }
    }
}
