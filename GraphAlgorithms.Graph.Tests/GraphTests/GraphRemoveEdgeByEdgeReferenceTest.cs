using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphRemoveEdgeByEdgeReferenceTest
    {
        [Test]
        public void Graph_Remove_Edge_By_Edge_Reference_Test()
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
            graph.RemoveEdge(e1);
            graph.ContainsEdge(e1).Should().BeFalse();
            graph.AreAdjacent('A', 'B').Should().BeFalse();
            a.OutDegree().Should().Be(3);
            b.InDegree().Should().Be(0);
            e1.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, b).Should().BeFalse();

            c.InDegree().Should().Be(1);
            graph.RemoveEdge(e2);
            graph.ContainsEdge(e2).Should().BeFalse();
            graph.AreAdjacent('A', 'C').Should().BeFalse();
            a.OutDegree().Should().Be(2);
            c.InDegree().Should().Be(0);
            e2.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, c).Should().BeFalse();

            Action act1 = () => graph.RemoveEdge(e1);
            act1.Should().Throw<InvalidOperationException>()
                .WithMessage("Edge does not belong to the graph.");

            var vertex1 = new Vertex<char>('F');
            var vertex2 = new Vertex<char>('G');

            var edge1 = new Edge<char>(vertex1, e);
            var edge2 = new Edge<char>(d, vertex1);
            var edge3 = new Edge<char>(vertex1, vertex2);

            Action act2 = () => graph.RemoveEdge(edge1);
            act2.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");

            Action act3 = () => graph.RemoveEdge(edge2);
            act3.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");

            Action act4 = () => graph.RemoveEdge(edge3);
            act4.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");
        }
    }
}