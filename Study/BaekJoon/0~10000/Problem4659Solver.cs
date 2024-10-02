using System;
using System.Linq;
using System.Text;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/4659
    // 비밀번호 발음하기
    internal class Problem4659Solver
    {
        static public void Solve()
        {
            StringBuilder sb = new StringBuilder();
            string vowels = "aeiou"; // 모음

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                    break;

                bool rule1 = false; 
                bool rule2 = true; 
                bool rule3 = true;

                int vowelCount = 0;   
                int consonantCount = 0;
                char prevChar = ' ';

                for (int i = 0; i < input.Length; i++)
                {
                    char current = input[i];

                    if (vowels.Contains(current))
                    {
                        rule1 = true; 
                        vowelCount++;
                        consonantCount = 0;
                    }
                    else
                    {
                        consonantCount++;
                        vowelCount = 0;
                    }

                    if (vowelCount >= 3 || consonantCount >= 3)
                    {
                        rule2 = false;
                    }

                    if (i > 0 && current == prevChar && current != 'e' && current != 'o')
                    {
                        rule3 = false;
                    }

                    prevChar = current;
                }

                if (rule1 && rule2 && rule3)
                {
                    sb.AppendLine($"<{input}> is acceptable.");
                }
                else
                {
                    sb.AppendLine($"<{input}> is not acceptable.");
                }
            }

            Console.Write(sb.ToString());
            
        }
    }
}
