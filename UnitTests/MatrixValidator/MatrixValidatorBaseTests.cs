using System;
using System.Collections.Generic;
using System.Linq;
using WordSearchLogic;
using Xunit;

public class MatrixValidatorBaseTests
{
    // Clase de implementación concreta para pruebas
    private class TestMatrixValidator : MatrixValidatorBase
    {
        public TestMatrixValidator(int? rowLimits = null, int? columnLimits = null)
            : base(rowLimits, columnLimits) { }

        public override void ExecuteOtherValidations(IEnumerable<string> matrix)
        {

        }
    }

    [Fact]
    public void ExecuteValidations_NullMatrix_ThrowsArgumentException()
    {
        var validator = new TestMatrixValidator();
        var exception = Assert.Throws<ArgumentException>(() => validator.ExecuteValidations(null));
        Assert.Equal($"The Matrix cannot be null or empty", exception.Message);

    }

    [Fact]
    public void ExecuteValidations_EmptyMatrix_ThrowsArgumentException()
    {
        var validator = new TestMatrixValidator();
        var exception = Assert.Throws<ArgumentException>(() => validator.ExecuteValidations(Enumerable.Empty<string>()));
        Assert.Equal($"The Matrix cannot be null or empty", exception.Message);

    }

    [Fact]
    public void ExecuteValidations_ValidMatrix_NoException()
    {
        var validator = new TestMatrixValidator();
        var matrix = new List<string> { "abc", "def", "ghi" };
        // No debería lanzar ninguna excepción
        validator.ExecuteValidations(matrix);
    }

    [Fact]
    public void ValidateMatrixMaxSize_ExceedsRowLimit_ThrowsArgumentException()
    {
        var validator = new TestMatrixValidator(2, null);
        var matrix = new List<string> { "abc", "def", "ghi" };
        var exception = Assert.Throws<ArgumentException>(() => validator.ExecuteValidations(matrix));
        Assert.Equal("The Matrix cannot be larger than 2 x ", exception.Message);
    }

    [Fact]
    public void ValidateMatrixMaxSize_ExceedsColumnLimit_ThrowsArgumentException()
    {
        var validator = new TestMatrixValidator(null, 2);
        var matrix = new List<string> { "abc", "de" };
        var exception = Assert.Throws<ArgumentException>(() => validator.ExecuteValidations(matrix));
        Assert.Equal("The Matrix cannot be larger than  x 2", exception.Message);
    }

    [Fact]
    public void ValidateMatrixMaxSize_ValidSize_NoException()
    {
        var validator = new TestMatrixValidator(3, 3);
        var matrix = new List<string> { "ab", "cd", "ef" };
        validator.ExecuteValidations(matrix);
    }
}