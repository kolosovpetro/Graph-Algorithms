using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphAddWeightedEdgeTest
    {
        [Test]
        public void Graph_Add_Weighted_Edge_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 30);
            var e2 = graph.AddEdge(b, a, 30);
            graph.AreAdjacent(a, b).Should().BeTrue();
            graph.AreAdjacent(b, a).Should().BeTrue();
            graph.AreAdjacent(b, c).Should().BeFalse();
            var vertex = new Vertex<char>('F');

            Action act1 = () => graph.AreAdjacent(vertex, d);
            act1.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");
        }
    }
}