using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class Game
    {
        public int ErrorCount { get; private set; }

        public string Word { get; private set; }

        public string HiddenWord { get; private set; }

        private List<char> _enteredLetters = new List<char>();

        private List<char> _wrongLetters = new List<char>();

        public Game()
        {
            var wordPicker = new WordPicker();
            Word = wordPicker.GetRandomWord();

            HiddenWord = new string('_', Word.Length);
        }

        public void Start()
        {
            Console.Clear();

            var drawer = new ConsoleDrawer();
            drawer.DrawGallow(OutputPositions.gallow);

            while (true)
            {
                OutputWrongAnswersInfo(OutputPositions.wrongAnswersBlock);
                OutputHiddenWordState(OutputPositions.hiddenWord);

                if (CheckGameState() != GameStatus.IsRunning)
                {
                    break;
                }

                var enteredLetter = GetLetterFromUserInput();
                _enteredLetters.Add(enteredLetter);

                var cursorPositionAfterInput = Console.GetCursorPosition();

                if (Word.Contains(enteredLetter))
                {
                    ShowLetterInHiddenWord(enteredLetter);
                }
                else
                {
                    ErrorCount++;
                    _wrongLetters.Add(enteredLetter);
                    drawer.DrawHangedMan(ErrorCount, OutputPositions.hangedMan);
                }

                ClearConsoleAfterUserInput(OutputPositions.userInteractionBlock, cursorPositionAfterInput);
            }
        }

        private GameStatus CheckGameState()
        {
            if (ErrorCount == 6)
            {
                Console.SetCursorPosition(OutputPositions.userInteractionBlock.X, OutputPositions.userInteractionBlock.Y);
                Console.WriteLine("You hanged!");
                Console.WriteLine($"The word was: {Word}\n");

                return GameStatus.Hanged;
            }
            else if (HiddenWord == Word)
            {
                Console.SetCursorPosition(OutputPositions.gallow.X, OutputPositions.gallow.Y);
                Console.WriteLine(@"
------------
|/         |
|
|
|         \o/
|          O
|         / \
-------");

                Console.SetCursorPosition(OutputPositions.userInteractionBlock.X, OutputPositions.userInteractionBlock.Y);
                Console.WriteLine("You win!\n");

                return GameStatus.Win;
            }

            return GameStatus.IsRunning;
        }

        private void OutputWrongAnswersInfo((int X, int Y) position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.WriteLine($"Error count: {ErrorCount}");
            Console.WriteLine($"Wrong letters: {string.Join(", ", _wrongLetters)}");
        }

        private void OutputHiddenWordState((int X, int Y) position)
        {
            Console.SetCursorPosition(position.X, position.Y);

            var hiddenWordSymbols = HiddenWord.ToCharArray();
            foreach (var symbol in hiddenWordSymbols)
            {
                Console.Write(symbol.ToString() + ' ');
            }

            Console.WriteLine('\n');
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
                if (_enteredLetters.Contains(Convert.ToChar(userInput)))
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

        private void ShowLetterInHiddenWord(char enteredLetter)
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

        private void ClearConsoleAfterUserInput((int X, int Y) userInteractionBlockPosition, (int X, int Y) cursorPositionAfterInput)
        {
            for (int i = cursorPositionAfterInput.Y - 1; i >= userInteractionBlockPosition.Y; i--)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.BufferWidth));
            }

            Console.SetCursorPosition(userInteractionBlockPosition.X, userInteractionBlockPosition.Y);
        }
    }
}
