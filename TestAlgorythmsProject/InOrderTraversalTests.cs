using AlgorythmsChapter.BinaryTreeFolders;

using DataStructures;

using Xunit;

namespace TestAlgorythmsProject
{
    public class InOrderTraversalTests
    {
        [Fact]
        public void Basic()
        {
            var node1 = new TreeNode<int>(1);
            var node2 = new TreeNode<int>(2);
            var node3 = new TreeNode<int>(3);

            node1.Right = node2;
            node2.Left = node3;

            var traverser = new BinaryTreeTraversal<int>();
            var inorderList = traverser.InOrderNonRecursive(node1);

            Assert.Equal(new[] { 1, 3, 2 }, inorderList);
        }


        [Fact]
        public void Balanced()
        {
            var node1 = new TreeNode<int>(1);
            var node2 = new TreeNode<int>(2);
            var node3 = new TreeNode<int>(3);

            node2.Left = node1;
            node2.Right = node3;

            var traverser = new BinaryTreeTraversal<int>();
            var inorderList = traverser.InOrderNonRecursive(node2);

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }

        [Fact]
        public void Left_chain()
        {
            var node1 = new TreeNode<int>(1);
            var node2 = new TreeNode<int>(2);
            var node3 = new TreeNode<int>(3);

            node2.Left = node1;
            node3.Left = node2;

            var traverser = new BinaryTreeTraversal<int>();
            var inorderList = traverser.InOrderNonRecursive(node3);

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }



        [Fact]
        public void Right_chain()
        {
            var node1 = new TreeNode<int>(1);
            var node2 = new TreeNode<int>(2);
            var node3 = new TreeNode<int>(3);

            node1.Right = node2;
            node2.Right = node3;

            var traverser = new BinaryTreeTraversal<int>();
            var inorderList = traverser.InOrderNonRecursive(node1);

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }
    }
}
