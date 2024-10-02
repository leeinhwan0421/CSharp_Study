using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1074
    // Z

    internal class Problem1074Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int n = int.Parse(inputs[0]);
            int r = int.Parse(inputs[1]);
            int c = int.Parse(inputs[2]);

            int result = 0;
            while(n != 0)
            {
                n -= 1;

                if (r < Math.Pow(2, n) && c < Math.Pow(2, n))
                {
                }
                else if (r < Math.Pow(2, n) && c >= Math.Pow(2, n))
                {
                    result += (int)Math.Pow(2, n) * (int)Math.Pow(2, n);
                    c -= (int)Math.Pow(2, n);
                }
                else if (r >= Math.Pow(2, n) && c < Math.Pow(2, n))
                {
                    result += (int)Math.Pow(2, n) * (int)Math.Pow(2, n) * 2;
                    r -= (int)Math.Pow(2, n);
                }
                else
                {
                    result += (int)Math.Pow(2, n) * (int)Math.Pow(2, n) * 3;
                    r -= (int)Math.Pow(2, n);
                    c -= (int)Math.Pow(2, n);
                }
            }

            Console.Write(result);
            
        }
    }
}
