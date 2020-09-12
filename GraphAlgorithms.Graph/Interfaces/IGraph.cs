using System.Collections.Generic;

namespace GraphAlgorithms.Graph.Interfaces
{
    public interface IGraph<T>
    {
        /// <summary>
        /// Returns the list of all edges belong to current graph.
        /// </summary>
        List<IEdge<T>> Edges { get; }
        
        /// <summary>
        /// Returns the list of all vertices belong to current graph.
        /// </summary>
        List<IVertex<T>> Vertices { get; }
        
        /// <summary>
        /// Returns the total number of the vertices in graph.
        /// </summary>
        int Count { get; }
        
        /// <summary>
        /// Indicates whenever graph contains at least 1 vertex.
        /// </summary>
        bool IsEmpty { get; }
        
        /// <summary>
        /// Checks whenever all vertices of graph are visited.
        /// </summary>
        bool IsTraversed { get; }

        /// <summary>
        /// Returns list of all neighbor vertices of specified vertex.
        /// </summary>
        List<IVertex<T>> AdjacentVertices(IVertex<T> vertex);
        
        /// <summary>
        /// Returns list of all unvisited neighbor vertices of specified vertex.
        /// </summary>
        List<IVertex<T>> AdjacentUnvisitedVertices(IVertex<T> vertex);
        
        /// <summary>
        /// Returns list of all unvisited vertices of a graph.
        /// </summary>
        List<IVertex<T>> UnvisitedVertices();

        /// <summary>
        /// Returns a list of all edges in the graph, such that start from particular vertex.
        /// </summary>
        List<IEdge<T>> EdgesToAdjacentVertices(IVertex<T> vertex);
        
        /// <summary>
        /// Returns all the edges which leads to unvisited vertices from particular vertex.
        /// </summary>
        List<IEdge<T>> EdgesToAdjacentUnvisitedVertices(IVertex<T> vertex);
        
        /// <summary>
        /// Returns list of all edges that contain particular vertex.
        /// </summary>
        List<IEdge<T>> EdgesContainVertex(IVertex<T> vertex);
        
        /// <summary>
        /// Checks whenever there is a path between two vertices.
        /// Returns true if there is an edge between start vertex and add vertex.
        /// </summary>
        bool AreAdjacent(IVertex<T> startVertex, IVertex<T> endVertex);
        
        /// <summary>
        /// Checks whenever there is a path between two vertices with specified data.
        /// Returns true if there is an edge between two vertices with specified data.
        /// </summary>
        bool AreAdjacent(T startData, T endData);
        
        /// <summary>
        /// Adds new vertex with specified data to the graph and gives pointer to it.
        /// </summary>
        IVertex<T> AddVertex(T data);

        /// <summary>
        /// Creates a new unweighted directed edge between two vertices and gives a pointer to it.
        /// Edge is directed from start vertex to edn vertex.
        /// </summary>
        IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex);

        /// <summary>
        /// Creates a new weighted edge between two vertices of graph and gives a pointer to it.
        /// Edge is directed from start vertex to edn vertex.
        /// </summary>
        IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex, int weight);
        
        /// <summary>
        /// Removes vertex with specified data.
        /// </summary>
        void RemoveVertex(T data);

        /// <summary>
        /// Removes vertex from the graph by reference.
        /// </summary>
        void RemoveVertex(IVertex<T> vertex);
        
        /// <summary>
        /// Removes directed edge between two vertices, if such edge exists.
        /// </summary>
        void RemoveEdge(IVertex<T> startVertex, IVertex<T> endVertex);
        
        /// <summary>
        /// Removes an edge from the graph by edge reference.
        /// </summary>
        void RemoveEdge(IEdge<T> edge);
        
        /// <summary>
        /// Checks whenever graph contains vertex with specified data.
        /// </summary>
        bool ContainsVertex(T data);

        /// <summary>
        /// Checks whenever graph contains specified vertex.
        /// </summary>
        bool ContainsVertex(IVertex<T> vertex);
        
        /// <summary>
        /// Checks whenever graph contains specified edge.
        /// </summary>
        bool ContainsEdge(IEdge<T> edge);
        
        /// <summary>
        /// Indicates whenever current graph has Eulerian path.
        /// </summary>
        bool HasEulerianPath();
        
        /// <summary>
        /// Indicates whenever current graph has Eulerian circuit.
        /// </summary>
        bool HasEulerianCircuit();

        /// <summary>
        /// Indicates whenever current graph in acyclic.
        /// </summary>
        bool IsAcyclic();

        /// <summary>
        /// Resets all vertices of a graph to be unvisited
        /// </summary>
        void Reset();

        /// <summary>
        /// Removes all edges between vertices.
        /// Vertices still remains in graph but any of them are connected.
        /// </summary>
        void ClearEdges();
    }
}