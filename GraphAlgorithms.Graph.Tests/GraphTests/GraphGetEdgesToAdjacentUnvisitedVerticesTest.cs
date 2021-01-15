using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphGetEdgesToAdjacentUnvisitedVerticesTest
    {
        [Test]
        public void Graph_Get_Edges_To_Adjacent_Unvisited_Vertices_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(a, c, 7);
            var e3 = graph.AddEdge(a, d, 8);
            var e4 = graph.AddEdge(a, e, 9);

            var adjacentUnvisitedEdges = graph.EdgesToAdjacentUnvisitedVertices(a);
            adjacentUnvisitedEdges.Count.Should().Be(4);
            adjacentUnvisitedEdges[0].Should().Be(e1);
            adjacentUnvisitedEdges[1].Should().Be(e2);
            adjacentUnvisitedEdges[2].Should().Be(e3);
            adjacentUnvisitedEdges[3].Should().Be(e4);

            d.Visit();
            e.Visit();

            adjacentUnvisitedEdges = graph.EdgesToAdjacentUnvisitedVertices(a);
            adjacentUnvisitedEdges.Count.Should().Be(2);
            adjacentUnvisitedEdges[0].Should().Be(e1);
            adjacentUnvisitedEdges[1].Should().Be(e2);

            var vertex = new Vertex<char>('F');
            Action act = () => graph.EdgesToAdjacentVertices(vertex);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }
    }
}