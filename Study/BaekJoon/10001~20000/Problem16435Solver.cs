using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/16435
    // 스네이크버그

    internal class Problem16435Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int L = int.Parse(inputs[1]);


            inputs = Console.ReadLine().Split(' ');
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            Array.Sort(arr);

            for (int i = 0; i < N; i++)
            {
                if (L >= arr[i])
                    L++;
            }

            Console.Write(L);
        }
    }
}
