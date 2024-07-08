namespace Hangman
{
    public class HangmanDrawer
    {
        public void Draw(Game game)
        {
            Console.WriteLine($"Error count: {game.ErrorCount}");

            if (game.HiddenWord == game.Word)
            {
                Console.WriteLine(@"
------------
|/         |
|
|
|         \o/
|          O
|         / \
-------");
                Console.WriteLine("You win!");
                return;
            }

            switch (game.ErrorCount)
            {
                case 0:
                    Console.WriteLine(@"
------------
|/         |
|
|
|
|
|
-------");
                    break;
                case 1:
                    Console.WriteLine(@"
------------
|/         |
|          o
|
|
|
|
-------");
                    break;
                case 2:
                    Console.WriteLine(@"
------------
|/         |
|          o
|          O
|
|
|
-------");
                    break;
                case 3:
                    Console.WriteLine(@"
------------
|/         |
|          o
|        - O
|       
|
|
-------");
                    break;
                case 4:
                    Console.WriteLine(@"
------------
|/         |
|          o
|        - O -
|       
|
|
-------");
                    break;
                case 5:
                    Console.WriteLine(@"
------------
|/         |
|          o
|        - O -
|         /
|
|
-------");
                    break;
                case 6:
                    Console.WriteLine(@"
------------
|/         |
|          o
|        - O -
|         / \
|
|
-------");
                    Console.WriteLine("You lose!");
                    Console.WriteLine($"The word was: {game.Word}");
                    return;
                default:
                    break;
            }

            var hiddenWordSymbols = game.HiddenWord.ToCharArray();
            foreach (var symbol in hiddenWordSymbols)
            {
                Console.Write(symbol.ToString() + ' ');
            }

            Console.WriteLine();
        }
    }
}
