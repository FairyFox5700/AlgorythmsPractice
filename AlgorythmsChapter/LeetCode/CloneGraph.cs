using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.LeetCode
{

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }


    public class SolutionCloneGraph
    {
        private Dictionary<int, Node> hashSet = new Dictionary<int, Node>();
        public Node CloneGraph(Node node)
        {
            if (node == null) return null;
            var clone = new Node(node.val);
            hashSet.Add(node.val, clone);
            foreach (var neighbour in node.neighbors)
            {
                if (hashSet.ContainsKey(neighbour.val))
                {
                    clone.neighbors.Add(hashSet[neighbour.val]);
                }
                else
                {
                    clone.neighbors.Add(CloneGraph(neighbour));
                }
            }

            return clone;
        }
    }
}
