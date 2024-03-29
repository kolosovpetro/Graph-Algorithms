﻿using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphGetEdgesThatContainVertexTest
    {
        [Test]
        public void Graph_Get_Edges_That_Contain_Vertex_Test()
        {
            var graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');
            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(a, d, 7);
            var e3 = graph.AddEdge(d, b, 8);
            var e4 = graph.AddEdge(c, a, 9);
            var vertex = new Vertex<char>('F');

            var containVertex = graph.EdgesContainVertex(a);
            Action act = () => graph.EdgesContainVertex(vertex);
            
            containVertex.Count.Should().Be(3);
            containVertex[0].Should().Be(e1);
            containVertex[1].Should().Be(e2);
            containVertex[2].Should().Be(e4);
            act.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }
    }
}