namespace Hangman
{
    public class WordPicker
    {
        private List<string> _words = new List<string>();

        private Random _random = new Random();

        public WordPicker()
        {
            GetWordsFromFile();
        }

        private void GetWordsFromFile()
        {
            StreamReader reader = new StreamReader("../../../words/words.txt");

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    var word = reader.ReadLine();
                    if (!string.IsNullOrEmpty(word))
                    {
                        _words.Add(word);
                    }
                }
            }

            if (_words.Count < 1)
            {
                throw new Exception("File \"words.txt\" does not contain any word to pick!");
            }
        }

        public string GetRandomWord()
        {
            var randomWordIndex = _random.Next(_words.Count);
            return _words[randomWordIndex];
        }
    }
}
