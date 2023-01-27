using DataStructures;

namespace AlgorythmsChapter.GraphFolders
{
    public class TopologicalSort<T> where T : IEquatable<T>, IComparable<T>
    {
        public void TopologicalSortFuncInternal(AdjacentListDirectedGraph<T> graph,
            HashSet<GraphNode<T>> visited,
            Stack<GraphNode<T>> stack,
            GraphNode<T> vertex)
        {
            visited.Add(vertex);
            foreach (var adjacent in graph.AdjacencyList[vertex])
            {
                if (!visited.Contains(adjacent))
                    TopologicalSortFuncInternal(graph, visited, stack, adjacent);
            }

            stack.Push(vertex);
        }

        public List<T> TopologicalSortFuncRecursive(AdjacentListDirectedGraph<T> graph, GraphNode<T> vertex)
        {
            var ordering = new List<T>();
            var visitedVertexes = new HashSet<GraphNode<T>>();
            var stack = new Stack<GraphNode<T>>();

            TopologicalSortFuncInternal(graph, visitedVertexes, stack, vertex);

            while (stack.Any())
            {
                ordering.Add(stack.Pop().Label);
            }

            return ordering;
        }

        public List<T> TopologicalSortFuncNonRecursive(AdjacentListDirectedGraph<T> graph, GraphNode<T> vertex)
        {

            var queue = new Queue<GraphNode<T>>();
            c
        }
    }
}
