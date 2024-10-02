using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/31669
    // 특별한 학교 탈출

    class Problem31669Solver
    {
        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            char[,] schedule = new char[N, M];

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < M; j++)
                {
                    schedule[i, j] = line[j];
                }
            }

            for (int j = 0; j < M; j++)
            {
                bool canEscape = true;

                for (int i = 0; i < N; i++)
                {
                    if (schedule[i, j] == 'O')
                    {
                        canEscape = false;
                        break;
                    }
                }

                if (canEscape)
                {
                    Console.WriteLine(j + 1);
                    
                    return;
                }
            }

            Console.WriteLine("ESCAPE FAILED");
            

        }
    }
}
