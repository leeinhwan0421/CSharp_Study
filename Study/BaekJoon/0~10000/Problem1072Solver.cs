using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    internal class Problem1072Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            long x = long.Parse(inputs[0]);
            long y = long.Parse(inputs[1]);

            long z = (y * 100) / x;

            if (z >= 99)
            {
                Console.Write("-1");
            }
            else
            {
                long low = 0;
                long high = x;
                long result = -1;

                while (low <= high)
                {
                    long mid = (low + high) / 2;
                    long newZ = (100 * (y + mid)) / (x + mid);

                    if (newZ > z)
                    {
                        result = mid;
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                Console.Write($"{result}");
                Console.ReadKey();
            }
        }
    }
}
