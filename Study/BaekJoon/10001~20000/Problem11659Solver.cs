using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/11659
    // 구간 합 구하기 4

    internal class Problem11659Solver
    {
        static public void Solve()
        {
            StringBuilder sb = new StringBuilder();

            string[] inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            string[] S = Console.ReadLine().Split(' ');

            int[] arr = new int[S.Length + 1];

            for (int i = 1; i <= S.Length; i++)
            {
                arr[i] += arr[i - 1] + int.Parse(S[i - 1]);
            }

            for (int i = 0; i < M; i++)
            {
                string[] str = Console.ReadLine().Split(' ');

                int start = int.Parse(str[0]);
                int end = int.Parse(str[1]);


                sb.Append($"{arr[end] - arr[start - 1]}\n");
            }

            Console.WriteLine(sb);
            Console.ReadKey();
        }
    }
}
