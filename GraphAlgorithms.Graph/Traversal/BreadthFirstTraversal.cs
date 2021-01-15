using System;
using System.Collections.Generic;
using System.Linq;
using GraphAlgorithms.Graph.Interfaces;

namespace GraphAlgorithms.Graph.Traversal
{
    public static class BreadthFirstTraversal<T>
    {
        public static IEnumerable<IVertex<T>> BreadthFirstSearchIterative(IGraph<T> graph, IVertex<T> startVertex,
            IVertex<T> endVertex)
        {
            if (!graph.ContainsVertex(startVertex) || !graph.ContainsVertex(endVertex))
                throw new InvalidOperationException("One or more vertices are not belong to graph.");

            var queue = new Queue<IVertex<T>>();
            queue.Enqueue(startVertex);

            while (queue.Any())
            {
                var vertex = queue.Dequeue();
                yield return vertex;
                
                if (vertex.Equals(endVertex)) yield break;
                vertex.Visit();
                var unvisitedVertices = startVertex.AdjacentUnvisitedVertices();
                foreach (var v in unvisitedVertices)
                    queue.Enqueue(v);
            }
        }
    }
}