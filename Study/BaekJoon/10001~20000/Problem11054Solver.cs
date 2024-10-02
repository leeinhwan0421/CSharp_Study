using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    internal class Problem11054Solver
    {
        static public void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');

            int[] arr = new int[n + 1];
            int[] lis = new int[n + 1];
            int[] lds = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                arr[i] = int.Parse(inputs[i - 1]);
                lis[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    if (arr[j] < arr[i] && lis[i] < lis[j] + 1)
                    {
                        lis[i] = lis[j] + 1;
                    }
                }
            }

            for (int i = n; i >= 1; i--)
            {
                lds[i] = 1;
                for (int j = n; j > i; j--)
                {
                    if (arr[j] < arr[i] && lds[i] < lds[j] + 1)
                    {
                        lds[i] = lds[j] + 1;
                    }
                }
            }

            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                result = Math.Max(result, lis[i] + lds[i] - 1);
            }

            Console.WriteLine(result);
            
        }
    }
}
