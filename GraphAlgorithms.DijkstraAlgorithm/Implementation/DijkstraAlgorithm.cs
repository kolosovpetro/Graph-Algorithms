using System;
using System.Collections.Generic;
using System.Linq;
using GraphAlgorithms.DijkstraAlgorithm.Models;
using GraphAlgorithms.Graph.Interfaces;

namespace GraphAlgorithms.DijkstraAlgorithm.Implementation
{
    public static class DijkstraAlgorithm<T>
    {
        public static List<DistanceModel<T>> DijkstraMethod(IGraph<T> graph, IVertex<T> start)
        {
            if (!graph.ContainsVertex(start))
                throw new InvalidOperationException("Vertex does not belong to graph");

            var list = new List<DistanceModel<T>> {new DistanceModel<T>(start, start, 0)};
            var currentVertex = start;
            var iterator = 0;

            while (graph.UnvisitedVertices().Any())
            {
                currentVertex.Visit();

                var edgesToAdjacentUnvisitedVertices = graph
                    .EdgesToAdjacentUnvisitedVertices(currentVertex);

                foreach (var edge in edgesToAdjacentUnvisitedVertices)
                {
                    if (ContainsAndGreater(list, edge.EndVertex, iterator + edge.Weight))
                    {
                        var distance = GetDistanceModelByEndVertex(list, edge.EndVertex);
                        distance.Distance = iterator + edge.Weight;
                        distance.PreviousVertex = currentVertex;
                        continue;
                    }

                    if (!Contains(list, edge.EndVertex))
                        list.Add(new DistanceModel<T>
                        {
                            Vertex = edge.EndVertex,
                            PreviousVertex = currentVertex,
                            Distance = iterator + edge.Weight,
                        });
                }

                if (!edgesToAdjacentUnvisitedVertices.Any()) break;

                var minEdge = GetMinEdge(edgesToAdjacentUnvisitedVertices);
                iterator += minEdge.Weight;
                currentVertex = minEdge.EndVertex;
            }

            return list;
        }

        private static IEdge<T> GetMinEdge(List<IEdge<T>> edges)
        {
            var minWeight = edges.Min(t => t.Weight);
            return edges.First(x => x.Weight == minWeight);
        }

        private static DistanceModel<T> GetDistanceModelByEndVertex(IEnumerable<DistanceModel<T>> distances,
            IVertex<T> endVertex)
            => distances.First(x => x.Vertex.Equals(endVertex));

        private static bool ContainsAndGreater(List<DistanceModel<T>> distances, IVertex<T> vertex, int value)
            => distances.Any(x => x.Vertex.Equals(vertex) && x.Distance > value);

        private static bool Contains(List<DistanceModel<T>> distances, IVertex<T> vertex)
            => distances.Any(x => x.Vertex.Equals(vertex));
    }
}