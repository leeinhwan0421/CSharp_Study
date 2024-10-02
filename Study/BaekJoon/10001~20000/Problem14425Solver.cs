using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/14425
    // 문자열 집합
    // Trie 사용해서 어렵게 풀 예정

    internal class Problem14425Solver
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children;
            public bool IsEndOfWord;

            public TrieNode()
            {
                Children = new Dictionary<char, TrieNode>();
                IsEndOfWord = false;
            }
        }

        public class Trie
        {
            private readonly TrieNode root;

            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {
                TrieNode currentNode = root;

                foreach (char ch in word)
                {
                    if (currentNode.Children.ContainsKey(ch) == false)
                    {
                        currentNode.Children[ch] = new TrieNode();
                    }

                    currentNode = currentNode.Children[ch];
                }

                currentNode.IsEndOfWord = true;
            }

            public bool Search(string word)
            {
                TrieNode currentNode = root;

                foreach (char ch in word)
                {
                    if (currentNode.Children.ContainsKey(ch) == false)
                    {
                        return false;
                    }

                    currentNode = currentNode.Children[ch];
                }

                return currentNode.IsEndOfWord;
            }

            public bool SearchWord(string word)
            {
                TrieNode currentNode = root;

                foreach (char ch in word)
                {
                    if (currentNode.Children.ContainsKey(ch) == false)
                    {
                        return false;
                    }

                    currentNode = currentNode.Children[ch];
                }

                return true;
            }
        }

        static public void Solve()
        {
            Trie trie = new Trie();

            string[] inputs = Console.ReadLine().Split(' ');

            int N = int.Parse(inputs[0]);
            int M = int.Parse(inputs[1]);

            for (int i = 0; i < N; i++)
            {
                trie.Insert(Console.ReadLine());
            }

            int result = 0;
            for (int i = 0; i < M; i++)
            {
                if (trie.Search(Console.ReadLine()))
                {
                    result++;
                }
            }

            Console.Write(result);
            
        }
    }
}
