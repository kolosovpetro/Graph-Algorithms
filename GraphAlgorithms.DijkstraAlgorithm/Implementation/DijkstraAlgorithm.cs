using System;
using System.Collections.Generic;
using System.Linq;
using GraphAlgorithms.DijkstraAlgorithm.Models;
using GraphAlgorithms.Graph.Interfaces;

namespace GraphAlgorithms.DijkstraAlgorithm.Implementation
{
    public static class DijkstraAlgorithm<T>
    {
        public static List<DistanceModel<T>> DijkstraMethod(IGraph<T> graph, IVertex<T> startVertex)
        {
            if (!graph.ContainsVertex(startVertex))
                throw new InvalidOperationException("Vertex does not belong to graph");
            
            graph.Reset();

            var distances = new List<DistanceModel<T>>
            {
                new DistanceModel<T>(startVertex, startVertex, 0)
            };

            var currentVertex = startVertex;

            var iterator = 0;

            while (graph.UnvisitedVertices().Any())
            {
                currentVertex.Visit();

                var edgesToAdjacentUnvisitedVertices = graph
                    .EdgesToAdjacentUnvisitedVertices(currentVertex);

                foreach (var edge in edgesToAdjacentUnvisitedVertices)
                {
                    if (ContainsAndGreater(distances, edge.EndVertex, iterator + edge.Weight))
                    {
                        var distanceModel = GetDistanceModelByEndVertex(distances, edge.EndVertex);
                        distanceModel.Distance = iterator + edge.Weight;
                        distanceModel.PreviousVertex = currentVertex;
                        continue;
                    }

                    if (!Contains(distances, edge.EndVertex))
                    {
                        distances.Add(new DistanceModel<T>
                        {
                            Vertex = edge.EndVertex,
                            PreviousVertex = currentVertex,
                            Distance = iterator + edge.Weight,
                        });
                    }
                }

                if (!edgesToAdjacentUnvisitedVertices.Any()) break;

                var minEdge = GetMinEdge(edgesToAdjacentUnvisitedVertices);
                iterator += minEdge.Weight;
                currentVertex = minEdge.EndVertex;
            }

            return distances;
        }

        private static IEdge<T> GetMinEdge(List<IEdge<T>> edges)
        {
            var minWeight = edges.Min(t => t.Weight);
            return edges.First(x => x.Weight == minWeight);
        }

        private static DistanceModel<T> GetDistanceModelByEndVertex(List<DistanceModel<T>> distances,
            IVertex<T> endVertex)
        {
            var distanceModel = distances.First(x => x.Vertex.Equals(endVertex));
            return distanceModel;
        }

        private static bool ContainsAndGreater(List<DistanceModel<T>> distances, IVertex<T> vertex, int value)
        {
            return distances.Any(x => x.Vertex.Equals(vertex) && x.Distance > value);
        }

        private static bool Contains(List<DistanceModel<T>> distances, IVertex<T> vertex)
        {
            return distances.Any(x => x.Vertex.Equals(vertex));
        }
    }
}