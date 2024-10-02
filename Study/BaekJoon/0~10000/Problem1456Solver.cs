using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1456
    // 거의 소수

    internal class Problem1456Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            long a = long.Parse(inputs[0]);
            long b = long.Parse(inputs[1]);

            long[] arr = new long[10000001];

            for (int i = 2; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            for (int i = 2; i < Math.Sqrt(arr.Length); i++)
            {
                if (arr[i] == 0)
                    continue;
                for (int j = i + i; j < arr.Length; j += i)
                    arr[j] = 0;
            }

            int cnt = 0;

            for (int i = 2; i < arr.Length; i++) 
            {
                if (arr[i] == 0)
                    continue;

                long tmp = arr[i];

                while ((double)arr[i] <= (double)b / (double)tmp)
                {
                    if ((double)arr[i] >= (double)a / (double)tmp)
                        cnt++;

                    tmp *= arr[i];
                }

            }

            Console.Write(cnt);
            
        }
    }
}
