using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.Tests
{
    [TestFixture]
    public class GraphVerticesAreAdjacentTest
    {
        [Test]
        public void Graph_Vertices_Are_Adjacent_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b);
            graph.AreAdjacent(a, b).Should().BeTrue();
            graph.AreAdjacent(b, a).Should().BeFalse();
            graph.AreAdjacent(b, c).Should().BeFalse();
            var vertex = new Vertex<char>('F');
            Action act = () => graph.AreAdjacent(vertex, d);

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");
        }
    }
}