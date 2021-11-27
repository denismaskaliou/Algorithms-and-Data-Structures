using Algorithms.Graphs;
using System.Collections.Generic;
using Xunit;

namespace Tests.Algorithms.Graph
{
    public sealed class GraphTraversalTests
    {
        private readonly IDictionary<int, int[]> _graph;

        public GraphTraversalTests()
        {
            _graph = new Dictionary<int, int[]>
            {
                { 0, new[] { 1, 10, 11, 12 } },
                { 1, new[] { 0, 7} },
                { 2, new[] { 6 } },
                { 3, new[] { 11 } },
                { 4, new[] { 6, 10 } },
                { 5, new[] { 8, 13 } },
                { 6, new[] { 2, 4, 10 } },
                { 7, new[] { 1, 13 } },
                { 8, new[] { 5, 12 } },
                { 9, new[] { 11 } },
                { 10, new[] { 0, 4, 6 } },
                { 11, new[] { 0, 3, 9, 12, 14 } },
                { 12, new[] { 0, 8, 11 } },
                { 13, new[] { 5, 7 } },
                { 14, new[] { 11 } }
            };
        }

        [Fact]
        public void BreadthFirstTraversal()
        {
            // Act
            _graph.BreadthFirstTraversal(0);
        }

        [Fact]
        public void DepthFirstTraversal()
        {
            // Act
            _graph.DepthFirstTraversal(0);
        }
    }
}
