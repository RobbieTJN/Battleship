using System;
using System.Threading;
using BattleshipClassLibrary;
using BattleshipClassLibrary.GameObjects;
using BattleshipClassLibrary.Validation;

namespace BattleshipConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Battleship by Robbie Nielsen";

            Game game = new Game();
            GameUtilities utilities = new GameUtilities();
            utilities.PrintBattleshipLogo();

            utilities.PrintIntro();
            Console.ReadKey(true);

            utilities.PrintCoinFlip();
            Thread.Sleep(1000);

            string player1 = game.EnterPlayerName("1");
            string player2 = game.EnterPlayerName("2");

            utilities.ConfirmPlayerNamesPrompt(player1, player2);
            string confirmNames = Console.ReadLine();
            bool namesConfirmed = Validator.AreNamesConfirmed(confirmNames);

            while (!namesConfirmed)
            {
                Console.Clear();
                utilities.PrintBattleshipLogo();

                player1 = game.EnterPlayerName("1");
                player2 = game.EnterPlayerName("2");

                utilities.ConfirmPlayerNamesPrompt(player1, player2);
                confirmNames = Console.ReadLine();
                namesConfirmed = Validator.AreNamesConfirmed(confirmNames);
            }

            Console.WriteLine("Starting game...");
            game.Player1 = new Player(player1);
            game.Player2 = new Player(player2);
            Thread.Sleep(1500);
            
            Console.Clear();

            game.SetShips(game.Player1, game.Player2);

            Console.WriteLine(player1 + "'s ships are all placed! Press any key to place " + player2 + "'s ships...");
            Console.ReadKey(true);
            Console.Clear();

            game.SetShips(game.Player2, game.Player1);

            Console.WriteLine("All ships placed! Press any key when ready...");
            Console.ReadKey(true);

            game.Play();
            Thread.Sleep(1000);

            Console.WriteLine("Goodbye! Press any key to exit...");
            Console.ReadKey();
        }
    }
}