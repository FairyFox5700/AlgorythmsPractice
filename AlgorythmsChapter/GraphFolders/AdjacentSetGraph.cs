using DataStructures;

namespace AlgorythmsChapter.GraphFolders;

public class AdjacentSetGraph<T> where T : IEquatable<T>, IComparable<T>
{
    public readonly HashSet<GraphNode<T>> Nodes;
    public readonly HashSet<UndirectedEdge<T>> Edges;
    public readonly Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> Neighbors;

    public int NumNodes => Nodes.Count;
    public int NumEdges => Edges.Count;

    public AdjacentSetGraph(IEnumerable<GraphNode<T>> nodes, IEnumerable<UndirectedEdge<T>> edges)
    {
        Nodes = nodes.ToHashSet();
        Edges = new HashSet<UndirectedEdge<T>>();
        Neighbors = new Dictionary<GraphNode<T>, HashSet<GraphNode<T>>>(Nodes.Count);

        foreach (var edge in edges)
        {
            Edges.Add(edge);
            edge.Source.OutDegree++;
            edge.Destination.InDegree++;

            AddNeighbor(edge.Source, edge.Destination);
            AddNeighbor(edge.Destination, edge.Source);
        }

    }

    private void AddNeighbor(GraphNode<T> source, GraphNode<T> destination)
    {
        if (Neighbors.TryGetValue(source, out var neighbors))
        {
            neighbors.Add(destination);
        }
        else Neighbors[source] = new HashSet<GraphNode<T>> { destination };

    }


}