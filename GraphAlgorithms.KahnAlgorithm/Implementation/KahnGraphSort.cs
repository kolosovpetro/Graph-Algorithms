﻿using System;
using System.Collections.Generic;
using System.Linq;
using GraphAlgorithms.Graph.Interfaces;

namespace GraphAlgorithms.KahnAlgorithm.Implementation
{
    public static class KahnGraphSort<T>
    {
        public static IEnumerable<IVertex<T>> KahnSort(IGraph<T> graph)
        {
            if (!graph.IsAcyclic())
                throw new InvalidOperationException("Kahn sort can be performed only on acyclic graph.");

            var queue = new Queue<IVertex<T>>();
            var startVertices = graph.Vertices.Where(x => x.InDegree() == 0).ToList();
            foreach (var vertex in startVertices)
                queue.Enqueue(vertex);

            while (queue.Any())
            {
                var vertex = queue.Dequeue();
                yield return vertex;
                var adjacentVertices = vertex.AdjacentVertices();
                graph.RemoveVertex(vertex);

                foreach (var v in adjacentVertices.Where(v => v.InDegree() == 0)) 
                    queue.Enqueue(v);
            }
        }
    }
}