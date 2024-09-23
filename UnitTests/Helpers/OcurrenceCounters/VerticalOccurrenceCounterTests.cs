using WordSearchLogic.Helpers.OcurrenceCounters;
using Xunit;

namespace UnitTests.Helpers.OcurrenceCounters
{
    public class VerticalOccurrenceCounterTests
    {
        [Fact]
        public void CountOccurrences_ReturnsCorrectCount_VerticalMatch()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'c', 'a', 't', 's' },
                { 'a', 'a', 't', 'e' },
                { 't', 'a', 't', 'a' },
                { 'd', 'h', 'o', 'g' },
                { 'e', 'r', 'l', 'e' },
            };

            var counter = new VerticalOccurrenceCounter(5, 4, matrix) { Word = "cat" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(1, result); // "cat" appears once vertically.
        }

        [Fact]
        public void CountOccurrences_ReturnsZero_WhenNoMatches()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'c', 'a', 't', 's' },
                { 'o', 'a', 't', 'e' },
                { 'l', 'a', 't', 'a' },
                { 'd', 'h', 'o', 'g' },
                { 'e', 'r', 'l', 'e' },
            };

            var counter = new VerticalOccurrenceCounter(5, 4, matrix) { Word = "dog" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(0, result); // "dog" does not appear vertically.
        }

        [Fact]
        public void CountOccurrences_ReturnsCorrectCount_WithSingleCharacter()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'a', 'b', 'c', 'a' },
                { 'a', 'd', 'e', 'f' },
                { 'a', 'g', 'h', 'i' },
                { 'a', 'j', 'k', 'l' },
            };

            var counter = new VerticalOccurrenceCounter(4, 4, matrix) { Word = "a" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(5, result); // "a" appears 4 times vertically.
        }

        [Fact]
        public void CountOccurrences_ReturnsCorrectCount_WithPartialWord()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'c', 'c', 't' },
                { 'a', 'a', 't' },
                { 'c', 'a', 't' },
            };

            var counter = new VerticalOccurrenceCounter(3, 3, matrix) { Word = "ca" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(2, result); // "ca" appears vertically in each row.
        }
    }
}
