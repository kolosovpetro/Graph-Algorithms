using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphContainsVertexTest
    {
        [Test]
        public void Graph_Contains_Vertex_Test()
        {
            var graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var vertex = new Vertex<char>('T');

            graph.ContainsVertex(a).Should().BeTrue();
            graph.ContainsVertex('A').Should().BeTrue();
            graph.ContainsVertex('F').Should().BeFalse();
            graph.ContainsVertex(vertex).Should().BeFalse();
        }
    }
}