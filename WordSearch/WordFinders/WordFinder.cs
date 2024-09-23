using _wordSearchLogic.Helpers.OcurrenceCounters;
using WordSearchLogic.Helpers;
using WordSearchLogic.Helpers.OcurrenceCounters;

namespace WordSearchLogic.WordFinders;
    public class WordFinder
    {
        private readonly char[,] _charMatrix;
        private readonly int _rows;
        private readonly int _cols;
        private readonly MatrixValidatorBase _validator;
        private readonly ICharMatrixAdapter _charMatrixAdapter;
        private OccurrenceCounterBase<char> _horizontalOccurrenceCounter;
        private OccurrenceCounterBase<char> _verticalOccurrenceCounter;

        //DI for inputMatrix
        public WordFinder(IEnumerable<string> inputMatrix)
        {
                 _validator = new Matrix64Validator();
                 _validator.ExecuteValidations(inputMatrix);

                 _rows = inputMatrix.Count();
                 _cols = inputMatrix.Max(s => s.Length);
                 _charMatrixAdapter = new CharMatrixConverterAdapter();
                 _charMatrix = _charMatrixAdapter.ConvertToCharMatrix(inputMatrix);

                _horizontalOccurrenceCounter = new HorizontalOccurrenceCounter(_rows,_cols, _charMatrix);
                _verticalOccurrenceCounter = new VerticalOccurrenceCounter(_rows, _cols, _charMatrix);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
                wordstream = wordstream.ToHashSet();
                var results = new Dictionary<string, int>();

                foreach (var word in wordstream)
                    results[word] = CountOccurrences(word);

                return results.Count > 0 ? results.Keys.Where(key => results[key] > 0).OrderByDescending(key => results[key]).Take(10) : new List<string>(); ;
         }

         private int CountOccurrences(string word)
         {
                _horizontalOccurrenceCounter.Word = word;
                _verticalOccurrenceCounter.Word = word;
                return _horizontalOccurrenceCounter.CountOccurrences() + _verticalOccurrenceCounter.CountOccurrences();
         }
}