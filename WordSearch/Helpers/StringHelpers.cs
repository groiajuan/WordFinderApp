namespace WordSearchLogic.Helpers;
    public static class StringHelpers
    {
        public static int CountingOccurrencesInPhrase(string phrase, string word)
        {
            int count = 0;

            for (int index = 0; (index = phrase.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1; index += word.Length)
                count++;

            return count;
        }
    }

    

