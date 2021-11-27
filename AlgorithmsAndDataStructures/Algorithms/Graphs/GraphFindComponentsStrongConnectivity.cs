using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public static class GraphFindComponentsStrongConnectivity
    {
        public static int[] Kosaraju(this IDictionary<int, int[]> graph)
        {
            var visited = Enumerable.Repeat(false, graph.Count).ToArray();
            var tOut = new List<int>();
            var components = Enumerable.Repeat(-1, graph.Count).ToArray();

            foreach (var vertex in graph.Keys)
                if (!visited[vertex])
                    Dfs(graph, vertex, visited, tOut);

            visited = Enumerable.Repeat(false, graph.Count).ToArray();
            var reversedGraph = ReverseGraph(graph);

            var componentNumber = 0;
            foreach (var vertex in (tOut as IEnumerable<int>).Reverse())
                if (!visited[vertex])
                    Dfs2(reversedGraph, vertex, visited, components, componentNumber++);

            return components;
        }

        private static void Dfs(
            this IDictionary<int, int[]> graph,
            int currentVertex,
            bool[] visited,
            List<int> outList)
        {
            visited[currentVertex] = true;

            if (graph[currentVertex] != null)
                foreach (var vertex in graph[currentVertex])
                    if (!visited[vertex])
                        Dfs(graph, vertex, visited, outList);

            outList.Add(currentVertex);
        }

        private static void Dfs2(
            this IDictionary<int, List<int>> graph,
            int currentVertex,
            bool[] visited,
            int[] components,
            int componentNumber)
        {
            visited[currentVertex] = true;
            components[currentVertex] = componentNumber;

            if (graph[currentVertex] != null)
                foreach (var vertex in graph[currentVertex])
                    if (!visited[vertex])
                        Dfs2(graph, vertex, visited, components, componentNumber);
        }

        private static IDictionary<int, List<int>> ReverseGraph(IDictionary<int, int[]> graph)
        {
            var newGraph = new Dictionary<int, List<int>>();

            for (var i = 0; i < graph.Count; i++)
                newGraph.Add(i, null);

            foreach (var keyValuePair in graph)
                if (keyValuePair.Value != null)
                    foreach (var vertex in keyValuePair.Value)
                        (newGraph[vertex] ??= new List<int>()).Add(keyValuePair.Key);

            return newGraph;
        }

    }
}