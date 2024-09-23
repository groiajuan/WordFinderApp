using System;
using System.Collections.Generic;
using System.Linq;
using WordSearchLogic.Helpers;
using Xunit;

namespace UnitTests.Helpers
{
    public class StringListToCharMatrixConverterTests
    {
        [Fact]
        public void ConvertToCharMatrix_ValidInput_ReturnsCorrectMatrix()
        {
            // Arrange
            var stringList = new List<string>
            {
                "hello",
                "world",
                "tests"
            };

            char[,] expectedMatrix = new char[,]
            {
                { 'h', 'e', 'l', 'l', 'o' },
                { 'w', 'o', 'r', 'l', 'd' },
                { 't', 'e', 's', 't', 's' } // Assuming padding with spaces
            };

            // Act
            var result = StringListToCharMatrixConverter.ConvertToCharMatrix(stringList);

            // Assert
            Assert.Equal(expectedMatrix.GetLength(0), result.GetLength(0)); // Check row count
            Assert.Equal(expectedMatrix.GetLength(1), result.GetLength(1)); // Check column count

            // Check each character
            for (int i = 0; i < expectedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < expectedMatrix.GetLength(1); j++)
                {
                    Assert.Equal(expectedMatrix[i, j], result[i, j]);
                }
            }
        }

        [Fact]
        public void ConvertToCharMatrix_NullList_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                StringListToCharMatrixConverter.ConvertToCharMatrix(null));
        }

    }
}
