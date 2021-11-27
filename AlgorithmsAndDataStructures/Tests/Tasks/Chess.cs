using Algorithms.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Tasks
{
    public sealed class Chess
    {
        private readonly IDictionary<string, IList<string>> _graph;

        public Chess()
        {
            _graph = new Dictionary<string, IList<string>>();
        }

        [Fact]
        public void Chees_FindShortestWayForHorse()
        {
            // Arrange
            var latters = "abcdefgh";
            var numbers = "12345678";

            (int l, int n)[] offsets = new[]
            {
                (-2, +1),
                (-1, +2),
                (+1, +2),
                (+2, +1),
                (+2, -1),
                (+1, -2),
                (-1, -2),
                (-2, -1)
            };

            for (var l = 0; l < latters.Length; l++)
                for (var n = 0; n < numbers.Length; n++)
                {
                    _graph.Add(
                        key: $"{latters[l]}{numbers[n]}",
                        value: offsets
                                .Where(offset => NotLess0AndNotMoreThan8(l, n, offset))
                                .Select(offset => $"{latters[l + offset.l]}{numbers[n + offset.n]}")
                                .ToList());
                }

            // Act
            var result = _graph.FindShortestWayForHorse(startPoint: "d4", targetPoint: "f7");

            // Assert
            Assert.Equal(2, result.Length);
        }

        private bool NotLess0AndNotMoreThan8(int l, int n, (int l, int n) offset) =>
            l + offset.l > 0 && l + offset.l < 8 && n + offset.n > 0 && n + offset.n < 8;
    }
}
