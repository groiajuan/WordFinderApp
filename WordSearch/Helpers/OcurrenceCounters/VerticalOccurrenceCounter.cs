using _wordSearchLogic.Helpers.OcurrenceCounters;

namespace WordSearchLogic.Helpers.OcurrenceCounters;
public class VerticalOccurrenceCounter : OccurrenceCounterBase<char>
{
    public VerticalOccurrenceCounter(int rows, int cols, char[,] matrix)
        : base(rows, cols, matrix) { }

    protected override int GetOuterLimit() => _cols;

    protected override int GetInnerLimit() => _rows - _word.Length;

    protected override bool IsMatch(int fixedIndex, int iteratorIndex)
    {
        for (int k = 0; k < _word.Length; k++)
            if (_matrix[iteratorIndex + k, fixedIndex] != _word[k])
                return false;

        return true;
    }
}
