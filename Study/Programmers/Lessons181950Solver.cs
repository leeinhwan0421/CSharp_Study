using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Programmers
{
    // https://school.programmers.co.kr/learn/courses/30/lessons/181950

    internal class Lessons181950Solver
    {
        public static void solution()
        {
            string input = Console.ReadLine();

            string text = input.Split(' ')[0];
            int repeat = int.Parse(input.Split(' ')[1]);

            for (int i = 0; i < repeat; i++)
            {
                Console.Write(text);
            }
        }
    }
}
