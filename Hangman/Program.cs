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
                Console.WriteLine("1. Start new game 2. Exit");

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
                        Console.WriteLine("Enter \"1\" to start new game or \"2\" exit");
                        break;
                }
            }
        }
    }
}
