namespace WordSearchLogic.Helpers;
public class StringListToCharMatrixConverter
{
    public static char[,] ConvertToCharMatrix(IEnumerable<string> stringList)
    {
        char[,] charMatrix = new char[stringList.Count(), stringList.Max(s => s.Length)];
        int rowIndex = 0;
        foreach (var str in stringList)
        {
            for (int colIndex = 0; colIndex < str.Length; colIndex++)
            {
                charMatrix[rowIndex, colIndex] = str[colIndex];
            }
            rowIndex++;
        }
        return charMatrix;
    }

}