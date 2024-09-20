using System;
using System.Collections.Generic;
using System.Numerics;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/13926
    // gcd(n, k) = 1

    internal class Problem13926Solver
    {
        static BigInteger Power(BigInteger x, BigInteger y, BigInteger p)
        {
            return BigInteger.ModPow(x, y, p);
        }

        static bool MillerRabinTest(BigInteger d, BigInteger n, BigInteger a)
        {
            BigInteger x = Power(a, d, n);

            if (x == 1 || x == n - 1)
                return true;

            while (d != n - 1)
            {
                x = (x * x) % n;
                d <<= 1;

                if (x == 1)
                    return false;
                if (x == n - 1)
                    return true;
            }

            return false;
        }

        static bool PrimeCheck(BigInteger n)
        {
            if (n == 2 || n == 3)
                return true;
            if (n < 2 || n % 2 == 0)
                return false;

            // Deterministic bases for n < 10^18
            BigInteger[] bases = { 2, 3, 5, 7, 11 };

            BigInteger d = n - 1;
            while ((d & 1) == 0)
                d >>= 1;

            foreach (var a in bases)
            {
                if (a >= n)
                    continue;
                if (!MillerRabinTest(d, n, a))
                    return false;
            }

            return true;
        }

        static BigInteger Gcd(BigInteger a, BigInteger b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }

        static BigInteger PollardRho(BigInteger n)
        {
            if (n % 2 == 0)
                return 2;
            if (n % 3 == 0)
                return 3;

            BigInteger x = 2, y = 2, c = 1, d = 1;

            while (d == 1)
            {
                x = (x * x + c) % n;
                y = (y * y + c) % n;
                y = (y * y + c) % n;
                d = Gcd(BigInteger.Abs(x - y), n);

                if (d == n)
                {
                    c++;
                    x = 2;
                    y = 2;
                    d = 1;
                }
            }

            return d;
        }

        static void Factorize(BigInteger n, HashSet<BigInteger> factors)
        {
            if (n == 1)
                return;

            if (PrimeCheck(n))
            {
                factors.Add(n);
                return;
            }

            BigInteger d = PollardRho(n);
            Factorize(d, factors);
            Factorize(n / d, factors);
        }

        static BigInteger EulerPhi(BigInteger n)
        {
            if (n == 1)
                return 1;

            HashSet<BigInteger> factors = new HashSet<BigInteger>();
            Factorize(n, factors);

            BigInteger res = n;
            foreach (BigInteger p in factors)
            {
                res -= res / p;
            }

            return res;
        }

        static public void Solve()
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());

            Console.Write(EulerPhi(n));
            Console.ReadKey();
        }
    }
}
