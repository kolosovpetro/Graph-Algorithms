using FluentAssertions;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.Graph.Tests.Tests
{
    [TestFixture]
    public class GraphIsAcyclicTest
    {
        [Test]
        public void Graph_Is_Acyclic_Test()
        {
            // example from lecture notes
            
            IGraph<string> stringGraph = new Graph<string>();
            var undershorts = stringGraph.AddVertex("undershorts");
            var pants = stringGraph.AddVertex("pants");
            var belt = stringGraph.AddVertex("belt");
            var jacket = stringGraph.AddVertex("jacket");
            var tie = stringGraph.AddVertex("tie");
            var shirt = stringGraph.AddVertex("shirt");
            var shoes = stringGraph.AddVertex("shoes");
            var socks = stringGraph.AddVertex("socks");
            var watch = stringGraph.AddVertex("watch");

            stringGraph.AddEdge(undershorts, pants);
            stringGraph.AddEdge(undershorts, shoes);
            stringGraph.AddEdge(pants, belt);
            stringGraph.AddEdge(pants, shoes);
            stringGraph.AddEdge(belt, jacket);
            stringGraph.AddEdge(tie, jacket);
            stringGraph.AddEdge(shirt, tie);
            stringGraph.AddEdge(shirt, belt);
            stringGraph.AddEdge(socks, shoes);

            stringGraph.IsAcyclic().Should().BeTrue();
        }
    }
}