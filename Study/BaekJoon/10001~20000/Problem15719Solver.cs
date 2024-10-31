using System;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/15719
    // 중복된 숫자

    internal class Problem15719Solver
    {
        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            long Nsum = 0;

            string inputLine = Console.ReadLine();
            int currentNumber = 0;

            foreach (char c in inputLine)
            {
                if (c == ' ')
                {
                    Nsum += currentNumber;
                    currentNumber = 0;
                }
                else
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                }
            }

            Nsum += currentNumber;
            long expectedSum = (long)(N - 1) * N / 2;
            Console.WriteLine(Nsum - expectedSum);
        }
    }
}
