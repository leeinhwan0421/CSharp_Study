using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11758
    // CCW

    internal class Problem11758Solver
    {
        static int CCW(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);
        }

        static public void Solve()
        {

            int[,] arr = new int[3, 2];

            for (int i = 0; i < 3; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                arr[i, 0] = int.Parse(inputs[0]);
                arr[i, 1] = int.Parse(inputs[1]);
            }

            int result = CCW(arr[0, 0], arr[0, 1], arr[1, 0], arr[1, 1], arr[2, 0], arr[2, 1]);

            if (result == 0)
                Console.Write("0");
            else if (result > 0)
                Console.Write("1");
            else
                Console.Write("-1");

            
        }
    }
}
