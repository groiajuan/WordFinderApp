using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using WordSearchLogic;

namespace WordSearch.Tests
{
    public class WordFinderWithGeneratedMatrixTests
    {
        [Fact]
        public void Constructor_NullMatrix_ThrowsArgumentException()
        {
            // Arrange
            IEnumerable<string> matrix = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new WordFinderWithGeneratedMatrix(matrix));
            Assert.Equal($"The Matrix cannot be null or empty", exception.Message);
        }

        [Fact]
        public void Constructor_EmptyMatrix_ThrowsArgumentException()
        {
            // Arrange
            var matrix = new List<string>();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new WordFinderWithGeneratedMatrix(matrix));
            Assert.Equal($"The Matrix cannot be null or empty", exception.Message);
        }

        [Fact]
        public void Find_InvalidWords_ThrowsArgumentException()
        {
            // Arrange
            var matrix = new List<string>
            {
                "hello",
                "world",
                "helloworld"
            };
            var exception = Assert.Throws<ArgumentException>(() => new WordFinderWithGeneratedMatrix(matrix));
            Assert.Equal($"All words on the Matrix must have the same Length", exception.Message);
        }

        [Fact]
        public void Find_DistinctWords_ReturnsCorrectCount()
        {
            // Arrange
            var matrix = new List<string>
            {
                "testtest",
                "testabcd"
            };
            var wordFinder = new WordFinderWithGeneratedMatrix(matrix);
            var wordsToFind = new List<string> { "test", "abcd","test"};

            // Act
            var foundWords = wordFinder.Find(wordsToFind).ToList();

            // Assert
            Assert.Contains("test", foundWords);
            Assert.Equal(2, foundWords.Count); // Solo debe devolver "test" una vez
        }

        [Fact]
        public void Find_EmptyWordStream_ReturnsEmpty()
        {
            // Arrange
            var matrix = new List<string>
            {
                "sample"
            };
            var wordFinder = new WordFinderWithGeneratedMatrix(matrix);
            var wordsToFind = new List<string>();

            // Act
            var foundWords = wordFinder.Find(wordsToFind);

            // Assert
            Assert.Empty(foundWords);
        }
    }
}