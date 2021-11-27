using System.Collections.Generic;

namespace Algorithms.Graphs
{
    public static class GraphDepthFirstTraversal
    {
        public static void DepthFirstTraversal(this IDictionary<int, int[]> graph, int currentVertex, IList<int> ussed = null)
        {
            ussed ??= new List<int>();
            ussed.Add(currentVertex);

            foreach (var neighborVertex in graph[currentVertex])
                if (!ussed.Contains(neighborVertex))
                    DepthFirstTraversal(graph, neighborVertex, ussed);
        }
    }
}
