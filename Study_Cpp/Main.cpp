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