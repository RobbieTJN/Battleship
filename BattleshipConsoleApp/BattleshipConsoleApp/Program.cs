using System;
using System.Threading;
using BattleshipClassLibrary;

namespace BattleshipConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Battleship by Robbie Nielsen";

            Game game = new Game();
            Board board = new Board();
            game.PrintBattleshipLogo();

            game.PrintIntro();
            Console.ReadKey(true);

            game.PrintCoinFlip();
            Thread.Sleep(1000);

            string player1 = game.Player1NameInput();
            string player2 = game.Player2NameInput();
            Console.WriteLine();

            bool namesConfirmed = game.ConfirmPlayerNames(player1, player2);

            while (!namesConfirmed)
            {
                Console.Clear();
                game.PrintBattleshipLogo();

                player1 = game.Player1NameInput();
                player2 = game.Player2NameInput();

                namesConfirmed = game.ConfirmPlayerNames(player1, player2);
            }

            Console.WriteLine("Starting game...");
            game.Player1 = new Player(player1);
            game.Player2 = new Player(player2);
            Thread.Sleep(1000);
            
            Console.Clear();
            board.DrawEmptyBoard();

            for (int i = 0; i < game.Player1.Fleet.Count; i++)
            {
                Ship ship = game.Player1.Fleet[i];
                game.PlaceShipMessage(player1, player2, ship.Name);

                int column = game.EnterColumn();
                int row = game.EnterRow();
                string orientation = game.EnterOrientation();

                string placedShip = game.Player1.PlaceShip(ship, row, column, orientation);
                while (placedShip != ConstantsHandler.SHIP_PLACE_SUCCESS)
                {
                    Console.WriteLine(placedShip);
                    column = game.EnterColumn();
                    row = game.EnterRow();
                    orientation = game.EnterOrientation();
                    placedShip = game.Player1.PlaceShip(ship, row, column, orientation);
                }
                Console.WriteLine(placedShip);
            }

            Console.WriteLine("Get ready to place " + player2 + "'s ships...");
            Thread.Sleep(1000);
            Console.Clear();
            board.DrawEmptyBoard();

            for (int i = 0; i < game.Player2.Fleet.Count; i++)
            {
                Ship ship = game.Player2.Fleet[i];
                game.PlaceShipMessage(player2, player1, ship.Name);

                int column = game.EnterColumn();
                int row = game.EnterRow();
                string orientation = game.EnterOrientation();

                string placedShip = game.Player2.PlaceShip(ship, row, column, orientation);
                while (placedShip != ConstantsHandler.SHIP_PLACE_SUCCESS)
                {
                    Console.WriteLine(placedShip);
                    column = game.EnterColumn();
                    row = game.EnterRow();
                    orientation = game.EnterOrientation();
                    placedShip = game.Player2.PlaceShip(ship, row, column, orientation);
                }

                Console.WriteLine(placedShip);
            }

            Console.WriteLine("Ships all placed! Time to play...");
            Thread.Sleep(1000);

            game.Play();
            Thread.Sleep(1000);

            Console.WriteLine("Goodbye! Press any key to exit...");
            Console.ReadKey();
        }
    }
}
