using WordSearchLogic;
using WordSearchLogic.Helpers.OcurrenceCounters;
using WordSearchLogic.WordFinders;

namespace WordSearch;

//A good algorithm for this is a tree search with DFS or branch and pruning
//with Dictionaries/Hashset but I find it complex to apply and not so clean so I chose
//2 approaches for a matrix that is 64x64 and to be able to show patterns and good practices.
public static class Example
{
    public static void ExecuteExample()
    {

        var matrix = new List<string>
        {
            "chillaapcb",
            "coldwacpob",
            "indowahplb",
            "warmyaipdb",
            "doughalpcb",
            "acoldalpob",
            "warmchillb",
            "abcdefggdb",
            "abcdefggfb",
            "coldcoldab"
        };

        var matrix2 = new List<string>
        {
            "chillaapcb",
            "coldwacpob",
            "indowahplb",
            "warmyaipdb",
            "doughalpcb",
            "acoldalpob",
            "warmchillb",
            "abcdefggdb",
            "abcdefggfb",
            "coldcoldab"
        };

        var words = new List<string>
        {
            "chill", "cold", "wind", "warm", "wind", "wind", "cold"
        };

        //First WordFinder
        var wordFinder = new WordFinder(matrix2);
        var results = wordFinder.Find(words);

        //Second WordFinder Approach, in this approach first we generate the Matrix and then search
        IMatrixGenerator matrixGenerator = new MatrixGenerator();
        var newMatrix = matrixGenerator.GenerateMatrix(matrix);

        var wordFinder2 = new WordFinderWithGeneratedMatrix(newMatrix);
        var results2 = wordFinder2.Find(words);

        Console.WriteLine("Top found words using Word Finder:");
        foreach (var word in results)
            Console.WriteLine(word);

        Console.WriteLine("Top found words using Word Finder with Matrix Generator:");
        foreach (var word in results2)
            Console.WriteLine(word);
    }
}