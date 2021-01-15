using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.Tests
{
    [TestFixture]
    public class GraphResetTest
    {
        [Test]
        public void Graph_Reset_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            foreach (var vertex in graph.Vertices)
                vertex.Visit();

            graph.IsTraversed.Should().BeTrue();
            graph.Reset();
            graph.IsTraversed.Should().BeFalse();
        }
    }
}