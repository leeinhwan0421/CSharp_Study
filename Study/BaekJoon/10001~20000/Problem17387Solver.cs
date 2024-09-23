using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/17387
    // 선분 교차 2

    internal class Problem17387Solver
    {
        // CCW 함수
        static int CCW(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            long result = (long)(x2 - x1) * (y3 - y1) - (long)(x3 - x1) * (y2 - y1);
            if (result > 0) return 1;
            if (result < 0) return -1;
            return 0;
        }

        static bool IsIntersect(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            int ccw1 = CCW(x1, y1, x2, y2, x3, y3);
            int ccw2 = CCW(x1, y1, x2, y2, x4, y4);
            int ccw3 = CCW(x3, y3, x4, y4, x1, y1);
            int ccw4 = CCW(x3, y3, x4, y4, x2, y2);

            if (ccw1 * ccw2 <= 0 && ccw3 * ccw4 <= 0)
            {
                if (ccw1 == 0 && ccw2 == 0 && ccw3 == 0 && ccw4 == 0)
                {
                    if (Math.Min(x1, x2) <= Math.Max(x3, x4) && Math.Min(x3, x4) <= Math.Max(x1, x2) &&
                        Math.Min(y1, y2) <= Math.Max(y3, y4) && Math.Min(y3, y4) <= Math.Max(y1, y2))
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }

        static public void Solve()
        {
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();

            int x1 = int.Parse(input1[0]);
            int y1 = int.Parse(input1[1]);
            int x2 = int.Parse(input1[2]);
            int y2 = int.Parse(input1[3]);

            int x3 = int.Parse(input2[0]);
            int y3 = int.Parse(input2[1]);
            int x4 = int.Parse(input2[2]);
            int y4 = int.Parse(input2[3]);

            if (IsIntersect(x1, y1, x2, y2, x3, y3, x4, y4))
            {
                Console.Write(1);
            }
            else
            {
                Console.Write(0);
            }

            Console.ReadKey();
        }
    }
}
