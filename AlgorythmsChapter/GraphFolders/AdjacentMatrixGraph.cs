namespace AlgorythmsChapter.GraphFolders
{
    //create Adjacency Matrix of the given Graph.
    public class AdjacentMatrixGraph
    {
        public int VertixCount;
        public int EdgeCount;
        public int[,] AdjacentMatrix;

        public AdjacentMatrixGraph(int vertixCount, int egdesCount)
        {
            VertixCount = vertixCount;
            EdgeCount = egdesCount;
            AdjacentMatrix = new int[VertixCount, VertixCount];
        }

        public void AddEdge(int source, int destination)
        {
            if (source >= VertixCount || destination >= VertixCount)
            {
                throw new ArgumentOutOfRangeException();
            }
            AdjacentMatrix[source, destination] = 1;
            AdjacentMatrix[destination, source] = 1;
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < EdgeCount; i++)
            {
                for (int j = 0; j < EdgeCount; j++)
                {
                    Console.WriteLine(AdjacentMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
