using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.Tests
{
    [TestFixture]
    public class GraphContainsEdgeTest
    {
        [Test]
        public void Graph_Contains_Edge_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(e, d, 7);
            var e3 = graph.AddEdge(d, a, 8);
            var e4 = graph.AddEdge(c, e, 9);

            graph.ContainsEdge(e1).Should().BeTrue();
            graph.AreAdjacent('A', 'B').Should().BeTrue();
            graph.AreAdjacent('B', 'A').Should().BeFalse();
            var edge = new Edge<char>(b, a);
            graph.ContainsEdge(edge).Should().BeFalse();
        }
    }
}