using System;
using GraphAlgorithms.Graph.DepthFirstSearch.Implementation;
using GraphAlgorithms.Graph.Implementations;
using GraphAlgorithms.Graph.Interfaces;

namespace GraphAlgorithms.Graph.DepthFirstSearch.UI
{
    internal static class Program
    {
        private static void Main()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            graph.AddEdge(a, b, 6);
            graph.AddEdge(b, a, 6);

            graph.AddEdge(a, d, 1);
            graph.AddEdge(d, a, 1);

            graph.AddEdge(d, e, 1);
            graph.AddEdge(e, d, 1);

            graph.AddEdge(d, b, 2);
            graph.AddEdge(b, d, 2);

            graph.AddEdge(e, b, 2);
            graph.AddEdge(b, e, 2);

            graph.AddEdge(e, c, 5);
            graph.AddEdge(c, e, 5);

            graph.AddEdge(c, b, 5);
            graph.AddEdge(b, c, 5);
            
            Console.WriteLine("Depth-First recursive traversal: ");
            DepthFirstTraversal<char>.DepthFirstSearchIterative(graph, a);
            
            graph.Reset();
            
            Console.WriteLine("Depth-First iterative path between two vertices: ");
            var depthFirstIterative = DepthFirstTraversal<char>
                .DepthFirstIterative(graph, a, e);

            foreach (var vertex in depthFirstIterative)
            {
                Console.WriteLine(vertex);
            }
        }
    }
}