using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/12015
    // 가장 긴 증가하는 부분 수열 2

    // https://www.acmicpc.net/problem/12738
    // 가장 긴 증가하는 부분 수열 3 (동일 코드)

    internal class Problem12015Solver
    {
        static int[] lis;
        static int[] arr;

        static public int BinarySearch(int left, int right, int target)
        {
            int mid;

            while(left < right)
            {
                mid = (left + right) / 2;

                if (lis[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return right;
        }

        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            arr = new int[n];
            lis = new int[n];

            string[] inputs = Console.ReadLine().Split(' ');

            for (int k = 0; k < n; k++)
            {
                arr[k] = int.Parse(inputs[k]);
            }

            lis[0] = arr[0];

            int i = 1;
            int j = 0;

            while(i < n)
            {
                if (lis[j] < arr[i])
                {
                    lis[j + 1] = arr[i];
                    j++;
                }
                else
                {
                    int pos = BinarySearch(0, j, arr[i]);
                    lis[pos] = arr[i];
                }
                i += 1;
            }

            Console.Write(j + 1);
            
        }
    }
}
