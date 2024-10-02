using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11689
    // GCD(n, k) = 1
    // 오일러 피 함수 구현 문제**

    // 서로소를 구하는 거다.
    // 9로 입력하면 1, 2, 4, 5, 7, 8

    internal class Problem11689Solver
    {
        static public void Solve()
        {
            long n = long.Parse(Console.ReadLine());
            long result = n;

            for (long p = 2; p <= Math.Sqrt(n); p++)
            {
                if (n % p == 0)
                {
                    result -= result / p;

                    while (n % p == 0)
                    {
                        n /= p;
                    }
                }
            }

            if (n > 1)
            {
                result -= result / n;
            }

            Console.Write(result);
            
        }
    }
}
