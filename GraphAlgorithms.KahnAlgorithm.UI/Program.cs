using System;
using GraphAlgorithms.Graph.Algorithms;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;

namespace GraphAlgorithms.KahnAlgorithm.UI
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Kahn topological sort test: ");
            IGraph<string> stringGraph = new Graph<string>();
            var undershorts = stringGraph.AddVertex("undershorts");
            var pants = stringGraph.AddVertex("pants");
            var belt = stringGraph.AddVertex("belt");
            var jacket = stringGraph.AddVertex("jacket");
            var tie = stringGraph.AddVertex("tie");
            var shirt = stringGraph.AddVertex("shirt");
            var shoes = stringGraph.AddVertex("shoes");
            var socks = stringGraph.AddVertex("socks");
            stringGraph.AddVertex("watch");

            stringGraph.AddEdge(undershorts, pants);
            stringGraph.AddEdge(undershorts, shoes);
            stringGraph.AddEdge(pants, belt);
            stringGraph.AddEdge(pants, shoes);
            stringGraph.AddEdge(belt, jacket);
            stringGraph.AddEdge(tie, jacket);
            stringGraph.AddEdge(shirt, tie);
            stringGraph.AddEdge(shirt, belt);
            stringGraph.AddEdge(socks, shoes);

            var topologicalSort = KahnGraphSort<string>.KahnSort(stringGraph);

            foreach (var vertex in topologicalSort)
            {
                Console.WriteLine(vertex);
            }
        }
    }
}