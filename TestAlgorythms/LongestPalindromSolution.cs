using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlgorythms
{
    public class ProductExceptSelfSolution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var newArray = new int[nums.Length];
            var index = 0;
            for (int l = 0; l < nums.Length; l++)
            {
                var product = 1;
                if (l == index)
                {
                    break;
                }
                else
                {
                    product *= nums[l];
                }
            }

            index++;
        }
    }

    public class MaxProfitSolution
    {
        public int MaxProfit(int[] prices)
        {
            var maxProfit = 0;
            var buy = int.MaxValue;
            for (int i = 0; i < prices.Length; i++)
            {
                if (buy > prices[i])
                {
                    buy = prices[i];
                }
                else if (prices[i] - buy > maxProfit)
                {
                    maxProfit = prices[i] - buy;
                }
            }

            return maxProfit;
        }
    }
    public class SumNumbersSolution
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public int SumNumbers(TreeNode root)
        {
            return SumNumbersInternal(root, 0);
        }



        private int SumNumbersInternal(TreeNode root, int valueCurrent)
        {
            if (root == null)
            {
                return 0;
            }


            valueCurrent = valueCurrent * 10 + root.val;
            if (root.right == null && root.left == null)
            {
                return valueCurrent;
            }
            return (SumNumbersInternal(root.left, valueCurrent) + SumNumbersInternal(root.right, valueCurrent));
        }
    }
    public class MinimumTotalSolution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var dp = new int[triangle[^1].Count + 1];

            for (int j = triangle.Count - 1; j >= 0; j--)
            {
                var items = triangle[j];
                for (int i = 0; i < items.Count; i++)
                {
                    dp[i] = items[i] + Math.Min(dp[i], dp[i + 1]);
                }
            }
            return dp[0];
        }
    }


    public class ValidBSTSolution
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public bool IsValidBST(TreeNode root)
        {
            var result = true;
            //check root
            result &= IsValidBSTInternal(root, double.MaxValue, double.MinValue);
            return result;
        }

        private bool IsValidBSTInternal(TreeNode root, double rightBound, double leftBound)
        {
            var result = true;
            if (root == null)
            {
                return true;
            }
            if (root.val >= rightBound || root.val <= leftBound)
            {
                return false;
            }
            result &= IsValidBSTInternal(root.left, root.val, leftBound);// must be lower then root
            result &= IsValidBSTInternal(root.right, rightBound, root.val);// must be greater then root
            return result;
        }
    }

    public class SortedArrayToBSTSolution
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortToBSTInternal(nums, 0, nums.Length - 1);
        }

        private TreeNode SortToBSTInternal(int[] nums, int begining, int end)
        {
            if (begining > end)
                return null;
            var mid = (begining + end) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = SortToBSTInternal(nums, begining, mid - 1);
            node.right = SortToBSTInternal(nums, mid + 1, end);
            return node;
        }
    }

    public class MergeTreesSolution
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            var val = 0;
            if (root1 == null && root2 == null)
            {
                return null;
            }
            if (root1 == null)
            {
                val = root2.val;

            }

            if (root2 == null)
            {
                val = root1.val;
            }

            if (root1 != null && root2 != null)
            {
                val = root1.val + root2.val;
            }

            var newNode = new TreeNode(val);
            var left = MergeTrees(root1?.left, root2?.left);
            var right = MergeTrees(root1?.right, root2?.right);
            newNode.left = left;
            newNode.right = right;
            return newNode;
        }
    }

    public class InvertTreeSolution
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            (root.right, root.left) = (root.left, root.right);

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }
    }
    public class GoodNodesSolution
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public int GoodNodes(TreeNode root)
        {
            return DFS(root, Int32.MinValue);
        }

        private int DFS(TreeNode root, int maxVal)
        {
            if (root == null)
            {
                return 0;
            }

            int count = 0;
            if (root.val >= maxVal)
            {
                maxVal = root.val;
                count += 1;
            }

            count += DFS(root.left, maxVal);
            count += DFS(root.right, maxVal);
            return count;
        }

        public class BalancedTReeSolution
        {

            public class TreeNode
            {
                public int val;
                public TreeNode left;
                public TreeNode right;
                public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
                {
                    this.val = val;
                    this.left = left;
                    this.right = right;
                }
            }

            public bool IsBalanced(TreeNode root)
            {
                return DFS(root).Item1;
            }


            //pre order traversal
            (bool, int) DFS(TreeNode? node)
            {
                if (node == null)
                {
                    return (true, 0);
                }
                var left = DFS(node.left);
                var right = DFS(node.right);


                var balanced = left.Item1 && right.Item1 && Math.Abs(left.Item2 - right.Item2) <= 1;
                return (balanced, 1 + Math.Max(left.Item2, right.Item2));
            }
        }
    }
    public class NetworkDelayTimeSolution
    {

        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        private int[] visited;

        private Dictionary<int, List<(int, int)>> edges = new Dictionary<int, List<(int, int)>>();
        public int NetworkDelayTime(int[][] times, int n, int k)
        {

            foreach (var time in times)
            {
                if (!edges.ContainsKey(time[0]))
                {
                    edges[time[0]] = new List<(int, int)>();
                }
                edges[time[0]].Add((time[1], time[2]));
            }

            visited = new int[n];
            var val = 0;
            for (int i = 0; i < times.Length; i++)
            {
                pq.Enqueue(times[i][0], times[i][2]);
                val = Diykstra(val);
            }
            return (pq.Count == n) ? val : -1;
        }

        //O(e*logV)
        public int Diykstra(int valPassed)
        {
            while (pq.Count > 0)
            {
                pq.TryDequeue(out int val, out int priorityval); ;
                if (visited != null && visited[val] != 1)
                {
                    visited[val] = 1;
                    val = Math.Max(valPassed, priorityval);
                }

                if (edges.ContainsKey(val))
                {
                    foreach (var (adjItem, adjPriority) in edges[val])
                    {
                        if (visited[adjItem] != 1)
                        {
                            pq.Enqueue(adjItem, adjPriority + priorityval);
                        }
                    }
                }
            }

            return valPassed;
        }
    }


    public class PacificAtlanticFlow
    {
        HashSet<(int, int)> visited = new HashSet<(int, int)>();
        HashSet<(int, int)> visited2 = new HashSet<(int, int)>();

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            // bfs from left
            // bfs from bottom

            int row = heights.Length;
            int column = heights[0].Length;

            for (int c = 0; c < column; c++)
            {
                // starting from top row
                DFS(0, c, heights, visited, Int32.MinValue);
                //starting from end row
                DFS(row - 1, c, heights, visited2, Int32.MinValue);
            }

            for (int r = 0; r < row; r++)
            {
                // starting from first colomn to the east
                DFS(r, 0, heights, visited, Int32.MinValue);
                //starting from end colomn to the west
                DFS(r, column - 1, heights, visited2, Int32.MinValue);
            }


            IList<IList<int>> result = new List<IList<int>>();
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    if (visited.Contains((r, c)) && visited2.Contains((r, c)))
                    {

                        IList<int> Coordinate = new List<int>();
                        Coordinate.Add(r);
                        Coordinate.Add(c);
                        result.Add(Coordinate);
                    }
                }
            }

            return result;
        }

        public void DFS(int r, int c, int[][] heights, HashSet<(int, int)> visited2, int prevHeights)
        {
            if (r >= 0 && r < heights.Length
                       && c >= 0 && heights[0].Length > c
                       && !visited2.Contains((r, c))
                       && heights[r][c] >= prevHeights)
            {
                visited2.Add((r, c));
                DFS(r, c + 1, heights, visited2, heights[r][c]);
                DFS(r, c - 1, heights, visited2, heights[r][c]);
                DFS(r + 1, c, heights, visited2, heights[r][c]);
                DFS(r - 1, c, heights, visited2, heights[r][c]);
            }
        }
    }


    internal class LongestPalindromSolution
    {
        public int LongestPalindrome(string s)
        {
            HashSet<char> mySet = new HashSet<char>();
            var len = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (mySet.Contains(s[i]))
                {
                    mySet.Remove(s[i]);
                    len += 2;
                }
                else mySet.Add(s[i]);
            }

            if (mySet.Count > 0)
                return len + 1;
            return len;
        }
    }

    public class NumberOfIslands
    {
        private HashSet<(int, int)> visisted = new();
        private Queue<(int, int)> queue = new Queue<(int, int)>();

        public int NumIslands(char[][] grid)
        {
            var count = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {

                    if (!visisted.Contains((r, c)) && grid[r][c] == '1')
                    {

                        queue.Enqueue((r, c));
                        visisted.Add((r, c));
                        BFS(grid);
                        count += 1;
                    }

                }
            }

            return count;
        }

        public void BFS(char[][] grid)
        {
            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();
                var directions = new List<(int, int)>()
                {
                    (r, c + 1),
                    (r, c - 1),
                    (r + 1, c),
                    (r - 1, c)
                };

                foreach (var (dr, dc) in directions)
                {
                    r = dr;
                    c = dc;
                    if (r >= 0 && r < grid.Length
                               && c >= 0 && c < grid[0].Length
                               && grid[r][c] == '1'
                               && !visisted.Contains((r, c)))
                    {
                        queue.Enqueue((r, c));
                        visisted.Add((r, c));
                    }
                }
            }
        }
    }
}
