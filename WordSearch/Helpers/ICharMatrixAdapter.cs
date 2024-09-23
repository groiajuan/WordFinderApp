namespace WordSearchLogic.Helpers;
public interface ICharMatrixAdapter
{
    char[,] ConvertToCharMatrix(IEnumerable<string> stringList);
}
