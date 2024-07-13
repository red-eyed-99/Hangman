namespace Hangman
{
    public class ConsoleDrawer
    {
        public void DrawGallow((int X, int Y) position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.WriteLine(@"
____________
|/         |
|
|
|
|
|
--------");
        }

        public void DrawHangedMan(int errorCount, (int X, int Y) position)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

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

            Console.ResetColor();
        }

        public void DrawHoorayHangedMan((int X, int Y) position)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(position.X - 1, position.Y + 2);
            Console.Write("\\o/");
            Console.SetCursorPosition(position.X, position.Y + 3);
            Console.Write("O");
            Console.SetCursorPosition(position.X - 1, position.Y + 4);
            Console.Write("/ \\");

            Console.ResetColor();
        }

        public void EraseHangedMan()
        {
            var hangedManHeight = 3;
            for (int i = 0; i < hangedManHeight; i++)
            {
                Console.SetCursorPosition(ConsoleOutputPositions.HangedMan.X - 1, ConsoleOutputPositions.HangedMan.Y + i);
                Console.Write(new string(' ', 3));
            }
        }
    }
}
