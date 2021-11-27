using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public static class GraphBreadthFirstTraversal
    {
        public static void BreadthFirstTraversal(this IDictionary<int, int[]> graph, int startVertex)
        {
            var distances = Enumerable.Repeat(-1, graph.Count).ToArray();
            distances[0] = 0;

            var parents = new int[graph.Count];

            var queue = new Queue<int>(new[] { startVertex });

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                foreach (var childVertex in graph[currentVertex])
                {
                    if (distances[childVertex] == -1)
                    {
                        distances[childVertex] = distances[currentVertex] + 1;
                        parents[childVertex] = currentVertex;
                        queue.Enqueue(childVertex);
                    }
                }
            }

            var path = new List<int>();
            var parentVertext = parents[13];
            while (parentVertext != startVertex)
            {
                path.Add(parentVertext);
                parentVertext = parents[parentVertext];
            }
        }
    }
}
