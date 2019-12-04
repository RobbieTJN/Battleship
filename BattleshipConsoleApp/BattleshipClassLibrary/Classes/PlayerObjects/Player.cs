using BattleshipClassLibrary.Classes.BoardObjects;
using BattleshipClassLibrary.Validation;
using BattleshipClassLibrary.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleshipClassLibrary.Enumerations;

namespace BattleshipClassLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public Board OwnBoard { get; set; }
        public AttackBoard OpponentBoard { get; set; }
        public List<Ship> Fleet { get; set; }
        public bool IsDefeated => Fleet.All(ships => ships.HasSunk);

        private string horizontalLine = "  ---------------------------------";
        private string verticalLine = " | ";

        public Player (string name)
        {
            Name = name;
            Fleet = new List<Ship>()
            {
                new Battleship()
            };
            OwnBoard = new Board();
            OpponentBoard = new AttackBoard();
        }

        public void DrawOwnBoard()
        {
            Console.Write("    ");
            for (int i = 1; i <= ConstantsHandler.BOARD_LENGTH; i++)
            {
                Console.Write((ColumnHeaderLetters)i + "   ");
            }
            Console.Write(Environment.NewLine);
            Console.WriteLine(horizontalLine);
            for (int column = 1; column <= ConstantsHandler.BOARD_LENGTH; column++)
            {
                for (int ownRow = 1; ownRow <= ConstantsHandler.BOARD_LENGTH; ownRow++)
                {
                    if (OwnBoard.Panels.At(column, ownRow).Coordinates.Row == 1)
                    {
                        Console.Write(column + verticalLine);
                    }
                    Console.Write(OwnBoard.Panels.At(column, ownRow).DisplayStatus + verticalLine);
                }
                Console.Write(Environment.NewLine);
                Console.WriteLine(horizontalLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public void DrawOpponentBoard()
        {
            Console.Write("    ");
            for (int i = 1; i <= ConstantsHandler.BOARD_LENGTH; i++)
            {
                Console.Write((ColumnHeaderLetters)i + "   ");
            }
            Console.Write(Environment.NewLine);
            Console.WriteLine(horizontalLine);
            for (int column = 1; column <= ConstantsHandler.BOARD_LENGTH; column++)
            {
                for (int ownRow = 1; ownRow <= ConstantsHandler.BOARD_LENGTH; ownRow++)
                {
                    if (OwnBoard.Panels.At(column, ownRow).Coordinates.Row == 1)
                    {
                        Console.Write(column + verticalLine);
                    }
                    Console.Write(OpponentBoard.Panels.At(column, ownRow).DisplayStatus + verticalLine);
                }
                Console.Write(Environment.NewLine);
                Console.WriteLine(horizontalLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public string PlaceShip(Ship ship, int startColumn, int startRow, string orientation)
        {
            string placementAvailable = "Successfully placed ship.";
            int endColumn = startColumn, endRow = startRow;

            switch (orientation)
            {
                case "horizontal":
                    for (int i = 1; i < ship.Size; i++)
                    {
                        endRow++;
                    }
                    break;
                case "vertical":
                    for (int i = 1; i < ship.Size; i++)
                    {
                        endColumn++;
                    }
                    break;
                default:
                    placementAvailable = "Invalid orientation";
                    break;
            }

            if (!Validator.IsValidEndCoordinates(endColumn, endRow))
            {
                placementAvailable = "Invalid ship placement - ship would be partially outside the game board. Try again.";
            }

            var selectedPanels = OwnBoard.Panels.ShipPanelRange(startColumn, startRow, endColumn, endRow);
            if (selectedPanels.Any(panel => panel.HasShip))
            {
                placementAvailable = "Invalid ship placement - one or more of the selected panels already contains a ship. Try again.";
            }

            foreach (var panel in selectedPanels)
            {
                panel.OccupationStatus = ship.Status;
            }

            return placementAvailable;
        }

        public Coordinates FireShot(int column, int row)
        {
            return new Coordinates(column, row);
        }

        public ShotResult HandleShot(Coordinates coordinates)
        {
            var affectedPanel = OwnBoard.Panels.At(coordinates.Column, coordinates.Row);
            if (!affectedPanel.HasShip)
            {
                return ShotResult.Miss;
            }

            var affectedShip = Fleet.First(ship => ship.Status == affectedPanel.OccupationStatus);
            affectedShip.Hits++;

            if (affectedShip.HasSunk)
            {
                return ShotResult.Sank;
            }
            else
            {
                return ShotResult.Hit;
            }
        }

        public string HandleShotResult(Coordinates coordinates, ShotResult ShotResult)
        {
            string result = "";
            var affectedPanel = OpponentBoard.Panels.At(coordinates.Column, coordinates.Row);
            switch (ShotResult)
            {
                case ShotResult.Hit:
                    affectedPanel.OccupationStatus = PanelStatus.Hit;
                    result = "Ka-BOOOM! Hit registered!";
                    break;
                case ShotResult.Miss:
                    affectedPanel.OccupationStatus = PanelStatus.Miss;
                    result = "Splooosh...Hit missed.";
                    break;
                case ShotResult.Sank:
                    string affectedShip = affectedPanel.OccupationStatus.ToString();
                    //var affectedShip = Fleet.First(ship => ship.Status == affectedPanel.OccupationStatus);
                    affectedPanel.OccupationStatus = PanelStatus.Hit;
                    result = "[Sinking ship sounds] ...You sank my " + affectedShip + ".";
                    break;
            }
            return result;
        }
    }
}
