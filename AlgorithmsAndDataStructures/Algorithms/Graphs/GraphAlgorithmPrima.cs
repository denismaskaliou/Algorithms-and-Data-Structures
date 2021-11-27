using Algorithms.Infrastructure;
using DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public static class GraphAlgorithmPrima
    {
        public static IList<(int V1, int V2, int W)> SearchWithAlgorithmPrima(this IList<(int V1, int V2, int W)> graph, int vertexCount)
        {
            // Init
            var usedVertex = Enumerable.Repeat(false, vertexCount).ToArray();
            var sortedEdgas = graph.OrderBy(x => x.W).ToList();
            var includedEdgas = new List<(int V1, int V2, int W)>();

            // Add first edge
            var firstEdge = sortedEdgas.First();
            usedVertex[firstEdge.V1] = usedVertex[firstEdge.V2] = true;
            includedEdgas.Add(firstEdge);
            sortedEdgas.Remove(firstEdge);

            // Find others
            while (includedEdgas.Count < vertexCount - 1)
                for (var i = 0; i < sortedEdgas.Count; i++)
                {
                    var edge = sortedEdgas[i];

                    if (usedVertex[edge.V1] && !usedVertex[edge.V2] ||
                        usedVertex[edge.V2] && !usedVertex[edge.V1])
                    {
                        usedVertex[edge.V1] = usedVertex[edge.V2] = true;
                        includedEdgas.Add(edge);
                        sortedEdgas.Remove(edge);
                        break;
                    }
                }

            return includedEdgas.OrderBy(x => x.V1).ThenBy(x => x.V2).ToList();
        }

        public static IList<Edge> SearchWithAlgorithmPrima(this IDictionary<int, IList<Edge>> graph)
        {
            // Init
            var usedVertex = Enumerable.Repeat(false, graph.Count).ToArray();
            var heap = new Heap<Edge>();
            var result = new List<Edge>();

            usedVertex[0] = true;
            var minEdge = graph[0]
                .Where(x => usedVertex[x.CurrentVertex] && !usedVertex[x.NextVertex] ||
                            usedVertex[x.NextVertex] && !usedVertex[x.CurrentVertex])
                .OrderBy(x => x.Weight)
                .FirstOrDefault();

            heap.Insert(minEdge);


            while (result.Count <= graph.Count - 1)
            {
                var min = heap.GetMin();
                result.Add(min);
                usedVertex[min.CurrentVertex] = usedVertex[min.NextVertex] = true;

                var firstMinEdge = graph[min.CurrentVertex]
                    .Where(x => usedVertex[x.CurrentVertex] && !usedVertex[x.NextVertex] ||
                                usedVertex[x.NextVertex] && !usedVertex[x.CurrentVertex])
                    .OrderBy(x => x.Weight)
                    .FirstOrDefault();

                if (firstMinEdge != null)
                    heap.Insert(firstMinEdge);

                var secondMinEdge = graph[min.NextVertex]
                    .Where(x => usedVertex[x.CurrentVertex] && !usedVertex[x.NextVertex] ||
                                usedVertex[x.NextVertex] && !usedVertex[x.CurrentVertex])
                    .OrderBy(x => x.Weight)
                    .FirstOrDefault();

                if (secondMinEdge != null)
                    heap.Insert(secondMinEdge);
            }

            return result;
        }
    }
}