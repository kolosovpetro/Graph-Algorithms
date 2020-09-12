using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.Tests
{
    [TestFixture]
    public class GraphContainsVertexTest
    {
        [Test]
        public void Graph_Contains_Vertex_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            graph.ContainsVertex(a).Should().BeTrue();
            graph.ContainsVertex('A').Should().BeTrue();
            graph.ContainsVertex('F').Should().BeFalse();
            var vertex = new Vertex<char>('T');
            graph.ContainsVertex(vertex).Should().BeFalse();
        }
    }
}