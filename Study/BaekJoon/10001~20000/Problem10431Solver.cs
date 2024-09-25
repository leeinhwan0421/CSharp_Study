using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/10431
    // 줄세우기

    internal class Problem10431Solver
    {
        static int result = 0;
        static int[] arr;

        static public int Bubble()
        {
            result = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        result++;
                    }
                }
            }

            return result;
        }

        static public void Solve()
        {
            StringBuilder sb = new StringBuilder();

            int P = int.Parse(Console.ReadLine());

            for (int i = 0; i < P; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                int T = int.Parse(inputs[0]);
                arr = new int[20];

                for (int j = 1; j <= 20; j++)
                {
                    arr[j - 1] = int.Parse(inputs[j]);
                }

                sb.Append($"{T} {Bubble()}\n");
            }

            Console.Write(sb.ToString());
            Console.ReadKey();
        }
    }
}
