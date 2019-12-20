using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice.Implementations.BinarySearchTree
{
    class BinarySearchTree
    {
        public class Node<T>{
            public T Value;
            public Node<T> Left;
            public Node<T> Right;

            public Node(T value)
            {
                Value = value;
            }
        }

        public class Tree<T> where T : int
        {
            public Node<T> Root;

            public Tree(Node<T> root)
            {
                Root = root;
            }

            public void Insert(T value)
            {
                Root = Insert(null, value);
            }

            private Node<T> Insert(Node<T> root, T value)
            {
                if (root == null)
                {
                    root = new Node<T>(value);
                }
                else if (root.Value > value)
                {

                }
            }
        }
    }
}
