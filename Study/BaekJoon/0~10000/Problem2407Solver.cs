using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2407
    // 조합

    internal class Problem2407Solver
    {
        static BigInteger Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            BigInteger result = Factorial(N) / (Factorial(M) * Factorial(N - M));

            Console.WriteLine(result);
            
        }
    }
}
