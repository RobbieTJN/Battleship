using BattleshipClassLibrary.Validation;
using System;
using System.Threading;

namespace BattleshipClassLibrary
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Board EmptyBoard { get; set; }

        public void PrintBattleshipLogo()
        {
            Console.WriteLine();
            Console.WriteLine(
                @" ______       _   _   _           _     _       " + Environment.NewLine +
                @" | ___ \     | | | | | |         | |   (_)      " + Environment.NewLine +
                @" | |_/ / __ _| |_| |_| | ___  ___| |__  _ _ __  " + Environment.NewLine +
                @" | ___ \/ _` | __| __| |/ _ \/ __| '_ \| | '_ \ " + Environment.NewLine +
                @" | |_/ / (_| | |_| |_| |  __/\__ \ | | | | |_) |" + Environment.NewLine +
                @" \____/ \__,_|\__|\__|_|\___||___/_| |_|_| .__/ " + Environment.NewLine +
                @"    Programmed by Robbie Nielsen         | |    " + Environment.NewLine +
                @"    Version 1.0 - 2019-12-04             |_|    ");
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
            Thread.Sleep(1000);
        }

        public void PrintIntro()
        {
            Console.WriteLine("A coin will be flipped to decide who goes first.");
            Thread.Sleep(750);
            Console.WriteLine("Decide who gets heads and who gets tails. Heads will be Player 1.");
            Thread.Sleep(750);
            Console.WriteLine("Press any key when ready.");
        }

        public int CoinFlip()
        {
            Random random = new Random();
            return random.Next(1, 3);
        }

        public void PrintCoinFlip()
        {
            Console.WriteLine();
            Console.WriteLine("Flipping a coin...");
            int result = CoinFlip();
            Thread.Sleep(1000);
            
            if (result == 1)
            {
                Console.WriteLine("Heads!");
            }
            else
            {
                Console.WriteLine("Tails!");
            }
        }

        public string Player1NameInput()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the name for Player 1: ");
            return Console.ReadLine();
        }

        public string Player2NameInput()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the name for Player 2: ");
            return Console.ReadLine();
        }

        public bool ConfirmPlayerNames(string player1, string player2)
        {
            Console.WriteLine("Are these names okay? (y/n)");
            Console.WriteLine("Player 1: " + player1 + "\t\t" + "Player 2: " + player2);
            string input = Console.ReadLine();

            return Validator.AreNamesConfirmed(input);
        }

        public void PlaceShipMessage(string firstName, string secondName, string shipName)
        {
            Console.WriteLine(firstName + ", enter the coordinates for your " + shipName + "! Make sure " + secondName + " doesn't peak!");
        }

        public int EnterColumn()
        {
            Console.WriteLine(ConstantsHandler.COLUMN);
            string columnInput = Console.ReadLine();
            while (!Validator.IsValidColumn(columnInput))
            {
                Console.WriteLine(ConstantsHandler.COLUMN_ERROR);
                Console.WriteLine(ConstantsHandler.COLUMN);
                columnInput = Console.ReadLine();
            }
            return StringConverters.StringToInt(columnInput);
        }

        public int EnterRow()
        {
            Console.WriteLine(ConstantsHandler.ROW);
            string rowInput = Console.ReadLine();
            while (!Validator.IsValidRow(rowInput))
            {
                Console.WriteLine(ConstantsHandler.ROW_ERROR);
                Console.WriteLine(ConstantsHandler.ROW);
                rowInput = Console.ReadLine();
            }
            return int.Parse(rowInput);
        }

        public string EnterOrientation()
        {
            Console.WriteLine(ConstantsHandler.ORIENTATION);
            string orientationInput = Console.ReadLine();
            string orientation = StringConverters.Orientation(orientationInput);
            while (orientation == "Error")
            {
                Console.WriteLine(ConstantsHandler.ORIENTATION_ERROR);
                orientationInput = Console.ReadLine();
                orientation = StringConverters.Orientation(orientationInput);
            }
            return orientation;
        }

        public void PlayTurn()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(Player1.Name + ConstantsHandler.PLAYER_TURN_MESSAGE);
            Console.WriteLine(ConstantsHandler.OPPONENT_BOARD);
            Player1.DrawOpponentBoard();
            Console.WriteLine();

            int column = EnterColumn();
            int row = EnterRow();
            var coordinates = Player1.FireShot(row, column);
            var result = Player2.HandleShot(coordinates);

            string shotResult = Player1.HandleShotResult(coordinates, result);
            while (shotResult == ConstantsHandler.ALREADY_HIT)
            {
                Console.WriteLine("Enter new coordinates:");
                column = EnterColumn();
                row = EnterRow();
                coordinates = Player1.FireShot(row, column);
                result = Player2.HandleShot(coordinates);
                shotResult = Player1.HandleShotResult(coordinates, result);
            }

            Console.Clear();
            
            if (result == ShotResult.Sank)
            {
                Console.WriteLine();
                Player2.HandleShot(coordinates);
            }

            Console.WriteLine();
            Console.WriteLine(shotResult);
            Player1.DrawOpponentBoard();

            Console.WriteLine(ConstantsHandler.CONTINUE);
            Console.ReadKey(true);

            if (!Player2.IsDefeated)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(Player2.Name + ConstantsHandler.PLAYER_TURN_MESSAGE);
                Console.WriteLine(ConstantsHandler.OPPONENT_BOARD);
                Player2.DrawOpponentBoard();
                Console.WriteLine();

                column = EnterColumn();
                row = EnterRow();
                coordinates = Player2.FireShot(row, column);
                result = Player1.HandleShot(coordinates);

                shotResult = Player2.HandleShotResult(coordinates, result);
                while (shotResult == ConstantsHandler.ALREADY_HIT)
                {
                    Console.WriteLine("Enter new coordinates:");
                    column = EnterColumn();
                    row = EnterRow();
                    coordinates = Player2.FireShot(row, column);
                    result = Player1.HandleShot(coordinates);
                    shotResult = Player2.HandleShotResult(coordinates, result);
                }

                Console.Clear();

                if (result == ShotResult.Sank)
                {
                    Console.WriteLine();
                    Player2.HandleShot(coordinates);
                }

                Console.WriteLine();
                Console.WriteLine(shotResult);
                Player2.DrawOpponentBoard();

                Console.WriteLine(ConstantsHandler.CONTINUE);
                Console.ReadKey(true);
            }
        }

        public void Play()
        {
            while (!Player1.IsDefeated && !Player2.IsDefeated)
            {
                PlayTurn();
            }

            Console.Clear();
            Console.WriteLine();

            if (Player2.IsDefeated)
            {
                Console.WriteLine(Player1.Name + " has won the game!");
            }
            else if (Player1.IsDefeated)
            {
                Console.WriteLine(Player2.Name + " has won the game!");
            }
        }
    }
}
