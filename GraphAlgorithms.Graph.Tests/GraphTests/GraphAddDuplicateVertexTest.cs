using System;
using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphAddDuplicateVertexTest
    {
        [Test]
        public void GraphAddDuplicateVertexTest_ShouldThrow()
        {
            var graph = new Graph<char>();
            graph.AddVertex('A');

            Action act = () => graph.AddVertex('A');
            
            act.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Vertex with same data is already in graph.");
        }
    }
}