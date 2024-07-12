namespace Hangman
{
    public class OutputPositions
    {
        public static readonly (int X, int Y) wrongAnswersBlock = (X: 0, Y: 0);

        public static readonly (int X, int Y) gallow = (X: 0, Y: 2);

        public static readonly (int X, int Y) hangedMan = (X: gallow.X + 11, Y: gallow.Y + 3);

        public static readonly (int X, int Y) hiddenWord = (X: 0, Y: 11);

        public static readonly (int X, int Y) userInteractionBlock = (X: 0, Y: 13);
    }
}
