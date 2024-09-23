using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using WordSearchLogic;

public class MatrixGeneratorBaseTests
{
    private class TestMatrixGenerator : MatrixGeneratorBase
    {
        
    }

    [Fact]
    public void GenerateMatrix_WithEmptyInitialMatrix_ReturnsEmptyMatrix()
    {
        // Arrange
        var generator = new TestMatrixGenerator();
        var initialMatrix = new List<string>();

        // Act
        var result = generator.GenerateMatrix(initialMatrix);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateMatrix_WithInitialMatrix_AddsVerticalWords()
    {
        // Arrange
        var generator = new TestMatrixGenerator();
        var initialMatrix = new List<string>
        {
            "abc",
            "def",
            "ghi"
        };

        // Act
        var result = generator.GenerateMatrix(initialMatrix).ToList();

        // Assert
        Assert.Equal(6, result.Count); // 3 original + 3 vertical
        Assert.Equal("abc", result[0]);
        Assert.Equal("def", result[1]);
        Assert.Equal("ghi", result[2]);
        Assert.Equal("adg", result[3]); // Vertical word
        Assert.Equal("beh", result[4]); // Vertical word
        Assert.Equal("cfi", result[5]); // Vertical word
    }

    [Fact]
    public void AddVerticalWords_WithEmptyMatrix_ReturnsMatrixWithVerticalWords()
    {
        // Arrange
        var generator = new TestMatrixGenerator();
        var initialMatrix = new List<string>();

        // Act
        var result = generator.AddVerticalWords(initialMatrix);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void AddVerticalWords_WithSingleRowMatrix_AddsVerticalWords()
    {
        // Arrange
        var generator = new TestMatrixGenerator();
        var initialMatrix = new List<string> { "abc" };

        // Act
        var result = generator.AddVerticalWords(initialMatrix).ToList();

        // Assert
        Assert.Equal("abc", result[0]);
        Assert.Equal("a", result[1]); // Vertical word
        Assert.Equal("b", result[2]); // Vertical word
        Assert.Equal("c", result[3]); // Vertical word
    }


    //My Assumption its all words have the same length, otherwise, fail
    [Fact]
    public void AddVerticalWords_WithUnevenRowLengths_ThrowsArgumentException()
    {
        // Arrange
        var generator = new TestMatrixGenerator();
        var initialMatrix = new List<string>
        {
            "abc",
            "de" // Uneven row length
        };

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => generator.AddVerticalWords(initialMatrix));
    }
}