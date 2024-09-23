using System;
using System.Collections.Generic;
using System.Linq;
using WordSearchLogic;
using Xunit;

namespace UnitTests
{
  
    public class Matrix64ValidatorTests
    {

        [Fact]
        public void ExecuteValidations_VariableLengthWords_ThrowsArgumentException()
        {
            var validator = new Matrix64Validator();
            var matrix = new List<string> { "abcd", "efg", "hijkl" };
            var exception = Assert.Throws<ArgumentException>(() => validator.ExecuteValidations(matrix));
            Assert.Equal("All words on the Matrix must have the same Length", exception.Message);
        }

        [Fact]
        public void ExecuteValidations_ValidMatrix_NoException()
        {
            var validator = new Matrix64Validator();
            var matrix = new List<string> { "abcd", "efgh", "ijkl" };
            validator.ExecuteValidations(matrix);
        }

        [Fact]
        public void ValidateMatrixMaxSize_ExceedsRowLimit_ThrowsArgumentException()
        {
            var validator = new Matrix64Validator();
            var matrix = new List<string>(Enumerable.Repeat("a", 65)); // 65 rows
            var exception = Assert.Throws<ArgumentException>(() => validator.ExecuteValidations(matrix));
            Assert.Equal("The Matrix cannot be larger than 64 x 64", exception.Message);
        }

        [Fact]
        public void ValidateMatrixMaxSize_ExceedsColumnLimit_ThrowsArgumentException()
        {
            var validator = new Matrix64Validator();
            var matrix = new List<string> { new string('a', 65) }; // 65 columns
            var exception = Assert.Throws<ArgumentException>(() => validator.ExecuteValidations(matrix));
            Assert.Equal("The Matrix cannot be larger than 64 x 64", exception.Message);
        }

        [Fact]
        public void ValidateMatrixMaxSize_ValidSize_NoException()
        {
            var validator = new Matrix64Validator();
            var matrix = new List<string>(Enumerable.Repeat(new string('a', 64), 64)); // 64 rows, 64 columns
                                                                                       // No throw exceptions
            validator.ExecuteValidations(matrix);
        }
    }
}
