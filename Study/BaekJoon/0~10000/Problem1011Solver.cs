using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1011
    // Fly me to the Alpha Centauri

    internal class Problem1011Solver
    {
        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int move_cnt;

                string[] inputs = sr.ReadLine().Split(' ');

                int x = int.Parse(inputs[0]);
                int y = int.Parse(inputs[1]);

                int len = y - x;
                int square_root = (int)Math.Sqrt(len);

                if (Math.Pow(square_root, 2) == len)
                    move_cnt = 2 * square_root - 1;
                else
                    move_cnt = 2 * square_root;

                if (len > square_root * (square_root + 1))
                    move_cnt++;

                sw.Write($"{move_cnt}\n");
            }

            sw.Flush();
            
        }
    }
}
