using System;
using System.Collections.Generic;

namespace Study.BaekJoon
{
    internal class Problem1991Solver
    {
        internal class BinaryTree
        {
            public class Node
            {
                public char Data { get; set; }
                public Node Left { get; set; }
                public Node Right { get; set; }

                public Node(char data)
                {
                    Data = data;
                    Left = Right = null;
                }
            }

            private Node _root;

            public void Insert(char parentData, char leftData, char rightData)
            {
                if (_root == null)
                {
                    _root = new Node(parentData);
                    if (leftData != '.') _root.Left = new Node(leftData);
                    if (rightData != '.') _root.Right = new Node(rightData);
                }
                else
                {
                    Insert(_root, parentData, leftData, rightData);
                }
            }

            private void Insert(Node node, char parentData, char leftData, char rightData)
            {
                if (node == null) return;
                if (node.Data == parentData)
                {
                    if (leftData != '.') node.Left = new Node(leftData);
                    if (rightData != '.') node.Right = new Node(rightData);
                }
                else
                {
                    Insert(node.Left, parentData, leftData, rightData);
                    Insert(node.Right, parentData, leftData, rightData);
                }
            }

            public void Preorder() => Preorder(_root);
            private void Preorder(Node node)
            {
                if (node == null) return;
                Console.Write(node.Data);
                Preorder(node.Left);
                Preorder(node.Right);
            }

            public void Inorder() => Inorder(_root);
            private void Inorder(Node node)
            {
                if (node == null) return;
                Inorder(node.Left);
                Console.Write(node.Data);
                Inorder(node.Right);
            }

            public void Postorder() => Postorder(_root);
            private void Postorder(Node node)
            {
                if (node == null) return;
                Postorder(node.Left);
                Postorder(node.Right);
                Console.Write(node.Data);
            }
        }

        public static void Solve()
        {
            int n = int.Parse(Console.ReadLine());
            BinaryTree tree = new BinaryTree();

            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                char parent = inputs[0][0];
                char left = inputs[1][0];
                char right = inputs[2][0];

                tree.Insert(parent, left, right);
            }

            tree.Preorder();
            Console.WriteLine();
            tree.Inorder();
            Console.WriteLine();
            tree.Postorder();

            Console.ReadKey();
        }
    }
}
