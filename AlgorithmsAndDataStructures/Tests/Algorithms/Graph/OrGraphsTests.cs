using Algorithms.Graphs;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Algorithms.Graph
{
    public sealed class OrGraphsTests
    {
        private readonly ITestOutputHelper _output;
        private IDictionary<int, int[]> _graph;

        public OrGraphsTests(ITestOutputHelper output)
        {
            _output = output;
            _graph = new Dictionary<int, int[]>
            {
                { 0, new[] { 3, 4} },
                { 1, new[] { 3} },
                { 2, new[] { 4, 7 } },
                { 3, new[] { 5, 6, 7 } },
                { 4, new[] { 6 } },
                { 5, null },
                { 6, null },
                { 7, null }
            };
        }

        [Fact]
        public void TopSort_ShoudSortGraph()
        {
            // Act
            var result = _graph.TopSort();

            // Assert
            Assert.Equal(new int[] { 2, 1, 0, 4, 3, 7, 6, 5 }, result);
            _output.WriteLine(result.Select(x => x.ToString()).Aggregate((b, x) => $"{b} {x}"));
        }

        [Fact]
        public void Kosaraju_ShoudFindStrongComponents()
        {
            // Arrange
            _graph = new Dictionary<int, int[]>
            {
                { 0, new[] { 1, 2, 3 } },
                { 1, new[] { 2, 4 } },
                { 2, null },
                { 3, new[] { 5 } },
                { 4, new[] { 1 } },
                { 5, new[] { 0, 1 } }
            };

            // Act
            var components = _graph.Kosaraju();

            // Assert
            Assert.Equal(3, components.GroupBy(x => x).Count());
            Assert.Equal(new int[] { 0, 1, 2, 0, 1, 0 }, components);
        }
    }
}
