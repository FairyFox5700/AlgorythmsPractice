using DataStructures;

namespace AlgorythmsChapter.BinaryTreeFolders
{
    public class BinaryTreeTraversal<T> where T : IComparable<T>
    {
        //pre = root, left, right
        public void PreOrder(TreeNode<T>? root)
        {
            if (root == null) return;
            Console.WriteLine(root);
            PreOrder(root.Left);
            PreOrder(root.Right);
        }

        /*To simulate the same, first we process
      the current node and before going to the left subtree, we store the current node on stack.After
      completing the left subtree processing, pop the element and go to its right subtree.Continue this
      process until stack is nonempty*/


        public List<T> PreOrderNonRecursive(TreeNode<T>? root)
        {
            var list = new List<T>();
            var stack = new Stack<TreeNode<T>>();
            while (true)
            {
                while (root != null)
                {
                    list.Add(root.Value);
                    stack.Push(root);
                    root = root.Left;
                }

                if (!stack.Any())
                    break;
                root = stack.Pop();
                root = root.Right;
            }

            return list;
        }

        //The Non-recursive version of Inorder traversal is similar to Preorder.The only change is, instead
        //   of processing the node before going to left subtree, process it after popping(which is indicated
        //   after completion of left subtree processing).

        //in = left, root, right
        public void InOrder(TreeNode<T>? root)
        {
            if (root == null) return;
            PreOrder(root.Left);
            Console.WriteLine(root);
            PreOrder(root.Right);
        }

        public List<T> InOrderNonRecursive(TreeNode<T>? root)
        {
            var list = new List<T>();
            var stack = new Stack<TreeNode<T>>();
            while (true)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }

                if (!stack.Any())
                {
                    break;
                }

                root = stack.Pop();
                list.Add(root.Value);
                root = root.Right;
            }

            return list;
        }


        //post = left, right, root
        public void PostOrder(TreeNode<T>? root)
        {
            if (root == null) return;
            PreOrder(root.Left);
            PreOrder(root.Right);
            Console.WriteLine(root);
        }

        /*Postorder traversal without recursion using 2 stacks*/
        /*1. Push root to first stack.
        2. Loop while first stack is not empty
        2.1 Pop a node from first stack and push it to second stack
        2.2 Push left and right children of the popped node to first stack
        3. Print contents of second stack*/

        public List<T> PostOrderNonRecursiveWithTwoStacks(TreeNode<T> root)
        {
            var stackFirst = new Stack<TreeNode<T>>();
            var stackSecond = new Stack<TreeNode<T>>();
            var list = new List<T>();
            stackFirst.Push(root);
            while (stackFirst.Any())
            {
                var popped = stackFirst.Pop();
                stackSecond.Push(popped);
                if (popped.Left != null)
                    stackFirst.Push(popped.Left);
                if (popped.Right != null)
                    stackFirst.Push(popped.Right);
            }

            while (stackSecond.Any())
            {
                var popped = stackSecond.Pop();
                list.Add(popped.Value);
            }

            return list;
        }

        /*1.1 Create an empty stack
2.1 Do following while root is not NULL
    a) Push root's right child and then root to stack.
    b) Set root as root's left child.
2.2 Pop an item from stack and set it as root.
    a) If the popped item has a right child and the right child
       is at top of stack, then remove the right child from stack,
       push the root back and set root as root's right child.
    b) Else print root's data and set root as NULL.
2.3 Repeat steps 2.1 and 2.2 while stack is not empty.*/
        public List<T> PostOrderNonRecursiveWithOneStacks(TreeNode<T> root)
        {
            var stack = new Stack<TreeNode<T>>();
            var list = new List<T>();
            while (true)
            {
                while (root != null)
                {
                    stack.Push(root);
                    stack.Push(root);
                    root = root.Left;
                }

                if (!stack.Any())
                    break;

                root = stack.Pop();
                if (stack.Any() && root == stack.Peek())
                {
                    root = root.Right;
                }
                else
                {
                    list.Add(root.Value);
                    root = null;
                }
            }

            return list;
        }
        /* Visit the root.
• While traversing level (, keep all the elements at level ( + 1 in queue.
• Go to the next level and visit all the nodes at that level.
• Repeat this until all levels are completed.*/
        public List<T> LevelOrderTraversal(TreeNode<T> root)
        {
            var list = new List<T>();
            var quesue = new Queue<TreeNode<T>>();
            quesue.Enqueue(root);
            while (quesue.Any())
            {
                root = quesue.Dequeue();
                list.Add(root.Value);
                if (root.Left != null)
                {
                    quesue.Enqueue(root.Left);
                }
                if (root.Right != null)
                {
                    quesue.Enqueue(root.Right);
                }
            }
            return list;
        }
    }
}
