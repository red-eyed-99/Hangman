using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class Game
    {
        public int ErrorCount { get; private set; }

        public string Word { get; private set; }

        public string HiddenWord { get; private set; }

        private List<char> enteredLetters = new List<char>();

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
                enteredLetters.Add(enteredLetter);
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
                if (ValidateUserInput(userInput))
                {
                    return Char.ToLower(Convert.ToChar(userInput));
                }
            }
        }

        private bool ValidateUserInput(string? userInput)
        {
            if (userInput != null && Regex.Match(userInput, @"^[а-яёА-ЯЁ]$").Success)
            {
                if (enteredLetters.Contains(Convert.ToChar(userInput)))
                {
                    Console.WriteLine("You have already entered this letter!");
                    return false;
                }

                return true;
            }
            else
            {
                Console.WriteLine("You can only enter one character in (а-яёА-ЯЁ)!");
                return false;
            } 
        }
    }
}
