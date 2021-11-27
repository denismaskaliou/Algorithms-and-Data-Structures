using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public static class GraphTopSort
    {
        public static IEnumerable<int> TopSort(this IDictionary<int, int[]> graph)
        {
            var sorted = new List<int>(graph.Count);
            var visited = Enumerable.Repeat(false, graph.Count).ToArray();

            foreach (var vertex in graph.Keys)
                if (!visited[vertex])
                    Dfs(graph, vertex, visited, sorted);

            return (sorted as IEnumerable<int>).Reverse();
        }

        public static void Dfs(IDictionary<int, int[]> graph, int currentVertex, bool[] visited, IList<int> sorted)
        {
            visited[currentVertex] = true;

            if (graph[currentVertex] != null)
                foreach (var childVertex in graph[currentVertex])
                    if (!visited[childVertex])
                        Dfs(graph, childVertex, visited, sorted);

            sorted.Add(currentVertex);
        }
    }
}