using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphGetAdjacentUnvisitedVerticesTest
    {
        [Test]
        public void Graph_Get_Adjacent_Unvisited_Vertices_Test()
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
            
            e.Visit();

            var adjacentVertices = graph.AdjacentUnvisitedVertices(a);
            a.OutDegree().Should().Be(4);
            adjacentVertices.Count.Should().Be(3);
            adjacentVertices[0].Should().Be(b);
            adjacentVertices[1].Should().Be(c);
            adjacentVertices[2].Should().Be(d);

            var vertex = new Vertex<char>('F');

            Action act = () => graph.AdjacentVertices(vertex);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }
    }
}