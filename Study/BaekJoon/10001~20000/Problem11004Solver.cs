using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11004
    // K번째 수
    // Sort 연습으로 사용 가능

    internal class Problem11004Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int K = int.Parse(inputs[1]);

            int[] A_list = new int[N];

            inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < N; i++)
            {
                A_list[i] = int.Parse(inputs[i]);
            }

            Array.Sort(A_list);

            Console.WriteLine(A_list[K - 1]);
        }
    }
}
