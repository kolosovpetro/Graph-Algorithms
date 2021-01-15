using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.Tests
{
    [TestFixture]
    public class GraphInitializationTest
    {
        [Test]
        public void Graph_Initialization_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            graph.IsEmpty.Should().BeFalse();
            graph.IsTraversed.Should().BeFalse();
            graph.Count.Should().Be(5);
            a.CurrentGraph.Should().Be(graph);
            b.CurrentGraph.Should().Be(graph);
            c.CurrentGraph.Should().Be(graph);
            d.CurrentGraph.Should().Be(graph);
            e.CurrentGraph.Should().Be(graph);
        }
    }
}