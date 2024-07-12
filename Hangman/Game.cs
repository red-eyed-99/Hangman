using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class Game
    {
        public int ErrorCount { get; private set; }

        public string Word { get; private set; }

        public string HiddenWord { get; private set; }

        public List<char> EnteredLetters { get; private set; } = new List<char>();

        public List<char> WrongLetters { get; private set; } = new List<char>();

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
            drawer.DrawGallow(ConsoleOutputPositions.Gallow);

            while (true)
            {
                OutputWrongAnswersInfo(ConsoleOutputPositions.WrongAnswersBlock);
                OutputHiddenWordState(ConsoleOutputPositions.HiddenWord);

                if (CheckGameState() != GameStatus.IsRunning)
                {
                    break;
                }

                var enteredLetter = GetLetterFromUserInput();
                EnteredLetters.Add(enteredLetter);

                var cursorPositionAfterInput = Console.GetCursorPosition();

                if (Word.Contains(enteredLetter))
                {
                    ShowLetterInHiddenWord(enteredLetter);
                }
                else
                {
                    ErrorCount++;
                    WrongLetters.Add(enteredLetter);
                    drawer.DrawHangedMan(ErrorCount, ConsoleOutputPositions.HangedMan);
                }

                ClearConsoleAfterUserInput(ConsoleOutputPositions.UserInteractionBlock, cursorPositionAfterInput);
            }
        }

        private GameStatus CheckGameState()
        {
            if (ErrorCount == 6)
            {
                Console.SetCursorPosition(ConsoleOutputPositions.UserInteractionBlock.X, ConsoleOutputPositions.UserInteractionBlock.Y);
                Console.WriteLine("You hanged!");
                Console.WriteLine($"The word was: {Word}\n");

                return GameStatus.Hanged;
            }
            else if (HiddenWord == Word)
            {
                Console.SetCursorPosition(ConsoleOutputPositions.Gallow.X, ConsoleOutputPositions.Gallow.Y);
                Console.WriteLine(@"
------------
|/         |
|
|
|         \o/
|          O
|         / \
-------");

                Console.SetCursorPosition(ConsoleOutputPositions.UserInteractionBlock.X, ConsoleOutputPositions.UserInteractionBlock.Y);
                Console.WriteLine("You win!\n");

                return GameStatus.Win;
            }

            return GameStatus.IsRunning;
        }

        private void OutputWrongAnswersInfo((int X, int Y) position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.WriteLine($"Error count: {ErrorCount}");
            Console.WriteLine($"Wrong letters: {string.Join(", ", WrongLetters)}");
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
                if (EnteredLetters.Contains(Convert.ToChar(userInput)))
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
