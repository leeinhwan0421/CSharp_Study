using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11399
    // ATM

    internal class Problem11399Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            String[] line = Console.ReadLine().Split();

            List<int> pList = new List<int>();

            for (int i = 0; i < line.Length; i++)
                pList.Add(int.Parse(line[i]));

            int result = 0;
            int curTime = 0;

            while (pList.Count != 0)
            {
                int cur = pList.Min();

                curTime += cur;
                result += curTime;

                pList.Remove(cur);
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
