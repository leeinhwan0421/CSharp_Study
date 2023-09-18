using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2343
    // 기타 레슨

    internal class Problem2343Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);

            int[] arr = new int[n];
            int s = 0;
            int e = 0;

            inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(inputs[i]);
                if (s < arr[i])
                    s = arr[i];

                e += arr[i];
            }

            while(s <= e)
            {
                int middle = (s + e) / 2;
                int sum = 0;
                int cnt = 0;

                for (int i = 0; i < n; i++)
                {
                    if (sum + arr[i] > middle)
                    {
                        cnt++;
                        sum = 0;
                    }

                    sum += arr[i];
                }

                if (sum != 0)
                    cnt++;

                if (cnt > m)
                    s = middle + 1;
                else
                    e = middle - 1;
            }

            Console.Write(s);
            Console.ReadKey();
        }
    }
}
