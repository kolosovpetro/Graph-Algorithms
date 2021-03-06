﻿using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphRemoveVertexByVertexReferenceTest
    {
        [Test]
        public void Graph_Remove_Vertex_By_Vertex_Reference_Test()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(e, d, 7);
            var e3 = graph.AddEdge(d, a, 8);
            var e4 = graph.AddEdge(c, e, 9);

            graph.RemoveVertex(a);
            graph.Count.Should().Be(4);
            graph.Edges.Count.Should().Be(2);
            graph.ContainsVertex(a).Should().BeFalse();
            graph.ContainsVertex('A').Should().BeFalse();
            a.CurrentGraph.Should().BeNull();

            Action act = () => graph.RemoveVertex(a);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");

            // test removed vertex InDegree and OutDegree exception
            Action inDegree = () => a.InDegree();
            inDegree.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to any graph.");

            Action outDegree = () => a.OutDegree();
            outDegree.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to any graph.");
        }
    }
}