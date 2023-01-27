using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AlgorythmsChapter.BinaryTreeFolders;

using DataStructures;

using Xunit;

namespace TestAlgorythmsProject
{
    public class PostOrderTraversalTests
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
            var postOrderList = traverser.PostOrderNonRecursiveWithTwoStacks(node1);

            Assert.Equal(new[] { 3, 2, 1 }, postOrderList);
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
            var postOrderList = traverser.PostOrderNonRecursiveWithTwoStacks(node2);

            Assert.Equal(new[] { 1, 3, 2 }, postOrderList);
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
            var postOrderList = traverser.PostOrderNonRecursiveWithTwoStacks(node3);

            Assert.Equal(new[] { 1, 2, 3 }, postOrderList);
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
            var postOrderList = traverser.PostOrderNonRecursiveWithTwoStacks(node1);

            Assert.Equal(new[] { 3, 2, 1 }, postOrderList);
        }

        [Fact]
        public void Failed_case()
        {
            var node1 = new TreeNode<int>(1);
            var node2 = new TreeNode<int>(2);
            var node3 = new TreeNode<int>(3);
            var node4 = new TreeNode<int>(4);

            node1.Left = node4;
            node1.Right = node3;
            node4.Left = node2;

            var traverser = new BinaryTreeTraversal<int>();
            var postOrderList = traverser.PostOrderNonRecursiveWithTwoStacks(node1);

            Assert.Equal(new[] { 2, 4, 3, 1 }, postOrderList);
        }
    }
}
