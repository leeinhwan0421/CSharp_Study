# CSharp_Study
C# 공부 + 백준 문제풀이  

# 📝 알고리즘 및 문제풀이  
알고리즘에 대한 이해가 부족하기 때문에, 알고리즘 공부 하면서 현황을 업로드 하도록 하겠습니다.

# 🧭 진행 현황
<details>
<summary>2023.09</summary>
<div markdown="1">
	
09.11 백준  
09.12 백준  
09.13 백준  
09.14 백준 & Sorting Algorithm  
09.15 백준 & DFS, BFS  
09.18 백준 & Binary Search  
09.19 백준 & Greedy Algorithm  
09.20 백준 & Number Theory  
09.21 백준  
09.26 백준 & Tree

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

## 풀이 중..

</div>
</details>
