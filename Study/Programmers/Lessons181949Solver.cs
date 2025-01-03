using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Programmers
{
    // https://school.programmers.co.kr/learn/courses/30/lessons/181949

    internal class Lessons181949Solver
    {
        public static void solution()
        {
            string s = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                // 대
                if (s[i] >= 65 && s[i] <= 90)
                {
                    sb.Append((char)(s[i] + 32));
                }
                // 소
                else
                {
                    sb.Append((char)(s[i] - 32));
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
