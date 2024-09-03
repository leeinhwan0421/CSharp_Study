using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/4195
    // 친구 네트워크

    internal class Problem4195Solver
    {
        static string[] inputs;

        static Dictionary<string, string> friends = new Dictionary<string, string>();
        static Dictionary<string, int> friends_count = new Dictionary<string, int>();

        static public void Union(string A, string B)
        {
            A = Find(A);
            B = Find(B);

            if (A == B) return;

            friends[B] = A;
            friends_count[A] += friends_count[B];

        }

        static public string Find(string A)
        {
            if (friends[A] == A)
            {
                return A;
            }
            else
            {
                return friends[A] = Find(friends[A]);
            }
        }

        static public void Solve()
        {
            int T = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < T; i++)
            {
                int F = int.Parse(Console.ReadLine());

                friends.Clear();
                friends_count.Clear();

                for (int j = 0; j < F; j++)
                {
                    inputs = Console.ReadLine().Split(' ');

                    if (!friends.ContainsKey(inputs[0]))
                    {
                        friends.Add(inputs[0], inputs[0]);
                        friends_count.Add(inputs[0], 1);
                    }
                    if (!friends.ContainsKey(inputs[1]))
                    {
                        friends.Add(inputs[1], inputs[1]);
                        friends_count.Add(inputs[1], 1);
                    }

                    Union(inputs[0], inputs[1]);
                    sb.Append($"{friends_count[Find(inputs[0])]} \n");
                }
            }

            Console.Write( sb.ToString() );
            Console.ReadKey();
        }
    }
}
