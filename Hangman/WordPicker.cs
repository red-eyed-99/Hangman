namespace Hangman
{
    public class WordPicker
    {
        private int _wordsCount;

        private Random _random = new Random();

        public WordPicker()
        {
            StreamReader reader = new StreamReader("../../../words.txt");

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    _wordsCount++;
                }
            }
        }

        public string GetRandomWord()
        {
            var randomWordIndex = _random.Next(_wordsCount);

            StreamReader reader = new StreamReader("../../../words.txt");

            var rowIndex = 0;

            using (reader)
            {
                while (rowIndex < randomWordIndex)
                {
                    reader.ReadLine();
                    rowIndex++;
                }

                var word = reader.ReadLine();
                if (!string.IsNullOrEmpty(word))
                {
                    return word;
                }
                else
                {
                    throw new Exception("File \"words.txt\" does not contain any word to pick!");
                }
            }
        }
    }
}
