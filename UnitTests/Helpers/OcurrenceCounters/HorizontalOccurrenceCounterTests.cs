using WordSearchLogic.Helpers.OcurrenceCounters;
using Xunit;

namespace UnitTests.Helpers.OcurrenceCounters
{
    public class HorizontalOccurrenceCounterTests
    {
        [Fact]
        public void CountOccurrences_ReturnsCorrectCount_HorizontalMatch()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'h', 'e', 'l', 'l', 'o' },
                { 'w', 'o', 'r', 'l', 'd' },
                { 'h', 'e', 'l', 'l', 'o' },
                { 'h', 'i', 's', 'c', 'h' },
            };

            var counter = new HorizontalOccurrenceCounter(4, 5, matrix) { Word = "hello" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(2, result); // "hello" appears twice in the matrix.
        }

        [Fact]
        public void CountOccurrences_ReturnsZero_WhenNoMatches()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'h', 'e', 'l', 'l', 'o' },
                { 'w', 'o', 'r', 'l', 'd' },
                { 'h', 'e', 'l', 'l', 'o' },
                { 'h', 'i', 's', 'c', 'h' },
            };

            var counter = new HorizontalOccurrenceCounter(4, 5, matrix) { Word = "worlds" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(0, result); // "worlds" does not appear.
        }

        [Fact]
        public void CountOccurrences_ReturnsCorrectCount_WithSingleCharacter()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'a', 'b', 'c', 'a', 'a' },
                { 'd', 'a', 'e', 'f', 'g' },
                { 'h', 'a', 'i', 'j', 'k' },
            };

            var counter = new HorizontalOccurrenceCounter(3, 5, matrix) { Word = "a" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(5, result); // "a" appears 5 times in the matrix.
        }

        [Fact]
        public void CountOccurrences_ReturnsCorrectCount_WithPartialWord()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'h', 'e', 'l', 'l', 'o' },
                { 'h', 'e', 'l', 'l', 'o' },
                { 'h', 'e', 'l', 'l', 'o' },
            };

            var counter = new HorizontalOccurrenceCounter(3, 5, matrix) { Word = "he" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(3, result); // "he" appears at the start of each row.
        }
    }
}
