using WordSearchLogic;
using WordSearchLogic.Helpers;

namespace WordSearch;
public class WordFinderWithGeneratedMatrix
{
    private readonly IEnumerable<string> _matrix;
    private readonly MatrixValidatorBase _validator;

    //I would like to implement DI  on the WordFinder to use SimetricalMatrixGeneratorBase but i will respect the Challenge Interface
    public WordFinderWithGeneratedMatrix(IEnumerable<string> matrix)
    {
        _validator = new Matrix64Validator();
        _validator.ExecuteValidations(matrix);
        _matrix = matrix;
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        //HashSet avoid duplicates and It is more efficient than maintaining the collection and using distinct, it is microperformance but it could helps.
        wordstream = wordstream.ToHashSet();

        var wordCount = new Dictionary<string, int>();

        int tempOcc;

        foreach (var word in wordstream)
        {
            tempOcc = 0;

            foreach (var wordInMatrix in _matrix)
                tempOcc += StringHelpers.CountingOccurrencesInPhrase(wordInMatrix, word);

            Console.WriteLine($"{word} has {tempOcc}");

            wordCount.Add(word, tempOcc);
        }

        return wordCount.Count > 0 ? wordCount.Keys.Where(key => wordCount[key] > 0).OrderByDescending(key => wordCount[key]).Take(10) : new List<string>();
    }

}


