using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/1780
    // 종이의 개수

    internal class Problem1780Solver
    {
        static int[,] arr;

        static int Case1; // -1
        static int Case2; // 0
        static int Case3; // 1 

        static public void Recursive(int minx, int maxx, int miny, int maxy)
        {
            int firstValue = arr[minx, miny];
            bool isUniform = true;

            for (int i = minx; i < maxx; i++)
            {
                for (int j = miny; j < maxy; j++)
                {
                    if (arr[i, j] != firstValue)
                    {
                        isUniform = false;
                        break;
                    }
                }
                if (!isUniform) break;
            }

            if (isUniform)
            {
                if (firstValue == -1) Case1++;
                else if (firstValue == 0) Case2++;
                else if (firstValue == 1) Case3++;
                return;
            }

            int size = (maxx - minx) / 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Recursive(minx + i * size, minx + (i + 1) * size, miny + j * size, miny + (j + 1) * size);
                }
            }
        }

        static public void Solve()
        {
            int N = int.Parse(Console.ReadLine());

            arr = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');

                for (int j = 0; j < N; j++)
                {
                    arr[i, j] = int.Parse(inputs[j]);
                }
            }

            Recursive(0, N, 0, N);

            Console.WriteLine(Case1);
            Console.WriteLine(Case2);
            Console.WriteLine(Case3);

            
        }
    }
}
