using Algorithms.Infrastructure;
using DataStructures;
using System.Collections.Generic;

namespace Algorithms.Graphs
{
    public static class GraphAlgorithmKruskal
    {
        public static IList<Edge> MinSpanningTreeWithAlgorithmKruskal(this Edge[] graph, int vertexCount)
        {
            var spanningTree = new List<Edge>();

            var heap = new Heap<Edge>(graph);
            var unionSet = new UnionSet(graph.Length);

            while (spanningTree.Count < vertexCount - 1)
            {
                var edge = heap.GetMin();
                if (unionSet.Find(edge.CurrentVertex) != unionSet.Find(edge.NextVertex))
                {
                    unionSet.Union(edge.CurrentVertex, edge.NextVertex);
                    spanningTree.Add(edge);
                }
            }

            return spanningTree;
        }
    }
}
