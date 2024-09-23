using _wordSearchLogic.Helpers.OcurrenceCounters;
using Moq;
using Xunit;

namespace UnitTests.Helpers.OcurrenceCounters
{
    public class OccurrenceCounterBaseTests
    {
        [Fact]
        public void CountOccurrences_ReturnsZero_WhenNoMatches()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'a', 'b', 'c' },
                { 'd', 'e', 'f' },
                { 'g', 'h', 'i' },
            };

            var counter = new TestOccurrenceCounter(3, 3, matrix) { Word = "xyz" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(0, result); // No occurrences of "xyz"
        }

        [Fact]
        public void CountOccurrences_ReturnsCorrectCount_WhenMatchesExist()
        {
            // Arrange
            char[,] matrix = new char[,]
            {
                { 'c', 'a', 't', 's' },
                { 'c', 'a', 't', 'e' },
                { 'c', 'a', 't', 'a' },
            };

            var counter = new TestOccurrenceCounter(3, 4, matrix) { Word = "cat" };

            // Act
            var result = counter.CountOccurrences();

            // Assert
            Assert.Equal(3, result); // "cat" appears 3 times horizontally.
        }

        public class TestOccurrenceCounter : OccurrenceCounterBase<char>
        {
            public TestOccurrenceCounter(int rows, int cols, char[,] matrix)
                : base(rows, cols, matrix) { }

            protected override int GetOuterLimit() => _rows;

            protected override int GetInnerLimit() => _cols - _word.Length;

            protected override bool IsMatch(int fixedIndex, int iteratorIndex)
            {
                for (int k = 0; k < _word.Length; k++)
                    if (_matrix[fixedIndex, iteratorIndex + k] != _word[k])
                        return false;

                return true;
            }
        }
    }
}
