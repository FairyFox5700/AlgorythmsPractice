using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorythms
{

        public static class SumOfNodesAtMinLevel
        {

            // structure of a node of binary tree
            class Node
            {
                public int data;
                public Node left, right;
            };

            // function to get a new node
            static Node getNode(int data)
            {
                // allocate space
                Node newNode = new Node();

                // put in the data
                newNode.data = data;
                newNode.left = newNode.right = null;
                return newNode;
            }



            // function to find the sum of
            // leaf nodes at minimum level
            static int sumOfLeafNodesAtMinLevel(Node root)
            {
                // if tree is empty
                if (root == null)
                    return 0;

                // if there is only one node
                if (root.left == null &&
                    root.right == null)
                    return root.data;

                // queue used for level order traversal
                Queue<Node> q = new Queue<Node>();
                int sum = 0;
                bool f = false;

                // push root node in the queue 'q'
                q.Enqueue(root);

                while (f == false)
                {

                    // count number of nodes in the
                    // current level
                    int nc = q.Count;

                    // traverse the current level nodes
                    while (nc-- > 0)
                    {

                        // get front element from 'q'
                        Node top = q.Peek();
                        q.Dequeue();

                        // if it is a leaf node
                        if (top.left == null &&
                            top.right == null)
                        {

                            // accumulate data to 'sum'
                            sum += top.data;

                            // set flag 'f' to 1, to signify
                            // minimum level for leaf nodes
                            // has been encountered
                            f = true;
                        }
                        else
                        {

                            // if top's left and right child
                            // exists, then push them to 'q'
                            if (top.left != null)
                                q.Enqueue(top.left);
                            if (top.right != null)
                                q.Enqueue(top.right);
                        }
                    }
                }

                // required sum
                return sum;
            }

            // Driver Code
            public static void SumOfNodes()
            {

                // binary tree creation
                Node root = getNode(1);
                root.left = getNode(2);
                root.right = getNode(3);
                root.left.left = getNode(4);
                root.left.right = getNode(5);
                root.right.left = getNode(6);
                root.right.right = getNode(7);
                root.left.right.left = getNode(8);
                root.right.left.right = getNode(9);

                Console.WriteLine("Sum = " +
                        sumOfLeafNodesAtMinLevel(root));
            }
        }
    }
