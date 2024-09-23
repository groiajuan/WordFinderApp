//This consumes a little more memory but for a 64x64 matrix it is insignificant. Basically it is a solution that adds new words by taking the columns.
namespace WordSearchLogic;
public abstract class MatrixGeneratorBase : IMatrixGenerator
{
     public virtual IEnumerable<string> GenerateMatrix(IEnumerable<string> initialMatrix)
    {
        if (!initialMatrix.Any())
            return initialMatrix;

        var _matrix = (ICollection<string>)initialMatrix;

        _matrix = AddVerticalWords(_matrix);

        return _matrix;
    }

    public virtual ICollection<string> AddVerticalWords(ICollection<string> matrix)
    {
        if (!matrix.Any())
            return matrix;

        int columnCount = matrix.First().Length;
        int rowCount = matrix.Count;

        for (int col = 0; col < columnCount; col++)
        {
            var columnWord = new char[rowCount];
            for (int row = 0; row < rowCount; row++)
            {
                columnWord[row] = matrix.ElementAt(row)[col];
            }
            matrix.Add(new string(columnWord));
        }

        return matrix;
    }

    
}
    

