namespace WordSearchLogic;
    public interface IMatrixGenerator
    {
        IEnumerable<string> GenerateMatrix(IEnumerable<string> initialMatrix);
        ICollection<string> AddVerticalWords(ICollection<string> matrix);
    }

