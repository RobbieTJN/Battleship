using System;
using System.Threading;

namespace BattleshipClassLibrary.GameObjects
{
    public class GameUtilities
    {
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

        public void PlayerNamePrompt(string whichPlayer, string isError)
        {
            if (isError == "noError")
            {
                Console.WriteLine();
                Console.WriteLine("Enter the name for Player " + whichPlayer + ":");
            }
            else if (isError == "error")
            {
                Console.WriteLine();
                Console.WriteLine("Invalid name - Must be letters only with a maximum length of 20.");
                Console.WriteLine("Enter another name for Player " + whichPlayer + ":");
            }
        }

        public void ConfirmPlayerNamesPrompt(string player1, string player2)
        {
            Console.WriteLine("Are these names okay? (y/n)");
            Console.WriteLine("Player 1: " + player1 + "\t\t" + "Player 2: " + player2);
        }

        public void PlaceShipMessage(string firstName, string secondName, string shipName)
        {
            Console.WriteLine(firstName + ", enter the coordinates for your " + shipName + "! Make sure " + secondName + " doesn't peak!");
        }

        public void EnterColumnPrompt(string isError)
        {
            if (isError == "noError")
            {
                Console.WriteLine(ConstantsHandler.COLUMN);
            }
            else if (isError == "error")
            {
                Console.WriteLine(ConstantsHandler.COLUMN_ERROR);
                Console.WriteLine(ConstantsHandler.COLUMN);
            }
        }

        public void EnterRowPrompt(string isError)
        {
            if (isError == "noError")
            {
                Console.WriteLine(ConstantsHandler.ROW);
            }
            else if (isError == "error")
            {
                Console.WriteLine(ConstantsHandler.ROW_ERROR);
                Console.WriteLine(ConstantsHandler.ROW);
            }
        }

        public void EnterOrientationPrompt(string isError)
        {
            if (isError == "noError")
            {
                Console.WriteLine(ConstantsHandler.ORIENTATION);
            }
            else if (isError == "error")
            {
                Console.WriteLine(ConstantsHandler.ORIENTATION_ERROR);
                Console.WriteLine(ConstantsHandler.ORIENTATION);
            }
        }
    }
}
