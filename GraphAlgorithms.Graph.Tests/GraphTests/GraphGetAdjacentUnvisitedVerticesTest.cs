using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphGetAdjacentUnvisitedVerticesTest
    {
        [Test]
        public void Graph_Get_Adjacent_Unvisited_Vertices_Test()
        {
            var graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');
            graph.AddEdge(a, b, 5);
            graph.AddEdge(a, c, 7);
            graph.AddEdge(a, d, 8);
            graph.AddEdge(a, e, 9);
            var vertex = new Vertex<char>('F');

            e.Visit();
            var adjacentVertices = graph.AdjacentUnvisitedVertices(a);
            Action act = () => graph.AdjacentVertices(vertex);

            adjacentVertices.Count.Should().Be(3);
            adjacentVertices[0].Should().Be(b);
            adjacentVertices[1].Should().Be(c);
            adjacentVertices[2].Should().Be(d);
            act.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }
    }
}