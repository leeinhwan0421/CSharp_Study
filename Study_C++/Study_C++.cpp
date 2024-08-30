﻿/*
    위 프로젝트를 생성한 이유는, C#으로 풀기 힘든 문제를 C++로 풀 수 있게 하기 위해서 입니다.
    한 언어에 종속된 프로그래머가 아닌, 많은 언어를 다채롭게 사용할 수 있는 개발자가 되도록 노력하겠습니다.

    위 프로젝트에서 해결한 문제들 

    // =================================================== //
    https://www.acmicpc.net/problem/1854
    K번째 최단 경로 찾기 (예정)

    C#으로 최대한 구현하려 했으나, 제 실력 부족으로 메모리 초과와 시간초과가 출력되었습니다. 
    사실 .NET 8.0을 사용하면 되는데 
    .NET Framework 4.8 버전을 사용해야만 위 프로젝트에서 인식이 되기떄문에..
    불가피하게 C++로 풀게 되었습니다.
    // =================================================== //
*/

#include <iostream>
#include <vector>
#include <queue>

using namespace std;

typedef pair<int, int> Node;

static int N;
static int M;
static int K;

static int W[1001][1001];

static priority_queue<int> distQueue[1001];

int main()
{
    ios::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    cin >> N >> M >> K;

    for (int i = 0; i < M; i++)
    {
        int a, b, c;

        cin >> a >> b >> c;

        W[a][b] = c;
    }

    priority_queue<Node, vector<Node>, greater<Node>> pq;
    pq.push(make_pair(0, 1));
    distQueue[1].push(0);

    while (!pq.empty())
    {
        auto u = pq.top();
        pq.pop();

        for (int adjNode = 1; adjNode <= N; adjNode++)
        {
            if (W[u.second][adjNode] != 0)
            {
                if (distQueue[adjNode].size() < K)
                {
                    distQueue[adjNode].push(u.first + W[u.second][adjNode]);
                    pq.push(make_pair(u.first + W[u.second][adjNode], adjNode));
                }
                else if (distQueue[adjNode].top() > u.first + W[u.second][adjNode])
                {
                    distQueue[adjNode].pop();
                    distQueue[adjNode].push(u.first + W[u.second][adjNode]);
                    pq.push(make_pair(u.first + W[u.second][adjNode], adjNode));
                }
            }
        }
    }

    for (int i = 1; i <= N; i++)
    {
        if (distQueue[i].size() == K)
        {
            cout << distQueue[i].top() << "\n";
        }
        else
        {
            cout << "-1" << "\n";
        }
    }
}
    
