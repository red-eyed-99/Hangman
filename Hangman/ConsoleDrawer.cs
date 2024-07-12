namespace Hangman
{
    public class ConsoleDrawer
    {
        public void DrawGallow((int X, int Y) position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.WriteLine(@"
------------
|/         |
|
|
|
|
|
-------");          
        }

        public void DrawHangedMan(int errorCount, (int X, int Y) position)
        {
            switch (errorCount)
            {
                case 1:
                    Console.SetCursorPosition(position.X ,position.Y);
                    Console.Write("o");
                    break;
                case 2:
                    Console.SetCursorPosition(position.X ,position.Y + 1);
                    Console.Write("O");
                    break;
                case 3:
                    Console.SetCursorPosition(position.X - 1 ,position.Y + 1);
                    Console.Write("/");
                    break;
                case 4:
                    Console.SetCursorPosition(position.X + 1 ,position.Y + 1);
                    Console.Write("\\");
                    break;
                case 5:
                    Console.SetCursorPosition(position.X - 1 ,position.Y + 2);
                    Console.Write("/");
                    break;
                case 6:
                    Console.SetCursorPosition(position.X + 1,position.Y + 2);
                    Console.Write("\\");
                    break;
                default:
                    break;
            }
        }
    }
}
