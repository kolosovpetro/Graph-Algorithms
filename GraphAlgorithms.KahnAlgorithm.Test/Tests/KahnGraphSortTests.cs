using System.Linq;
using FluentAssertions;
using GraphAlgorithms.Graph.Algorithms;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;
using NUnit.Framework;

namespace GraphAlgorithms.KahnAlgorithm.Test.Tests
{
    [TestFixture]
    public class KahnGraphSortTests
    {
        [Test]
        public void KahnAlgorithmTest()
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
            var topologicalSort = KahnGraphSort<string>.KahnSort(stringGraph);
            var kahnSortArray = topologicalSort as IVertex<string>[] ?? topologicalSort.ToArray();
            kahnSortArray[0].Data.Should().Be("undershorts");
            kahnSortArray[1].Data.Should().Be("shirt");
            kahnSortArray[2].Data.Should().Be("socks");
            kahnSortArray[3].Data.Should().Be("watch");
            kahnSortArray[4].Data.Should().Be("pants");
            kahnSortArray[5].Data.Should().Be("tie");
            kahnSortArray[6].Data.Should().Be("belt");
            kahnSortArray[7].Data.Should().Be("shoes");
            kahnSortArray[8].Data.Should().Be("jacket");

            stringGraph.IsEmpty.Should().BeTrue();
        }
    }
}