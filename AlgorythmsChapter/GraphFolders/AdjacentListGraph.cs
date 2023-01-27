using System;

using DataStructures;

namespace AlgorythmsChapter.GraphFolders
{

    public class AdjacentListDirectedGraph<T> where T : IEquatable<T>, IComparable<T>
    {
        public int VertexCount { get; set; }
        public int EdgesCount { get; set; }
        public AdjacentListDirectedGraph(IEnumerable<GraphNode<T>> nodes, IEnumerable<UndirectedEdge<T>> edges)
        {
            foreach (var vertex in nodes)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge.Source, edge.Destination);
        }

        public Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> AdjacencyList { get; } = new Dictionary<GraphNode<T>, HashSet<GraphNode<T>>>();

        public void AddVertex(GraphNode<T> vertex)
        {
            AdjacencyList[vertex] = new HashSet<GraphNode<T>>();
        }

        public void AddEdge(GraphNode<T> source, GraphNode<T> destination)
        {
            if (AdjacencyList.ContainsKey(source) && AdjacencyList.ContainsKey(destination))
            {
                AdjacencyList[source].Add(destination);
            }
        }
    }

    public class AdjacentListGraph<T> where T : IEquatable<T>, IComparable<T>
    {
        public AdjacentListGraph(IEnumerable<GraphNode<T>> nodes, IEnumerable<UndirectedEdge<T>> edges)
        {
            foreach (var vertex in nodes)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge.Source, edge.Destination);
        }

        public Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> AdjacencyList { get; } = new Dictionary<GraphNode<T>, HashSet<GraphNode<T>>>();

        public void AddVertex(GraphNode<T> vertex)
        {
            AdjacencyList[vertex] = new HashSet<GraphNode<T>>();
        }

        public void AddEdge(GraphNode<T> source, GraphNode<T> destination)
        {
            if (AdjacencyList.ContainsKey(source) && AdjacencyList.ContainsKey(destination))
            {
                AdjacencyList[source].Add(destination);
                AdjacencyList[destination].Add(source);
            }
        }
    }
}
