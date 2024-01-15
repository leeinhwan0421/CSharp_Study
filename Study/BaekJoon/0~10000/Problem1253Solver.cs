using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1253
    // 좋다

    internal class Problem1253Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            Array.Sort(arr);

            int result = 0;

            for (int i = 0; i < n; i++)
            {
                int sI = 0;
                int eI = n - 1;
                int val = arr[i];

                while (sI != eI)
                {
                    int sum = arr[sI] + arr[eI];

                    if (sum == val)
                    {
                        if (sI != i && eI != i)
                        {
                            result++;
                            break;
                        }
                        else if (sI == i)
                        {
                            sI++;
                        }
                        else
                        {
                            eI--;
                        }
                    }
                    else if (sum < val)
                    {
                        sI++;
                    }
                    else
                    {
                        eI--;
                    }
                }
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
