using _wordSearchLogic.Helpers.OcurrenceCounters;

namespace WordSearchLogic.Helpers.OcurrenceCounters;
public class HorizontalOccurrenceCounter : OccurrenceCounterBase<char>
{
    public HorizontalOccurrenceCounter(int rows, int cols, char[,] matrix)
        : base(rows, cols, matrix) { }

    protected override int GetOuterLimit() => _rows;

    protected override int GetInnerLimit() => _cols - Word.Length;

    protected override bool IsMatch(int fixedIndex, int iteratorIndex)
    {
        for (int k = 0; k < Word.Length; k++)
            if (_matrix[fixedIndex, iteratorIndex + k] != Word[k])
                return false;

        return true;
    }
}
