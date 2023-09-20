using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1016
    // 제곱 ㄴㄴ 수

    internal class Problem1016Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            long min = long.Parse(inputs[0]);
            long max = long.Parse(inputs[1]);

            bool[] chk = new bool[max - min + 1];
            
            for (long i = 2; i * i <= max; i++)
            {
                long power = i * i;
                long s = min / power;

                if (min % power != 0)
                {
                    // 나머지가 있는 경우 1을 더해줍니다 -> Min보다 더 큰 제곱수부터 시작해야지요
                    s++;
                }

                for (long j = s; power * j <= max; j++)
                {
                    chk[(int)((j * power) - min)] = true;
                }
            }

            int cnt = 0; 

            for (int i = 0; i <= max-min; i++)
            {
                if (!chk[i])
                {
                    cnt++;
                }
            }

            Console.Write(cnt);
            Console.ReadKey();
        }
    }
}
