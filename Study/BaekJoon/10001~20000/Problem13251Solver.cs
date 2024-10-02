using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/13251
    // 조약돌 꺼내기

    internal class Problem13251Solver
    {
        static public void Solve()
        {
            int M = int.Parse(Console.ReadLine());

            int allRock = 0;

            int[] rockArr = new int[M];
            double[] probabily = new double[M];

            string[] inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < M; i++)
            {
                rockArr[i] = int.Parse(inputs[i]);
                allRock += rockArr[i];
            }

            int K = int.Parse(Console.ReadLine());
            double answer = 0;

            for (int i = 0; i < M; i++)
            {
                if (rockArr[i] >= K)
                {
                    probabily[i] = 1.0;

                    for (int k = 0; k < K; k++)
                    {
                        probabily[i] *= (double)(rockArr[i] - k) / (allRock - k); 
                    }
                }

                answer += probabily[i];
            }

            Console.Write($"{answer}");
            
        }
    }
}