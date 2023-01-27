using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures;

namespace AlgorythmsChapter.GraphFolders
{
    internal class GraphTraversal<T> where T : IEquatable<T>, IComparable<T>
    {
        public List<GraphNode<T>> DepthFirstSearch(AdjacentListGraph<T> graph, GraphNode<T> vertex)
        {
            var visitedVertexes = new List<GraphNode<T>>();
            var stack = new Stack<GraphNode<T>>();
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

        public List<GraphNode<T>> BreathFirstSearch(AdjacentListGraph<T> graph, GraphNode<T> vertex)
        {
            var visitedVertexes = new List<GraphNode<T>>();
            var queue = new Queue<GraphNode<T>>();
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


        /*procedure dfs(vertex v)
 {
     visit(v);
     for each neighbor u of v
         if u is undiscovered
             call dfs(u);
 }*/
        public void DepthFirstSearchInternal(AdjacentListDirectedGraph<T> graph,
            HashSet<GraphNode<T>> visited,
            GraphNode<T> vertex)
        {
            visited.Add(vertex);
            foreach (var adjacent in graph.AdjacencyList[vertex])
            {
                if (!visited.Contains(adjacent))
                    DepthFirstSearchInternal(graph, visited, adjacent);
            }
        }

        public void DepthFirstSearchRecursive(AdjacentListDirectedGraph<T> graph,
            GraphNode<T> vertex)
        {
            var visted = new HashSet<GraphNode<T>>();
            DepthFirstSearchInternal(graph, visted, vertex);
        }
    }
}
