using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphContainsEdgeTest
    {
        [Test]
        public void Graph_Contains_Edge_Test()
        {
            var graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            
            var edge1 = graph.AddEdge(a, b, 5);
            var edge2 = new Edge<char>(b, a);

            graph.ContainsEdge(edge1).Should().BeTrue();
            graph.ContainsEdge(edge2).Should().BeFalse();
        }
    }
}