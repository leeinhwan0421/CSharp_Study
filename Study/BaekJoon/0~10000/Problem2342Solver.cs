using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/2342
    // Dance Dance Revolution

    internal class Problem2342Solver
    {
        static public int Cost(int from, int to)
        {
            if (from == to) 
                return 1;

            if (from == 0) 
                return 2;

            if ((from == 1 && to == 3) || (from == 3 && to == 1) ||
                (from == 2 && to == 4) || (from == 4 && to == 2)) 
                return 4;
            
            return 3;
        }

        static public void Solve()
        {
            List<int> commands = new List<int>();
            string[] inputs = Console.ReadLine().Split(' ');
            foreach (var input in inputs)
            {
                int num = int.Parse(input);

                if (num == 0)
                    break; 

                commands.Add(num);
            }

            int[,,] DP = new int[commands.Count + 1, 5, 5];
            for (int i = 0; i <= commands.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        DP[i, j, k] = 100000000;
                    }
                }
            }

            DP[0, 0, 0] = 0;

            for (int i = 0; i < commands.Count; i++)
            {
                int command = commands[i];

                for (int left = 0; left < 5; left++)
                {
                    for (int right = 0; right < 5; right++)
                    {
                        if (command != right)
                        {
                            DP[i + 1, command, right] = Math.Min(DP[i + 1, command, right], DP[i, left, right] + Cost(left, command));
                        }
                        if (command != left)
                        {
                            DP[i + 1, left, command] = Math.Min(DP[i + 1, left, command], DP[i, left, right] + Cost(right, command));
                        }
                    }
                }
            }

            int result = int.MaxValue;
            for (int left = 0; left < 5; left++)
            {
                for (int right = 0; right < 5; right++)
                {
                    result = Math.Min(result, DP[commands.Count, left, right]);
                }
            }

            Console.Write(result);
            Console.ReadKey();
        }
    }
}
