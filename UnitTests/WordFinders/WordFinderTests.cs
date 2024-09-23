using Moq;
using System.Collections.Generic;
using System.Linq;
using WordSearchLogic;
using WordSearchLogic.Helpers;
using WordSearchLogic.Helpers.OcurrenceCounters;
using WordSearchLogic.WordFinders;
using Xunit;

namespace UnitTests.WordFinders;

    public class WordFinderTests
    {
        [Fact]
        public void Find_ReturnsFoundWords()
        {
            // Arrange
            var inputMatrix = new List<string>
                {
                    "hello",
                    "world",
                    "hello",
                    "there"
                };

            var wordstream = new List<string> { "hello", "world", "foo" };

            // Create the WordFinder with actual implementations
            var wordFinder = new WordFinder(inputMatrix);

            // Act
            var result = wordFinder.Find(wordstream);

            // Assert
            Assert.Contains("hello", result);
            Assert.Contains("world", result);
            Assert.DoesNotContain("foo", result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Find_ReturnsTop10Words()
        {
            // Arrange
            var inputMatrix = new List<string>
                {
                    "abzzzzzzzzzzzzzzzz", "bbzzzzzzzzzzzzzzzz", "cbzzzzzzzzzzzzzzzz", "dbzzzzzzzzzzzzzzzz", "ebzzzzzzzzzzzzzzzz", "fbzzzzzzzzzzzzzzzz", "gbzzzzzzzzzzzzzzzz", "hbzzzzzzzzzzzzzzzz", "ibzzzzzzzzzzzzzzzz", "jbzzzzzzzzzzzzzzzz", "kbzzzzzzzzzzzzzzzz", "lbzzzzzzzzzzzzzzzz", "mbzzzzzzzzzzzzzzzz", "nbzzzzzzzzzzzzzzzz", "obzzzzzzzzzzzzzzzz","abzzzzzzzzzzzzzzzz","ebzzzzzzzzzzzzzzzz","abzzzzzzzzzzzzzzzz"
                };

            var wordstream = new List<string> { "ab", "bb", "cb", "db", "eb", "fb", "gb", "hb", "ib", "jb", "kb", "lb", "mb", "nb", "ob","ob","dd","yy"};

            // Create the WordFinder with actual implementations
            var wordFinder = new WordFinder(inputMatrix);

            // Act
            var result = wordFinder.Find(wordstream);

            // Assert
            Assert.Equal(10, result.Count());// Should return 10 found words
            Assert.Equal("bb", result.First());
            Assert.Equal("ab", result.ElementAt(1));
            Assert.Equal("eb", result.ElementAt(2));
    }

        [Fact]
        public void Find_ReturnsEmpty_WhenNoWordsFound()
        {
            // Arrange
            var inputMatrix = new List<string> { "abcd", "efgh", "ijkl" };
            var wordstream = new List<string> { "xyz", "pqr" };

            // Create the WordFinder with actual implementations
            var wordFinder = new WordFinder(inputMatrix);

            // Act
            var result = wordFinder.Find(wordstream);

            // Assert
            Assert.Empty(result); // No words should be found
        }
    }


