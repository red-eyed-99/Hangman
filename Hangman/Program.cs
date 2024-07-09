﻿namespace Hangman
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("H_A_N_G_M_A_N");
            Console.WriteLine();
            Console.WriteLine("1. Start new game 2. Exit");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        try
                        {
                            var game = new Game();
                            game.Start();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("1. Start new game 2. Exit");
                        }
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter \"1\" to start new game or \"2\" to exit");
                        break;
                }
            }
        }
    }
}
