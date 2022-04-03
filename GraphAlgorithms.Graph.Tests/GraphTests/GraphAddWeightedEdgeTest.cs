using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphAddWeightedEdgeTest
    {
        [Test]
        public void Graph_Add_Weighted_Edge_Test()
        {
            var graph = new Graph<char>();
            var belongToGraph = graph.AddVertex('A');
            var doesNotBelongToGraph = new Vertex<char>('F');

            Action act1 = () => graph.AreAdjacent(doesNotBelongToGraph, belongToGraph);
            
            act1.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");
        }
    }
}