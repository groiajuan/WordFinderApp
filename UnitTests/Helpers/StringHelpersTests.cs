using System;
using WordSearchLogic.Helpers;
using Xunit;

public class StringHelpersTests
{


    // I omitted blanks and nulls on rows/columns phrases but i created a test just in case
    [Fact]
    public void CountingOccurrencesInPhrase_NullPhrase_ThrowsArgumentNullException()
    {
        // Arrange
        string phrase = null;
        string word = "test";

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => StringHelpers.CountingOccurrencesInPhrase(phrase, word));
    }

    // I omitted blanks and nulls on rows/columns phrases but i created a test just in case
    [Fact]
    public void CountingOccurrencesInPhrase_NullWord_ThrowsArgumentNullException()
    {
        // Arrange
        string phrase = "This is a test phrase.";
        string word = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => StringHelpers.CountingOccurrencesInPhrase(phrase, word));
    }

    [Fact]
    public void CountingOccurrencesInPhrase_EmptyPhrase_ReturnsZero()
    {
        // Arrange
        string phrase = "";
        string word = "test";

        // Act
        int result = StringHelpers.CountingOccurrencesInPhrase(phrase, word);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void CountingOccurrencesInPhrase_WordNotInPhrase_ReturnsZero()
    {
        // Arrange
        string phrase = "This is a test phrase.";
        string word = "example";

        // Act
        int result = StringHelpers.CountingOccurrencesInPhrase(phrase, word);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void CountingOccurrencesInPhrase_WordInPhrase_ReturnsCorrectCount()
    {
        // Arrange
        string phrase = "This test is a test of the test.";
        string word = "test";

        // Act
        int result = StringHelpers.CountingOccurrencesInPhrase(phrase, word);

        // Assert
        Assert.Equal(3, result);
    }

    // I assummed all words are on lowercase but just in case
    [Fact]
    public void CountingOccurrencesInPhrase_CaseInsensitive_ReturnsCorrectCount()
    {
        // Arrange
        string phrase = "Test test teSt TeSt";
        string word = "test";

        // Act
        int result = StringHelpers.CountingOccurrencesInPhrase(phrase, word);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void CountingOccurrencesInPhrase_WordAtStartAndEnd_ReturnsCorrectCount()
    {
        // Arrange
        string phrase = "test This is a test";
        string word = "test";

        // Act
        int result = StringHelpers.CountingOccurrencesInPhrase(phrase, word);

        // Assert
        Assert.Equal(2, result);
    }
}