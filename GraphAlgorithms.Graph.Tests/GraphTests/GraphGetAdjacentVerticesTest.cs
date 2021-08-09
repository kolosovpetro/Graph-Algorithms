using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphGetAdjacentVerticesTest
    {
        [Test]
        public void Graph_Get_Adjacent_Vertices_Test()
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

            var adjacentVertices = graph.AdjacentVertices(a);
            Action act = () => graph.AdjacentVertices(vertex);
            
            a.OutDegree().Should().Be(4);
            adjacentVertices.Count.Should().Be(4);
            adjacentVertices[0].Should().Be(b);
            adjacentVertices[1].Should().Be(c);
            adjacentVertices[2].Should().Be(d);
            adjacentVertices[3].Should().Be(e);
            act.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }
    }
}