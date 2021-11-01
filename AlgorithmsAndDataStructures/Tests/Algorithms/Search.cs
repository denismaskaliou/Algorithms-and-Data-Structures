using Xunit;

namespace Tests.Algorithms
{
    public sealed class Search
    {
        [Fact]
        public void SearchSubString()
        {
            // Arrange
            var text = "Hello my dear friend";
            var target = "dear";

            // Act
            var beginIndex = -1;

            for (var i = 0; i < text.Length - target.Length; i++)
            {
                var j = 0;
                while (j < target.Length && target[j] == text[i + j])
                {
                    j++;
                }

                if (j == target.Length)
                {
                    beginIndex = i;
                    break;
                }
            }

            // Assert
            Assert.Equal(9, beginIndex);
        }
    }
}