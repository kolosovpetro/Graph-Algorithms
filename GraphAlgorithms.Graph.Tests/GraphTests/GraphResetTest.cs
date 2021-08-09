using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphResetTest
    {
        [Test]
        public void Graph_Reset_Test()
        {
            var graph = new Graph<char>();
            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('C');
            graph.AddVertex('D');
            graph.AddVertex('E');

            foreach (var vertex in graph.Vertices)
            {
                vertex.Visit();
            }

            graph.IsTraversed.Should().BeTrue();
            graph.Reset();
            graph.IsTraversed.Should().BeFalse();
        }
    }
}