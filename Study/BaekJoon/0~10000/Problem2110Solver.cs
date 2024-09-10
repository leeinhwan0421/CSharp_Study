using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2110
    // 공유기 설치

    internal class Problem2110Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            int[] arr = new int[N];

            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(arr);

            int s = 1;
            int e = arr[N - 1] - arr[0] + 1;
            int result = 0;

            while (s < e)
            {
                int mid = (s + e) / 2; 
                int installed = 1;
                int lastInstalledLocation = arr[0];

                for (int i = 1; i < N; i++)
                {
                    if (arr[i] - lastInstalledLocation >= mid)
                    {
                        installed++;
                        lastInstalledLocation = arr[i];
                    }
                }

                if (installed >= M)
                {
                    result = mid;
                    s = mid + 1;
                }
                else
                {
                    e = mid;
                }
            }

            Console.Write(result);
            Console.ReadKey();
        }
    }
}
