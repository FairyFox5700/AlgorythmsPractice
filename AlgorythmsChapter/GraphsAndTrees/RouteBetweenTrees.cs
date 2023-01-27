namespace AlgorythmsChapter.GraphsAndTrees
{
    public class Graph<T>
    {
        public Graph()
        {
        }

        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
    }

    public class RouteBetweenTrees
    {

        public List<T> DepthFirstSearch<T>(Graph<T> graph, T vertex)
        {
            var visitedVertexes = new List<T>();
            var stack = new Stack<T>();
            stack.Push(vertex);
            while (stack.Count > 0)
            {
                var vertexCurrent = stack.Pop();
                visitedVertexes.Add(vertexCurrent);

                if (!graph.AdjacencyList.ContainsKey(vertexCurrent))
                {
                    return visitedVertexes;
                }

                foreach (var adjacentVertex in graph.AdjacencyList[vertexCurrent])
                {
                    if (!visitedVertexes.Contains(adjacentVertex))
                    {
                        stack.Push(adjacentVertex);
                    }
                }
            }

            return visitedVertexes;
        }

        public List<T> BreathFirstSearch<T>(Graph<T> graph, T vertex)
        {
            var visitedVertexes = new List<T>();
            var queue = new Queue<T>();
            queue.Enqueue(vertex);
            while (queue.Count > 0)
            {
                var vertexCurrent = queue.Dequeue();
                visitedVertexes.Add(vertexCurrent);

                if (!graph.AdjacencyList.ContainsKey(vertexCurrent))
                {
                    return visitedVertexes;
                }

                foreach (var adjacentVertex in graph.AdjacencyList[vertexCurrent])
                {
                    if (!visitedVertexes.Contains(adjacentVertex))
                    {
                        queue.Enqueue(adjacentVertex);
                    }
                }
            }

            return visitedVertexes;
        }
    }
}
