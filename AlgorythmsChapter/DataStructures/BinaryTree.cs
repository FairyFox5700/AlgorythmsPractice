using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.DataStructures
{

    public class Node
    {
        public int Key { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }
    }

    public class BinaryTree
    {
        public Node? Root { get; set; }

        /* Given a binary tree, print
           its nodes in inorder*/
        public void PrintInOrder(Node? node)
        {
            if (node == null)
            {
                return;
            }

            PrintInOrder(node.Left);
            Console.WriteLine(node.Key);
            PrintInOrder(node.Right);
        }

        /* Given a binary tree, print
           its nodes according to the
           "bottom-up" postorder traversal. */
        /*Algorithm Postorder(tree)
        1. Traverse the left subtree, i.e., call Postorder(left-subtree)
        2. Traverse the right subtree, i.e., call Postorder(right-subtree)
        3. Visit the root.*/

        public void PrintPostOrder(Node? node)
        {
            if (node == null)
            {
                return;
            }

            PrintInOrder(node.Left);
            PrintInOrder(node.Right);
            Console.WriteLine(node.Key);

        }

        /*Algorithm Preorder(tree)
            1. Visit the root.
        2. Traverse the left subtree, i.e., call Preorder(left-subtree)
            3. Traverse the right subtree, i.e., call Preorder(right-subtree)*/
        public void PrintPreOrder(Node? node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Key);
            PrintInOrder(node.Left);
            PrintInOrder(node.Right);

        }

        public void PrintInOrderWithStack(Node? node)
        {
            if (node == null)
            {
                return;
            }

            var stack = new Stack<Node>();
            var current = Root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                var fromStack = stack.Pop();
                Console.WriteLine(fromStack.Key);
                current = fromStack.Right;
            }
        }

        /* Function to traverse binary tree without
            recursion and without stack */
        //TODO
        public void PrintInOrderSimple(Node? node)
        {
            if (node == null)
            {
                return;
            }

            var current = Root;
            if (current?.Left == null)
            {
                Console.WriteLine(current?.Key);
                current = current?.Right;
            }
            else
            {

            }
        }
    }

}
