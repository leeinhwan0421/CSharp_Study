using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Programmers
{
    // https://school.programmers.co.kr/learn/courses/30/lessons/178871

    internal class Lessons178871Solver
    {
        public string[] solution(string[] players, string[] callings)
        {
            Dictionary<string, int> playerDict = new Dictionary<string, int>();

            for (int i = 0; i < players.Length; i++)
            {
                playerDict.Add(players[i], i);
            }

            foreach (string call in callings)
            {
                int currentIndex = playerDict[call];

                if (currentIndex > 0)
                {
                    string temp = players[currentIndex - 1];
                    players[currentIndex - 1] = call;
                    players[currentIndex] = temp;

                    playerDict[call] = currentIndex - 1;
                    playerDict[temp] = currentIndex;
                }
            }

            return players;
        }
    }
}
