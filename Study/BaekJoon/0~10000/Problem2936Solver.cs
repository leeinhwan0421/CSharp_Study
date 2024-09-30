using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2936
    // 채식주의자

    // 위 문제는 분기 조건이 많기 떄문에, Program.Main 함수 내부에 Console.ReadKey 함수를 넣어줬습니다.

    internal class Problem2936Solver
    {
        static public void Solve()
        {
            string[] tokens = Console.ReadLine().Split();
            int a = int.Parse(tokens[0]);
            int b = int.Parse(tokens[1]);

            if (a + b == 0)
            {
                Console.WriteLine("125.00 125.00");
                return;
            }
            double baseArea = 250.0 * 250.0 / 2;

            if (a > 0 && b > 0)
            {
                double val = 250.0 - baseArea / Math.Max(a, b);
                if (a > b)
                    Console.WriteLine("0.00 {0:F2}", val);
                else
                    Console.WriteLine("{0:F2} 0.00", val);
                return;
            }

            if (a < 125 && b == 0)
            {
                double tmp = 250.0 - baseArea / (250 - a);
                Console.WriteLine("{0:F2} {1:F2}", tmp, 250.0 - tmp);
                return;
            }

            if (a == 0 && b < 125)
            {
                double tmp = 250.0 - baseArea / (250 - b);
                Console.WriteLine("{0:F2} {1:F2}", 250.0 - tmp, tmp);
                return;
            }

            if (b == 0)
            {
                double val = baseArea / a;
                Console.WriteLine("0.00 {0:F2}", val);
                return;
            }

            double valF = baseArea / b;
            Console.WriteLine("{0:F2} 0.00", valF);
        }
    }
}
