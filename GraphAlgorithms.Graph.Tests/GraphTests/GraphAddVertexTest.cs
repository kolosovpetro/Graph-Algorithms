using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphAddVertexTest
    {
        [Test]
        public void Graph_Add_Vertex_Test()
        {
            IGraph<char> graph = new Graph<char>();
            graph.AddVertex('A');
            graph.AddVertex('B');

            Action act = () => graph.AddVertex('A');
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex with same data is already in graph.");
        }
    }
}