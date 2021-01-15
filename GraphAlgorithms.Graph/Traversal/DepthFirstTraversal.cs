using System;
using System.Collections.Generic;
using System.Linq;
using GraphAlgorithms.Graph.Interfaces;

namespace GraphAlgorithms.Graph.Traversal
{
    public static class DepthFirstTraversal<T>
    {
        /// <summary>
        /// Recursive method. Prints the order of visited vertices to console
        /// </summary>
        public static void DepthFirstSearchIterative(IGraph<T> graph, IVertex<T> startVertex)
        {
            if (!graph.ContainsVertex(startVertex))
                throw new InvalidOperationException("Vertex does not belong to graph.");

            if (startVertex.IsVisited) return;
            
            startVertex.Visit();
            Console.WriteLine(startVertex);
            
            var unvisitedVertices = startVertex.AdjacentUnvisitedVertices();
            foreach (var vertex in unvisitedVertices) 
                DepthFirstSearchIterative(graph, vertex);
        }

        /// <summary>
        /// Returns the list of vertices, which are path from start vertex to end vertex
        /// </summary>
        public static IEnumerable<IVertex<T>> DepthFirstIterative(IGraph<T> graph, IVertex<T> startVertex,
            IVertex<T> searchVertex)
        {
            if (!graph.ContainsVertex(startVertex) || !graph.ContainsVertex(searchVertex))
                throw new InvalidOperationException("One or more vertices are not belong to graph.");

            var stack = new Stack<IVertex<T>>();

            stack.Push(startVertex);

            while (stack.Any())
            {
                var vertex = stack.Pop();
                vertex.Visit();
                yield return vertex;
                if (vertex.Equals(searchVertex))
                    yield break;
                var unvisitedVertices = vertex.AdjacentUnvisitedVertices();
                foreach (var v in unvisitedVertices)
                    stack.Push(v);
            }
        }
    }
}