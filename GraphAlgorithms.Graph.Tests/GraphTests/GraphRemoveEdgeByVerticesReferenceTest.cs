using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphRemoveEdgeByVerticesReferenceTest
    {
        [Test]
        public void Graph_Remove_Edge_By_Vertices_Reference_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(a, c, 7);
            var e3 = graph.AddEdge(a, d, 8);
            var e4 = graph.AddEdge(a, e, 9);

            a.OutDegree().Should().Be(4);
            b.InDegree().Should().Be(1);
            graph.RemoveEdge(a, b);
            graph.ContainsEdge(e1).Should().BeFalse();
            graph.AreAdjacent(a, b).Should().BeFalse();
            a.OutDegree().Should().Be(3);
            b.InDegree().Should().Be(0);
            e1.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, b).Should().BeFalse();

            a.OutDegree().Should().Be(3);
            c.InDegree().Should().Be(1);
            graph.RemoveEdge(a, c);
            graph.ContainsEdge(e2).Should().BeFalse();
            graph.AreAdjacent(a, c).Should().BeFalse();
            a.OutDegree().Should().Be(2);
            c.InDegree().Should().Be(0);
            e2.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, c).Should().BeFalse();

            Action act1 = () => graph.RemoveEdge(a, b);
            act1.Should().Throw<InvalidOperationException>()
                .WithMessage("There is no such edge in the graph.");

            var vertex = new Vertex<char>('F');
            Action act2 = () => graph.RemoveEdge(vertex, d);
            act2.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");
        }
    }
}