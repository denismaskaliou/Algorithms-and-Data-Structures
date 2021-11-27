using Algorithms.Graphs;
using Algorithms.Infrastructure;
using System.Collections.Generic;
using Xunit;

namespace Tests.Algorithms.Graph
{
    public sealed class SpanningTreeTests
    {

        [Fact]
        public void SearchMinSpanningTreeV1()
        {
            // Arrange
            var graph = new List<(int V1, int V2, int W)>
            {
                ( 0, 1, 2 ), // 0
                ( 1, 2, 1 ), // 1
                ( 2, 3, 8 ), // 2
                ( 3, 4, 3 ), // 3
                ( 4, 5, 9 ), // 4
                ( 0, 5, 4 ), // 5
                ( 1, 5, 6 ), // 6
                ( 1, 6, 3 ), // 7
                ( 2, 6, 6 ), // 8
                ( 3, 6, 4 ), // 9
                ( 4, 6, 12 ),// 10
                ( 5, 6, 8 )  // 11
            };

            // Act
            var spanningTree = graph.SearchWithAlgorithmPrima(vertexCount: 7);

            // Assert
            Assert.Equal(
                new[] { graph[0], graph[5], graph[1], graph[7], graph[3], graph[9] },
                spanningTree);
        }

        [Fact]
        public void SearchMinSpanningTreeV2()
        {
            // Arrange
            var graph = new Dictionary<int, IList<Edge>>
            {
                { 0, new [] { new Edge(0, 1, 2), new Edge(0, 4, 1) ,new Edge(0, 3, 3) } },
                { 1, new [] { new Edge(1, 0, 2), new Edge(1, 2, 1) } },
                { 2, new [] { new Edge(2, 1, 1), new Edge(2, 3, 2) ,new Edge(2, 4, 5) } },
                { 3, new [] { new Edge(3, 2, 2), new Edge(3, 0, 3) ,new Edge(3, 4, 4) } },
                { 4, new [] { new Edge(4, 0, 1), new Edge(4, 2, 5) ,new Edge(4, 3, 4) } },
            };

            // Act
            var spanningTree = graph.SearchWithAlgorithmPrima();

            // Assert

        }

        [Fact]
        public void MinSpanningTreeWithAlgorithmKruskal()
        {
            // Arrange
            var graph = new[]
            {
                new Edge(0, 1, 2),
                new Edge(0, 4, 5),
                new Edge(1, 2, 8),
                new Edge(2, 3, 2),
                new Edge(2, 5, 7),
                new Edge(3, 5, 3),
                new Edge(4, 5, 4)
            };

            // Act
            var spanningTree = graph.MinSpanningTreeWithAlgorithmKruskal(vertexCount: 6);

            // Assert

        }
    }
}
