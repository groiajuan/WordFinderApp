namespace WordSearchLogic.Helpers;
public class CharMatrixConverterAdapter : ICharMatrixAdapter
{
    public char[,] ConvertToCharMatrix(IEnumerable<string> stringList)
    {
        return StringListToCharMatrixConverter.ConvertToCharMatrix(stringList);
    }
}
