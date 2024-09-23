//I have used Generics with a Template Method Pattern and also IoC. It allows us to create a generic counter regardless of what we want to count.
//It allows us to have shared logic and to extend it in the future.
namespace _wordSearchLogic.Helpers.OcurrenceCounters;
public abstract class OccurrenceCounterBase<T>
{
    protected string _word;
    protected int _rows { get; }
    protected int _cols { get; }
    protected T[,] _matrix { get; }
    public string Word { get => _word; set => _word = value; }

    protected OccurrenceCounterBase(int rows, int cols, T[,] matrix)
    {
        _rows = rows;
        _cols = cols;
        _matrix = matrix;
    }

    public virtual int CountOccurrences()
    {
        int count = 0;

        int outerLimit = GetOuterLimit();
        int innerLimit = GetInnerLimit();

        for (int i = 0; i < outerLimit; i++)
            for (int j = 0; j <= innerLimit; j++)
                if (IsMatch(i, j))
                    count++;

        return count;
    }

    //The search limit, for example in the search by rows, will be the number of rows
    protected abstract int GetOuterLimit();
    protected abstract int GetInnerLimit();
    protected abstract bool IsMatch(int fixedIndex, int iteratorIndex);
}
