using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphAddEdgeWhenVertexDoesNotBelongToGraph
    {
        [Test]
        public void GraphAddEdgeWhenVertexDoesNotBelongToGraph_Test()
        {
            var graph = new Graph<char>();
            var vertexBelongsToGraph = graph.AddVertex('C');
            var vertexDoesntBelongToGraph = new Vertex<char>('F');
            
            Action addEdge = () => graph.AddEdge(vertexDoesntBelongToGraph, vertexBelongsToGraph);
            
            addEdge.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");
        }
    }
}