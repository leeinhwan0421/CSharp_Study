using System;
using System.Collections.Generic;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/13926
    // gcd(n, k) = 1

    internal class Problem13926Solver
    {
        static long Power(long x, long y, long p)
        {
            long res = 1;
            x %= p;

            while (y != 0)
            {
                if ((y & 1) == 1)
                    res = (res * x) % p;
                y >>= 1;
                x = (x * x) % p;
            }

            return res;
        }

        static bool MillerRabinTest(long d, long n)
        {
            Random rand = new Random();
            long a = 2 + (long)(rand.NextDouble() * (n - 4));
            long x = Power(a, d, n);

            if (x == 1 || x == n - 1)
                return true;

            while (d != n - 1)
            {
                x = Power(x, 2, n);
                d <<= 1;

                if (x == 1)
                    return false;
                if (x == n - 1)
                    return true;
            }

            return false;
        }

        static bool PrimeCheck(long n, int k)
        {
            if (n == 1)
                return false;

            long[] basePrimes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
            foreach (long i in basePrimes)
            {
                if (n == i)
                    return true;
                if (n % i == 0)
                    return false;
            }

            long d = n - 1;
            while ((d & 1) == 0)
                d >>= 1;

            for (int i = 0; i < k; i++)
            {
                if (!MillerRabinTest(d, n))
                    return false;
            }

            return true;
        }

        static long Gcd(long a, long b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }

        static long PollardRho(long n, int k)
        {
            if (n == 1)
                return n;
            if ((n & 1) == 0)
                return 2;

            Random rand = new Random();
            long x = 2 + (long)(rand.NextDouble() * (n - 4));
            long y = x;
            long c = 1 + (long)(rand.NextDouble() * (n - 2));
            long d = 1;

            while (d == 1)
            {
                x = (Power(x, 2, n) + c) % n;
                y = (Power(y, 2, n) + c) % n;
                y = (Power(y, 2, n) + c) % n;
                d = Gcd(Math.Abs(x - y), n);

                if (d == n)
                {
                    x = 2 + (long)(rand.NextDouble() * (n - 4));
                    y = x;
                    c = 1 + (long)(rand.NextDouble() * (n - 2));
                    d = 1;
                }
            }

            return PrimeCheck(d, k) ? d : PollardRho(d, k);
        }

        static List<long> CalcFactors(long n, int k)
        {
            List<long> res = new List<long>();

            if (n % 2 == 0)
            {
                res.Add(2);
                while (n % 2 == 0)
                    n >>= 1;
            }

            while (n != 1)
            {
                if (PrimeCheck(n, k))
                {
                    res.Add(n);
                    break;
                }

                long factor = PollardRho(n, k);

                res.Add(factor);

                while (n % factor == 0)
                    n /= factor;
            }

            return res;
        }

        static long EulerPhi(long n, int k)
        {
            if (n == 1)
                return 1;
            if (PrimeCheck(n, k))
                return n - 1;

            List<long> factors = CalcFactors(n, k);
            long res = n;
            foreach (long f in factors)
            {
                res -= (res / f);
            }

            return res;
        }

        static public void Solve()
        {
            long n = long.Parse(Console.ReadLine());
            int k = 10;

            Console.WriteLine(EulerPhi(n, k));
            Console.ReadKey();
        }
    }
}
