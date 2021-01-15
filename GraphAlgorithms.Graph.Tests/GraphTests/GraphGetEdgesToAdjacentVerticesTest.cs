using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphGetEdgesToAdjacentVerticesTest
    {
        [Test]
        public void Graph_Get_Edges_To_Adjacent_Vertices_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(a, d, 7);
            var e3 = graph.AddEdge(d, a, 8);
            var e4 = graph.AddEdge(c, e, 9);

            var edgesStartsWith = graph.EdgesToAdjacentVertices(a);
            edgesStartsWith.Count.Should().Be(2);
            edgesStartsWith[0].Should().Be(e1);
            edgesStartsWith[1].Should().Be(e2);

            edgesStartsWith = graph.EdgesToAdjacentVertices(b);
            edgesStartsWith.Should().BeEmpty();

            var vertex = new Vertex<char>('F');
            Action act = () => graph.EdgesToAdjacentVertices(vertex);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }
    }
}