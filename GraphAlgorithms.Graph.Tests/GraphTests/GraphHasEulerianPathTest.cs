using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphHasEulerianPathTest
    {
        [Test]
        public void Graph_Has_Eulerian_Path_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');
            var f = graph.AddVertex('F');

            graph.AddEdge(a, b);
            graph.AddEdge(a, b);
            graph.AddEdge(b, d);
            graph.AddEdge(b, c);
            graph.AddEdge(d, a);
            graph.AddEdge(c, a);

            graph.HasEulerianPath().Should().BeTrue();
            graph.HasEulerianCircuit().Should().BeTrue();

            graph.ClearEdges();

            graph.AddEdge(a, b);
            graph.AddEdge(b, c);
            graph.AddEdge(d, c);
            graph.AddEdge(d, a);

            graph.HasEulerianPath().Should().BeFalse();
            graph.HasEulerianCircuit().Should().BeFalse();
            graph.ClearEdges();

            graph.AddEdge(b, b);
            graph.AddEdge(b, c);
            graph.AddEdge(b, d);
            graph.AddEdge(c, e);
            graph.AddEdge(e, e);
            graph.AddEdge(e, b);
            graph.AddEdge(e, d);
            graph.AddEdge(d, e);
            graph.AddEdge(d, f);
            graph.AddEdge(f, e);

            graph.HasEulerianPath().Should().BeTrue();
            graph.HasEulerianCircuit().Should().BeFalse();
        }
    }
}