using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/27964
    // 콰트로 치즈 피자

    internal class Problem27964Solver
    {
        static public void Solve()
        {
            Console.ReadLine();

            string[] inputs = Console.ReadLine().Split(' ');

            string[] distinct = inputs.Distinct().ToArray();

            int result = 0;

            for (int i = 0; i < distinct.Length; i++)
            {
                if (distinct[i].EndsWith("Cheese"))
                {
                    result++;
                }

            }

            Console.Write($"{(result >= 4 ? "yummy" : "sad")}");
            Console.ReadKey();
        }
    }
}
