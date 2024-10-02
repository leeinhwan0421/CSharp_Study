using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1920
    // 수 찾기

    internal class Problem1920Solver
    {
        static int[] arr = new int[1];
        static StringBuilder sb = new StringBuilder();

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());
            string[] Nline = Console.ReadLine().Split(' ');

            arr = new int[N];

            for (int i = 0; i < Nline.Length; i++)
            {
                arr[i] = int.Parse(Nline[i]);
            }

            Array.Sort(arr);

            // ======================================== //

            int M = int.Parse(Console.ReadLine());
            string[] Mline = Console.ReadLine().Split(' ');

            for (int i = 0; i < Mline.Length; i++)
            {
                BinarySearch(int.Parse(Mline[i]));
            }

            Console.Write(sb.ToString());
            
        }

        static public void BinarySearch(int n)
        {
            int start = 0;
            int end = arr.Length - 1;

            bool find = false;

            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (arr[middle] > n)
                {
                    end = middle - 1;
                }
                else if (arr[middle] < n)
                {
                    start = middle + 1;
                }
                else
                {
                    find = true;
                    break;
                }
            }

            if (find)
                sb.Append("1\n");
            else
                sb.Append("0\n");
        }
    }
}
