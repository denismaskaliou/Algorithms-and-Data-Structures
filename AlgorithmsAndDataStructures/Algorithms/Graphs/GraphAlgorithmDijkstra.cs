using Algorithms.Infrastructure;
using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public static class GraphAlgorithmDijkstra
    {
        public static (List<int> path, int summ) FindShortestPathWithAlgorithmDijkstra(this IDictionary<int, IList<Edge>> graph, int tagetVertex)
        {
            // Init
            var usedVertexes = Enumerable.Repeat(false, graph.Count).ToArray();
            var distances = Enumerable.Repeat(int.MaxValue, graph.Count).ToArray();
            var parrents = Enumerable.Repeat(-1, graph.Count).ToArray();
            var heap = new Heap<Dist>();

            // set start vertex
            distances[0] = 0;
            heap.Insert(new Dist { Vertex = 0, Distance = 0 });

            // go around all vertexs
            var counter = 1;
            while (counter <= graph.Count - 1)
            {
                var minDist = heap.GetMin();
                usedVertexes[minDist.Vertex] = true;

                foreach (var edge in graph[minDist.Vertex])
                    if (!usedVertexes[edge.NextVertex] && 
                        (distances[edge.CurrentVertex] + edge.Weight) < distances[edge.NextVertex])
                    {
                        distances[edge.NextVertex] = distances[edge.CurrentVertex] + edge.Weight;
                        parrents[edge.NextVertex] = edge.CurrentVertex;
                        heap.Insert(new Dist { Vertex = edge.NextVertex, Distance = distances[edge.NextVertex] });
                    }

                counter++;
            }

            // build path
            var path = new List<int>();

            var parrentVertex = parrents[tagetVertex];
            while (parrentVertex != 0)
            {
                path.Add(parrentVertex);
                parrentVertex = parrents[parrentVertex];
            }
            path.Reverse();

            return (path, distances[tagetVertex]);
        }


        public struct Dist : IComparable<Dist>
        {
            public int Vertex { get; set; }
            public int Distance { get; set; }

            public int CompareTo(Dist other)
            {
                return Distance > other.Distance
                    ? 1
                    : Distance == other.Distance
                        ? 0
                        : -1;
            }
        }
    }
}