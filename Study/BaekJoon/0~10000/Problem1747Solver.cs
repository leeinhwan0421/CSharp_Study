using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1747
    // 소수 & 팰린드롬

    internal class Problem1747Solver
    {
        static public bool Palindrome(int target)
        {
            char[] c = target.ToString().ToCharArray();

            int s = 0;
            int e = c.Length - 1;

            while (s < e)
            {
                if (c[s] != c[e])
                    return false;

                s++;
                e--;
            }

            return true;
        }

        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[10000001];

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

            for (int i = n; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    continue;

                if (Palindrome(arr[i]))
                {
                    Console.Write(arr[i]);
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
