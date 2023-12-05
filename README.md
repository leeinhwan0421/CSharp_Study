# CSharp_Study
C# 공부 + 백준 문제풀이  

# 📝 알고리즘 및 문제풀이  
알고리즘에 대한 이해가 부족하기 때문에, 알고리즘 공부 하면서 현황을 업로드 하도록 하겠습니다.

# 🧭 진행 현황
<details>
<summary>2023.09</summary>
<div markdown="1">
	
- **09.11** 백준  
- **09.12** 백준  
- **09.13** 백준  
- **09.14** 백준 & Sorting Algorithm  
- **09.15** 백준 & DFS, BFS  
- **09.18** 백준 & Binary Search  
- **09.19** 백준 & Greedy Algorithm  
- **09.20** 백준 & Number Theory  
- **09.21** 백준  
- **09.26** 백준 & Tree  
- **09.27** 백준 & Graph

</div>
</details>
<details>
<summary>2023.10</summary>
<div markdown="1">
	
- **10.04** 백준 복습 ( 노트 정리 )  
- **10.05** Solved.ac Class 3*  
- **10.06** Union, Find  
- **10.10** topology sort, bitmasking  
- **10.11** 시리얼 통신, 파일 입출력, 청크 로더  
- **10.17** 위상 정렬 1   
- **10.18** 위상 정렬 2  
- **10.20** Solved.ac Class 4  
- **10.23** Solved.ac Class 4

</div>
</details>
<details>
<summary>2023.11</summary>
<div markdown="1">
	
- **11.01 ~ 11.30** C++ DX12 공부

</div>
</details>
<details>
<summary>2023.12</summary>
<div markdown="1">
	
- **12.01 ~ 12.21** C++ DX12 공부  
- **12.05** DP  
- **12.21 ~ 01.11** 전문산업기능군사교육소집기간

</div>
</details>

# ❌ 풀지 못한 문제
<details>
<summary>https://www.acmicpc.net/problem/11003, 최소값 찾기, 시간 초과</summary>
<div markdown="1">

## C++ 풀이
  
```cpp
#include <iostream>
#include <deque>

using namespace std;
typedef pair<int, int> Node;

int main()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	int n, l;
	cin >> n >> l;

	deque<Node> m_deque;

	for (int i = 0; i < n; i++)
	{
		int nw;
		cin >> nw;

		while (!m_deque.empty() && m_deque.back().first > nw)
		{
			m_deque.pop_back();
		}

		m_deque.push_back(make_pair(nw, i));

		if (m_deque.front().second <= i - l)
		{
			m_deque.pop_front();
		}

		cout << m_deque.front().first << ' ';
	}

	return 0;
}
```

</div>
</details>

<details>
<summary>https://www.acmicpc.net/problem/7576, 토마토, 시간 초과</summary>
<div markdown="1">

## C# 풀이, 기존 FloodFill 알고리즘에서, BFS를 활용해서 풀이

```cs
using System;
using System.Collections.Generic;
using System.IO;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/7576
    // 토마토

    // FloodFill로 풀었는데 잘 안되서
    // BFS 형식으로 코드를 바꿔봤습니다.
    // 제발돼라

    internal class Problem7576Solver
    {
        static int[,] arr;
        static int rows;
        static int cols;
        static int[] dx = { 1, -1, 0, 0 };
        static int[] dy = { 0, 0, 1, -1 };

        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            String[] str = sr.ReadLine().Split(' ');

            rows = int.Parse(str[0]);
            cols = int.Parse(str[1]);

            arr = new int[cols, rows];
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

            for (int i = 0; i < cols; i++)
            {
                String[] line = sr.ReadLine().Split(' ');

                for (int j = 0; j < rows; j++)
                {
                    arr[i, j] = int.Parse(line[j]);

                    if (arr[i, j] == 1)
                    {
                        queue.Enqueue(new Tuple<int, int>(i, j));
                    }
                }
            }

            int days = BFS(queue);

            if (CheckAllRipe())
            {
                Console.Write(days);
            }
            else
            {
                Console.Write("-1");
            }

            Console.ReadKey();
        }

        static int BFS(Queue<Tuple<int, int>> queue)
        {
            int days = -1;

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    Tuple<int, int> tomato = queue.Dequeue();
                    int x = tomato.Item1;
                    int y = tomato.Item2;

                    for (int j = 0; j < 4; j++)
                    {
                        int nx = x + dx[j];
                        int ny = y + dy[j];

                        if (nx >= 0 && nx < cols && ny >= 0 && ny < rows && arr[nx, ny] == 0)
                        {
                            arr[nx, ny] = 1;
                            queue.Enqueue(new Tuple<int, int>(nx, ny));
                        }
                    }
                }

                days++;
            }

            return days;
        }

        static bool CheckAllRipe()
        {
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

```

</div>
</details>
