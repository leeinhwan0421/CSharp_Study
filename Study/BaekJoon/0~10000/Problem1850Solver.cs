using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1850
    // 최대공약수

    internal class Problem1850Solver
    {
        static public void Solve()
        {
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string[] inputs = Console.ReadLine().Split(' ');

            long a = long.Parse(inputs[0]);
            long b = long.Parse(inputs[1]);

            long result = GCD(a, b);

            while(result > 0)
            {
                sw.Write("1");
                result--;
            }

            sw.Flush();
            Console.ReadLine();
        }

        static public long GCD(long a, long b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }
    }
}
