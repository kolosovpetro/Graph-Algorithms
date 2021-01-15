using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.Tests
{
    [TestFixture]
    public class GraphAddNotWeightedEdgeTest
    {
        [Test]
        public void Graph_Add_Not_Weighted_Edge_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var edge = graph.AddEdge(a, b);
            edge.Weight.Should().Be(0);
            a.OutDegree().Should().Be(1);
            b.OutDegree().Should().Be(0);
            b.InDegree().Should().Be(1);

            var vertex = new Vertex<char>('F');
            Action act3 = () => graph.AddEdge(vertex, c);
            act3.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertices does not belong to graph.");
        }
    }
}