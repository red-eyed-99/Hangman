namespace Hangman
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("H_A_N_G_M_A_N");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("1 Начать новую игру. 2 Выход");

                switch(Console.ReadLine())
                {
                    case "1":
                        var game = new Game();
                        game.Start();
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Введите \"1\", чтобы начать новую игру или \"2\" для выхода");
                        break;
                }
            }
        }
    }
}
