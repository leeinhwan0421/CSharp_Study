using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Programmers
{
    // https://school.programmers.co.kr/learn/courses/30/lessons/181951

    internal class Lessons181951Solver
    {
        public static void solution()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.Write($"a = {numbers[0]}\nb = {numbers[1]}");
        }
    }
}
