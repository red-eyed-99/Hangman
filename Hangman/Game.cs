using System.Text;

namespace Hangman
{
    public class Game
    {
        public int ErrorCount { get; private set; }

        public string Word { get; private set; } 

        public string HiddenWord { get; private set; }   

        public Game() 
        {
            var wordPicker = new WordPicker();
            
            Word = wordPicker.GetRandomWord();
            
            HiddenWord = new string('_', Word.Length);
        }

        public void Start()
        {
            Console.Clear();

            var drawer = new HangmanDrawer();

            while (true)
            {
                Console.Clear();

                drawer.Draw(this);

                if (ErrorCount == 6 || HiddenWord == Word)
                {
                    break;
                }

                var enteredLetter = GetLetterFromUserInput();

                if (Word.Contains(enteredLetter))
                {
                    for (int i = 0; i < Word.Length; i++)
                    {
                        if (Word[i] == enteredLetter)
                        {
                            var hiddenWord = new StringBuilder(HiddenWord);
                            hiddenWord[i] = Word[i];
                            HiddenWord = hiddenWord.ToString();
                        }
                    }
                }
                else
                {
                    ErrorCount++;
                } 
            }
        }

        private char GetLetterFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Enter a letter: ");

                var userInput = Console.ReadLine();
                if (userInput != null && userInput.Length == 1 && Char.IsLetter(Convert.ToChar(userInput)))
                {
                    return Char.ToLower(Convert.ToChar(userInput));
                }
            }
        }
    }
}
