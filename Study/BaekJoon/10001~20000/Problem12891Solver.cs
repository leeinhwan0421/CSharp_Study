using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/12891
    // DNA 비밀번호

    internal class Problem12891Solver
    {
        static int[] myArr = new int[4];
        static int[] lineArr = new int[4];
        static int result = 0;

        static void Add(char c)
        {
            if (c == 'A')
                myArr[0]++;
            else if (c == 'C')
                myArr[1]++;
            else if (c == 'G')
                myArr[2]++;
            else if (c == 'T')
                myArr[3]++;
        }

        static void Remove(char c)
        {
            if (c == 'A')
                myArr[0]--;
            else if (c == 'C')
                myArr[1]--;
            else if (c == 'G')
                myArr[2]--;
            else if (c == 'T')
                myArr[3]--;
        }              

        static void Result()
        {
            if (myArr[0] >= lineArr[0] && myArr[1] >= lineArr[1] && myArr[2] >= lineArr[2] && myArr[3] >= lineArr[3])
                result++;
        }

        static public void Solve()
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int S = int.Parse(inputs[0]);
            int P = int.Parse(inputs[1]);

            string line = Console.ReadLine();

            inputs = Console.ReadLine().Split(' ');
            for (int i = 0; i < 4; i++)
                lineArr[i] = int.Parse(inputs[i]);

            for (int i = 0; i < P; i++)
                Add(line[i]);

            Result();

            for (int i = P; i < line.Length; i++)
            {
                int k = i - P;
                Add(line[i]);
                Remove(line[k]);

                Result();
            }

            Console.Write(result);
            Console.ReadLine();
        }
    }
}
