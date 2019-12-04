using BattleshipClassLibrary.GameObjects;
using BattleshipClassLibrary.Validation;
using System;

namespace BattleshipClassLibrary
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        private readonly GameUtilities utilities = new GameUtilities();

        public string EnterPlayerName(string whichPlayer)
        {
            utilities.PlayerNamePrompt(whichPlayer, "noError");
            string name = Console.ReadLine();
            bool isValidPlayerName = Validator.IsValidName(name);
            while (!isValidPlayerName)
            {
                utilities.PlayerNamePrompt(whichPlayer, "error");
                name = Console.ReadLine();
                isValidPlayerName = Validator.IsValidName(name);
            }
            return name;
        }

        public int EnterColumn()
        {
            utilities.EnterColumnPrompt("noError");
            string columnInput = Console.ReadLine();
            while (!Validator.IsValidColumn(columnInput))
            {
                utilities.EnterColumnPrompt("error");
                columnInput = Console.ReadLine();
            }
            return StringConverters.StringToInt(columnInput);
        }

        public int EnterRow()
        {
            utilities.EnterRowPrompt("noError");
            string rowInput = Console.ReadLine();
            while (!Validator.IsValidRow(rowInput))
            {
                utilities.EnterRowPrompt("error");
                rowInput = Console.ReadLine();
            }
            return int.Parse(rowInput);
        }

        public string EnterOrientation()
        {
            utilities.EnterOrientationPrompt("noError");
            string orientationInput = Console.ReadLine();
            string orientation = StringConverters.Orientation(orientationInput);
            while (orientation == ConstantsHandler.ORIENTATION_INPUT_ERROR)
            {
                utilities.EnterOrientationPrompt("error");
                orientationInput = Console.ReadLine();
                orientation = StringConverters.Orientation(orientationInput);
            }
            return orientation;
        }

        public void SetShips(Player currentPlayer, Player opponent)
        {
            for (int i = 0; i < currentPlayer.Fleet.Count; i++)
            {
                Console.WriteLine();
                currentPlayer.DrawOwnBoard();
                Ship ship = currentPlayer.Fleet[i];
                utilities.PlaceShipMessage(currentPlayer.Name, opponent.Name, ship.Name);

                int column = EnterColumn();
                int row = EnterRow();
                string orientation = EnterOrientation();

                string placedShip = currentPlayer.PlaceShip(ship, row, column, orientation);
                while (placedShip != ConstantsHandler.SHIP_PLACE_SUCCESS)
                {
                    Console.WriteLine(placedShip);
                    column = EnterColumn();
                    row = EnterRow();
                    orientation = EnterOrientation();
                    placedShip = currentPlayer.PlaceShip(ship, row, column, orientation);
                }
                Console.WriteLine(placedShip);
            }
        }

        public void PlayTurn(Player attackingPlayer, Player opponent)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(attackingPlayer.Name + ConstantsHandler.PLAYER_TURN_MESSAGE);
            Console.WriteLine(ConstantsHandler.OPPONENT_BOARD);
            attackingPlayer.DrawOpponentBoard();
            Console.WriteLine();

            int column = EnterColumn();
            int row = EnterRow();
            var coordinates = attackingPlayer.FireShot(row, column);
            var result = opponent.HandleShot(coordinates);

            string shotResult = attackingPlayer.HandleShotResult(coordinates, result);
            while (shotResult == ConstantsHandler.ALREADY_HIT)
            {
                Console.WriteLine(ConstantsHandler.ALREADY_HIT);
                column = EnterColumn();
                row = EnterRow();
                coordinates = attackingPlayer.FireShot(row, column);
                result = opponent.HandleShot(coordinates);
                shotResult = attackingPlayer.HandleShotResult(coordinates, result);
            }

            Console.WriteLine();
            Console.WriteLine(shotResult);
            attackingPlayer.DrawOpponentBoard();

            Console.WriteLine(ConstantsHandler.CONTINUE);
        }


        public void PlayRound()
        {
            PlayTurn(Player1, Player2);
            Console.ReadKey(true);
            if (!Player2.IsDefeated)
            {
                PlayTurn(Player2, Player1);
                Console.ReadKey(true);
            }
        }

        public void Play()
        {
            while (!Player1.IsDefeated && !Player2.IsDefeated)
            {
                PlayRound();
            }

            Console.Clear();
            Console.WriteLine();

            if (Player2.IsDefeated)
            {
                Console.WriteLine(Player2.Name + ConstantsHandler.WINNER_MSG_START + Player1.Name + ConstantsHandler.WINNER_MSG_END);
            }
            else if (Player1.IsDefeated)
            {
                Console.WriteLine(Player1.Name + ConstantsHandler.WINNER_MSG_START + Player2.Name + ConstantsHandler.WINNER_MSG_END);
            }
        }
    }
}
