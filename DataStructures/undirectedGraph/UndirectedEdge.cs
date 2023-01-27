namespace DataStructures;

public class UndirectedEdge<T> : IEquatable<UndirectedEdge<T>> where T : IEquatable<T>, IComparable<T>
{
    public readonly GraphNode<T> Source;
    public readonly GraphNode<T> Destination;
    public int Weight;

    public UndirectedEdge(GraphNode<T> source, GraphNode<T> destination, int weight = 0)
    {
        Source = source;
        Destination = destination;
        Weight = weight;
    }

    public bool Equals(UndirectedEdge<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Source.Equals(other.Source) && Destination.Equals(other.Destination);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UndirectedEdge<T>)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Source, Destination);
    }
}