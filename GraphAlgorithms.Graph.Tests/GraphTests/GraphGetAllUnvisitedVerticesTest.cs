using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.GraphTests
{
    [TestFixture]
    public class GraphGetAllUnvisitedVerticesTest
    {
        [Test]
        public void Graph_Get_All_Unvisited_Vertices_Test()
        {
            var graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');
            
            e.Visit();
            var unvisitedVertices = graph.UnvisitedVertices();
            
            unvisitedVertices.Count.Should().Be(4);
            unvisitedVertices[0].Should().Be(a);
            unvisitedVertices[1].Should().Be(b);
            unvisitedVertices[2].Should().Be(c);
            unvisitedVertices[3].Should().Be(d);
        }
    }
}