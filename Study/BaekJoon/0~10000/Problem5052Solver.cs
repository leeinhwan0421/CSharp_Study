using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.BaekJoon
{
    // https://www.acmicpc.net/problem/5052
    // 전화번호 목록

    internal class Problem5052Solver
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

                    if (currentNode.Children[ch].IsEndOfWord)
                    {
                        return true;
                    }

                    currentNode = currentNode.Children[ch];
                }

                return true;
            }
        }

        static public void Solve()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());

                Trie trie = new Trie();
                List<string> arr = new List<string>();

                for (int j = 0; j < N; j++)
                {
                    arr.Add(sr.ReadLine());
                }

                arr.Sort();

                bool consistency = true;
                for (int j = 0; j < N; j++)
                {
                    if (trie.SearchWord(arr[j]))
                    {
                        consistency = false;
                        break;
                    }

                    trie.Insert(arr[j]);
                }

                if (consistency)
                {
                    sb.Append("YES\n");
                }
                else
                {
                    sb.Append("NO\n");
                }
            }

            sw.Write( sb.ToString() );
            sw.Flush();

            sw.Close();
            sr.Close();

            Console.ReadKey();
        }
    }
}
