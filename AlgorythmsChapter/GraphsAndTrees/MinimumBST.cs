namespace AlgorythmsChapter.GraphsAndTrees
{
    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }

    public class MinimumBST
    {
        public Node BuildMinimumBst(int[] array, int begin, int end)
        {
            if (end < begin)
            {
                return new Node();
            }

            var mid = (begin + end) / 2;
            var midElement = array[mid];
            var treeNode = new Node
            {
                Data = midElement,
                LeftNode = BuildMinimumBst(array, begin, mid - 1),
                RightNode = BuildMinimumBst(array, mid + 1, end)
            };

            return treeNode;
        }

        public List<LinkedList<Node>> CreateLeveledLinkedlist(Node? root)
        {
            var result = new List<LinkedList<Node>>();
            if (root == null)
            {
                return null;
            }

            var currentList = new LinkedList<Node>();
            currentList.AddLast(root); // 0 level

            while (currentList.Count > 0)
            {
                var parents = currentList;
                result.Add(parents);
                currentList = new LinkedList<Node>();
                foreach (var parent in parents)
                {
                    if (parent.LeftNode != null)
                    {
                        currentList.AddLast(parent.LeftNode);
                    }

                    if (parent.RightNode != null)
                    {
                        currentList.AddLast(parent.RightNode);
                    }
                }
            }

            return result;
        }
    }
}
