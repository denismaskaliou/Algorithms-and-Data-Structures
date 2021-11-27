using Algorithms.Graphs;
using Algorithms.Infrastructure;
using System.Collections.Generic;
using Xunit;

namespace Tests.Algorithms.Graph
{
    public sealed class ShortestPathTests
    {
        public ShortestPathTests()
        {

        }

        [Fact]
        public void FindShortestPathWithAlgorithmDijkstra()
        {
            // Arrange
            var graph = new Dictionary<int, IList<Edge>>
            {
                { 0, new [] { new Edge(0, 1, 1), new Edge(0, 5, 10) } },
                { 1, new [] { new Edge(1, 0, 1), new Edge(1, 2, 3), new Edge(1, 6, 4) } },
                { 2, new [] { new Edge(2, 1, 3), new Edge(2, 3, 2) } },
                { 3, new [] { new Edge(3, 4, 1), new Edge(3, 2, 2) ,new Edge(3, 6, 1) } },
                { 4, new [] { new Edge(4, 3, 1), new Edge(4, 5, 2) ,new Edge(4, 6, 1) } },
                { 5, new [] { new Edge(5, 0, 10), new Edge(5, 4, 2) } },
                { 6, new [] { new Edge(6, 1, 4), new Edge(6, 3, 1) ,new Edge(6, 4, 1) } }
            };

            // Act
            var (path, summ) = graph.FindShortestPathWithAlgorithmDijkstra(5);
        }
    }
}
