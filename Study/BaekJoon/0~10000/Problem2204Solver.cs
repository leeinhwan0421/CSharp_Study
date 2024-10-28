using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2204
    // 도비의 난독증 테스트 

    internal class Problem2204Solver
    {
        static public void Solve()
        {
            while (true)
            {
                int n = int.Parse(Console.ReadLine());

                if (n == 0)
                {
                    break;
                }

                List<string> list = new List<string>();

                for (int i = 0; i < n; i++)
                {
                    list.Add(Console.ReadLine());
                }

                list.Sort(StringComparer.OrdinalIgnoreCase);

                Console.WriteLine(list.First());
            }

            Console.ReadKey();
        }
    }
}
