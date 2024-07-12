namespace Hangman
{
    public static class ConsoleOutputPositions
    {
        public static (int X, int Y) WrongAnswersBlock { get; } = (X: 0, Y: 0);

        public static (int X, int Y) Gallow { get; } = (X: 0, Y: 2);

        public static (int X, int Y) HangedMan { get; } = (X: Gallow.X + 11, Y: Gallow.Y + 3);

        public static (int X, int Y) HiddenWord { get; } = (X: 0, Y: 11);

        public static (int X, int Y) UserInteractionBlock { get; } = (X: 0, Y: 13);
    }
}
