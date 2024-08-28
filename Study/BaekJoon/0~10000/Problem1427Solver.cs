using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1427
    // 소트인사이드

    internal class Problem1427Solver
    {
        static public void Solve()
        {
            string N = Console.ReadLine();

            int[] arr = new int[N.Length];

            for (int i = 0; i < N.Length; i++)
            {
                arr[i] = int.Parse(N[i].ToString());
            }

            Array.Sort(arr);
            arr = arr.Reverse().ToArray();

            foreach(int i in arr)
            {
                Console.Write(i);
            }

            Console.ReadKey();
        }
    }
}
