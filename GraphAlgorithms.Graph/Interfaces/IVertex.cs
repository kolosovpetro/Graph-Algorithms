using System;
using System.Collections.Generic;

namespace GraphAlgorithms.Graph.Interfaces
{
    public interface IVertex<T> : IEquatable<IVertex<T>>
    {
        /// <summary>
        /// Vertex data
        /// </summary>
        T Data { get; }

        /// <summary>
        /// Boolean, indicates whenever vertex is visited
        /// </summary>
        bool IsVisited { get; }

        /// <summary>
        /// Gives a pointer to the graph vertex belongs to
        /// </summary>
        IGraph<T> CurrentGraph { get; set; }

        /// <summary>
        /// Returns the In-Degree of a current vertex. It is the number of edges which ends with current vertex.
        /// </summary>
        int InDegree();

        /// <summary>
        /// Returns the Out-Degree of a current vertex. It is the number of edges which end with current vertex.
        /// </summary>
        int OutDegree();

        /// <summary>
        /// Marks vertex as visited
        /// </summary>
        void Visit();

        /// <summary>
        /// Resets vertex to be unvisited
        /// </summary>
        void Reset();

        /// <summary>
        /// Returns the list of edges which start from current vertex
        /// </summary>
        List<IEdge<T>> EdgesToAdjacentVertices();
        
        /// <summary>
        /// Returns all the edges which leads to unvisited vertices from particular vertex.
        /// </summary>
        List<IEdge<T>> EdgesToAdjacentUnvisitedVertices();

        /// <summary>
        /// Returns list of adjacent vertices to current vertex
        /// </summary>
        List<IVertex<T>> AdjacentVertices();

        /// <summary>
        /// Returns list of all adjacent and unvisited vertices
        /// </summary>
        List<IVertex<T>> AdjacentUnvisitedVertices();
    }
}