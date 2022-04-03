using System;
using System.Collections.Generic;
using System.Linq;
using GraphAlgorithms.Graph.Interfaces;

namespace GraphAlgorithms.Graph.Implementations
{
    public class Graph<T> : IGraph<T>
    {
        /// <summary>
        /// Returns the list of all edges belong to current graph.
        /// </summary>
        public List<IEdge<T>> Edges { get; }

        /// <summary>
        /// Returns the list of all vertices belong to current graph.
        /// </summary>
        public List<IVertex<T>> Vertices { get; }

        /// <summary>
        /// Returns the total number of the vertices in graph.
        /// </summary>
        public int Count => Vertices.Count;

        /// <summary>
        /// Indicates whenever graph contains at least 1 vertex.
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Checks whenever all vertices of graph are visited
        /// </summary>
        public bool IsTraversed => Vertices.All(x => x.IsVisited);

        public Graph()
        {
            Edges = new List<IEdge<T>>();
            Vertices = new List<IVertex<T>>();
        }

        /// <summary>
        /// Returns list of all neighbor vertices of specified vertex
        /// </summary>
        public List<IVertex<T>> AdjacentVertices(IVertex<T> vertex)
        {
            ThrowIfDoesNotContainVertex(vertex);
            return vertex.AdjacentVertices();
        }

        /// <summary>
        /// Returns list of all unvisited neighbor vertices of specified vertex.
        /// </summary>
        public List<IVertex<T>> AdjacentUnvisitedVertices(IVertex<T> vertex)
        {
            ThrowIfDoesNotContainVertex(vertex);
            return vertex.AdjacentUnvisitedVertices();
        }

        /// <summary>
        /// Returns list of all unvisited vertices of a graph
        /// </summary>
        public List<IVertex<T>> UnvisitedVertices()
        {
            return Vertices.Where(x => !x.IsVisited).ToList();
        }

        /// <summary>
        /// Returns a list of all edges in the graph, such that start from particular vertex
        /// </summary>
        public List<IEdge<T>> EdgesToAdjacentVertices(IVertex<T> vertex)
        {
            ThrowIfDoesNotContainVertex(vertex);
            return vertex.EdgesToAdjacentVertices();
        }

        /// <summary>
        /// Returns all the edges which leads to unvisited vertices from particular vertex
        /// </summary>
        public List<IEdge<T>> EdgesToAdjacentUnvisitedVertices(IVertex<T> vertex)
        {
            ThrowIfDoesNotContainVertex(vertex);
            return vertex.EdgesToAdjacentUnvisitedVertices();
        }

        /// <summary>
        /// Returns list of all edges that contain particular vertex
        /// </summary>
        public List<IEdge<T>> EdgesContainVertex(IVertex<T> vertex)
        {
            ThrowIfDoesNotContainVertex(vertex);
            return Edges.Where(x => x.StartVertex.Equals(vertex) || x.EndVertex.Equals(vertex)).ToList();
        }

        /// <summary>
        /// Checks whenever there is a path between two vertices.
        /// Returns true if graph contains and edge such that start vertex and end vertex are parameters
        /// </summary>
        public bool AreAdjacent(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            ThrowIfDoesNotContainVertices(startVertex, endVertex);
            return AreAdjacent(startVertex.Data, endVertex.Data);
        }

        private void ThrowIfDoesNotContainVertices(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            if (!ContainsVertex(startVertex) || !ContainsVertex(endVertex))
                throw new InvalidOperationException("One or more vertex does not belong to the graph.");
        }

        /// <summary>
        /// Adds new vertex with specified data to the graph and gives pointer to it
        /// </summary>
        public IVertex<T> AddVertex(T data)
        {
            ThrowIfContainsData(data);

            var vertex = new Vertex<T>(data, this);
            Vertices.Add(vertex);
            return vertex;
        }

        private void ThrowIfContainsData(T data)
        {
            if (ContainsVertex(data))
            {
                throw new InvalidOperationException("Vertex with same data is already in graph.");
            }
        }

        /// <summary>
        /// Creates a new unweighted directed edge between two vertices and gives a pointer to it.
        /// Edge is directed from start vertex to edn vertex.
        /// </summary>
        public IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            ThrowIfDoesNotContainVertices(startVertex, endVertex);

            var edge = new Edge<T>(startVertex, endVertex, this);
            Edges.Add(edge);
            return edge;
        }

        /// <summary>
        /// Creates a new weighted edge between two vertices of graph and gives a pointer to it.
        /// Edge is directed from start vertex to edn vertex.
        /// </summary>
        public IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex, int weight)
        {
            ThrowIfDoesNotContainVertices(startVertex, endVertex);

            var edge = new Edge<T>(startVertex, endVertex, weight, this);
            Edges.Add(edge);
            return edge;
        }

        /// <summary>
        /// Removes vertex with specified data.
        /// </summary>
        public void RemoveVertex(T data)
        {
            ThrowIfDoesNotContainData(data);

            var vertex = Vertices.First(x => x.Data.Equals(data));
            var connectedEdges = EdgesContainVertex(vertex);

            connectedEdges.ForEach(RemoveEdge);
            Vertices.Remove(vertex);
            vertex.CurrentGraph = null;
        }

        private void ThrowIfDoesNotContainData(T data)
        {
            if (!ContainsVertex(data))
                throw new InvalidOperationException("There is no any vertex with such data.");
        }

        /// <summary>
        /// Removes vertex from the graph by reference.
        /// </summary>
        public void RemoveVertex(IVertex<T> vertex)
        {
            ThrowIfDoesNotContainVertex(vertex);

            var connectedEdges = EdgesContainVertex(vertex);

            connectedEdges.ForEach(RemoveEdge);
            Vertices.Remove(vertex);
            vertex.CurrentGraph = null;
        }

        /// <summary>
        /// Removes an edge between two vertices, if such edge exists.
        /// </summary>
        public void RemoveEdge(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            ThrowIfDoesNotContainVertices(startVertex, endVertex);

            if (!AreAdjacent(startVertex, endVertex))
            {
                throw new InvalidOperationException("There is no such edge in the graph.");
            }

            var edge = Edges.First(x => x.StartVertex.Equals(startVertex)
                                        && x.EndVertex.Equals(endVertex));
            Edges.Remove(edge);

            edge.CurrentGraph = null;
        }

        /// <summary>
        /// Removes an edge from graph, if such edge belongs to graph.
        /// </summary>
        public void RemoveEdge(IEdge<T> edge)
        {
            ThrowIfDoesNotContainVertices(edge.StartVertex, edge.EndVertex);

            if (!ContainsEdge(edge))
            {
                throw new InvalidOperationException("Edge does not belong to the graph.");
            }

            edge.CurrentGraph = null;
            Edges.Remove(edge);
        }

        /// <summary>
        /// Checks whenever graph contains vertex with specified data.
        /// </summary>
        public bool ContainsVertex(T data)
        {
            return Vertices.Any(x => x.Data.Equals(data));
        }

        /// <summary>
        /// Checks whenever graph contains specified vertex.
        /// </summary>
        public bool ContainsVertex(IVertex<T> vertex)
        {
            return vertex.CurrentGraph == this;
        }

        /// <summary>
        /// Checks whenever graph contains specified edge.
        /// </summary>
        public bool ContainsEdge(IEdge<T> edge)
        {
            return edge.CurrentGraph == this;
        }

        /// <summary>
        /// Indicates whenever current graph has Eulerian path.
        /// </summary>
        public bool HasEulerianPath()
        {
            var outInDifferenceVertices = Vertices
                .Where(x => x.OutDegree() - x.InDegree() == 1)
                .ToList();

            var inOutDifferenceVertices = Vertices
                .Where(x => x.InDegree() - x.OutDegree() == 1)
                .ToList();

            if (inOutDifferenceVertices.Count > 1 || outInDifferenceVertices.Count > 1)
            {
                return false;
            }

            var otherVertices = Vertices
                .Except(outInDifferenceVertices)
                .Except(inOutDifferenceVertices)
                .ToList();

            return otherVertices.All(x => x.InDegree() == x.OutDegree());
        }

        /// <summary>
        /// Indicates whenever current graph has Eulerian circuit.
        /// </summary>
        public bool HasEulerianCircuit()
        {
            return Vertices.All(x => x.OutDegree() == x.InDegree());
        }

        /// <summary>
        /// Indicates whenever current graph in acyclic.
        /// </summary>
        public bool IsAcyclic()
        {
            return Vertices.Any(x => x.InDegree() == 0)
                   && Vertices.Any(x => x.OutDegree() == 0);
        }

        /// <summary>
        /// Checks whenever graph contains an edge with specified start data and end data.
        /// </summary>
        public bool AreAdjacent(T startData, T endData)
        {
            return Edges.Any(x => x.StartVertex.Data.Equals(startData) && x.EndVertex.Data.Equals(endData));
        }

        /// <summary>
        /// Resets all vertices of a graph to be unvisited.
        /// </summary>
        public void Reset()
        {
            foreach (var vertex in Vertices)
            {
                vertex.Reset();
            }
        }

        /// <summary>
        /// Removes all edges between vertices.
        /// Vertices still remains in graph but any of them are connected.
        /// </summary>
        public void ClearEdges()
        {
            while (Edges.Any())
            {
                RemoveEdge(Edges.First());
            }
        }

        private void ThrowIfDoesNotContainVertex(IVertex<T> vertex)
        {
            if (!ContainsVertex(vertex))
            {
                throw new InvalidOperationException("Vertex does not belong to the graph.");
            }
        }
    }
}