using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.Tests
{
    [TestFixture]
    public class VertexGetAdjacentUnvisitedVerticesTest
    {
        [Test]
        public void Vertex_Get_Adjacent_Unvisited_Vertices_Test()
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

            var adjacentEdges = a.AdjacentUnvisitedVertices();
            adjacentEdges.Count.Should().Be(4);
            adjacentEdges[0].Should().Be(b);
            adjacentEdges[1].Should().Be(c);
            adjacentEdges[2].Should().Be(d);
            adjacentEdges[3].Should().Be(e);

            b.Visit();
            c.Visit();

            adjacentEdges = a.AdjacentUnvisitedVertices();
            adjacentEdges.Count.Should().Be(2);
            adjacentEdges[0].Should().Be(d);
            adjacentEdges[1].Should().Be(e);

            Action act = () => new Vertex<char>('F').AdjacentVertices();

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to any graph.");
        }
    }
}