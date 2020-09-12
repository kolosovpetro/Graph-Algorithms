using System;
using System.Collections.Generic;
using System.Linq;
using GraphAlgorithms.Graph.Interfaces;

namespace GraphAlgorithms.Graph.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        /// <summary>
        /// Vertex data
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Boolean, indicates whenever vertex is visited
        /// </summary>
        public bool IsVisited { get; private set; }

        /// <summary>
        /// Gives a pointer to the graph vertex belongs to
        /// </summary>
        public IGraph<T> CurrentGraph { get; set; }

        public Vertex(T data) => Data = data;

        public Vertex(T data, IGraph<T> currentGraph)
        {
            Data = data;
            CurrentGraph = currentGraph;
        }

        /// <summary>
        /// Returns the In-Degree of a current vertex. It is the number of edges which end with current vertex.
        /// </summary>
        public int InDegree()
        {
            if (CurrentGraph == null)
                throw new InvalidOperationException("Vertex does not belong to any graph.");

            return CurrentGraph.Edges.Count(x => x.EndVertex.Equals(this));
        }

        /// <summary>
        /// Returns the Out-Degree of a current vertex. It is the number of edges which start from current vertex.
        /// </summary>
        public int OutDegree()
        {
            if (CurrentGraph == null)
                throw new InvalidOperationException("Vertex does not belong to any graph.");

            return CurrentGraph.Edges.Count(x => x.StartVertex.Equals(this));
        }

        /// <summary>
        /// Marks vertex as visited
        /// </summary>
        public void Visit() => IsVisited = true;

        /// <summary>
        /// Resets vertex to be unvisited
        /// </summary>
        public void Reset() => IsVisited = false;

        /// <summary>
        /// Returns the list of edges which start from current vertex
        /// </summary>
        public List<IEdge<T>> EdgesToAdjacentVertices()
        {
            if (CurrentGraph == null)
                throw new InvalidOperationException("Vertex does not belong to any graph.");

            return CurrentGraph.Edges.Where(x => x.StartVertex.Equals(this)).ToList();
        }

        /// <summary>
        /// Returns all the edges which leads to unvisited vertices from particular vertex.
        /// </summary>
        public List<IEdge<T>> EdgesToAdjacentUnvisitedVertices()
        {
            if (CurrentGraph == null)
                throw new InvalidOperationException("Vertex does not belong to any graph.");

            return EdgesToAdjacentVertices().Where(x => !x.EndVertex.IsVisited).ToList();
        }

        /// <summary>
        /// Returns list of adjacent vertices to current vertex
        /// </summary>
        public List<IVertex<T>> AdjacentVertices() => EdgesToAdjacentVertices().Select(t => t.EndVertex).ToList();

        /// <summary>
        /// Returns list of all adjacent and unvisited vertices
        /// </summary>
        public List<IVertex<T>> AdjacentUnvisitedVertices() => AdjacentVertices().Where(x => !x.IsVisited).ToList();

        public override string ToString() => Data.ToString();

        private bool Equals(Vertex<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Data, other.Data) && IsVisited == other.IsVisited &&
                   Equals(CurrentGraph, other.CurrentGraph);
        }

        public bool Equals(IVertex<T> other)
        {
            return other != null
                   && Data.Equals(other.Data)
                   && CurrentGraph.Equals(other.CurrentGraph)
                   && IsVisited.Equals(other.IsVisited);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vertex<T>) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Data, IsVisited, CurrentGraph);
        }
    }
}