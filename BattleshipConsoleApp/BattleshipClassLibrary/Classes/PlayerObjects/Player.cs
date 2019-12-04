using BattleshipClassLibrary.Validation;
using BattleshipClassLibrary.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipClassLibrary.Enumerations;

namespace BattleshipClassLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public Board OwnBoard { get; set; }
        public Board OpponentBoard { get; set; }
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
            OpponentBoard = new Board();
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
            for (int row = 1; row <= ConstantsHandler.BOARD_LENGTH; row++)
            {
                for (int column = 1; column <= ConstantsHandler.BOARD_LENGTH; column++)
                {
                    if (OwnBoard.Panels.At(row, column).Coordinates.Column == 1)
                    {
                        Console.Write(row + verticalLine);
                    }
                    Console.Write(OwnBoard.Panels.At(row, column).DisplayStatus + verticalLine);
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
            for (int row = 1; row <= ConstantsHandler.BOARD_LENGTH; row++)
            {
                for (int column = 1; column <= ConstantsHandler.BOARD_LENGTH; column++)
                {
                    if (OpponentBoard.Panels.At(row, column).Coordinates.Column == 1)
                    {
                        Console.Write(row + verticalLine);
                    }
                    Console.Write(OpponentBoard.Panels.At(row, column).DisplayStatus + verticalLine);
                }
                Console.Write(Environment.NewLine);
                Console.WriteLine(horizontalLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public string PlaceShip(Ship ship, int startRow, int startColumn, string orientation)
        {
            string placementAvailable = ConstantsHandler.SHIP_PLACE_SUCCESS;
            int endRow = startRow, endColumn = startColumn;

            switch (orientation)
            {
                case "horizontal":
                    for (int i = 1; i < ship.Size; i++)
                    {
                        endColumn++;
                    }
                    break;
                case "vertical":
                    for (int i = 1; i < ship.Size; i++)
                    {
                        endRow++;
                    }
                    break;
                default:
                    placementAvailable = "Invalid orientation";
                    break;
            }

            if (!Validator.IsValidEndCoordinates(endRow, endColumn))
            {
                placementAvailable = "Invalid ship placement - ship would be partially outside the game board. Try again.";
            }
            else
            {
                var selectedPanels = OwnBoard.Panels.ShipPanelRange(startRow, startColumn, endRow, endColumn);
                if (selectedPanels.Any(panel => panel.HasShip))
                {
                    placementAvailable = "Invalid ship placement - one or more of the selected panels already contains a ship. Try again.";
                }
                else
                {
                    foreach (var panel in selectedPanels)
                    {
                        panel.OccupationStatus = ship.Status;
                    }
                }
            }
            
            return placementAvailable;
        }

        public Coordinates FireShot(int row, int column)
        {
            return new Coordinates(row, column);
        }

        public ShotResult HandleShot(Coordinates coordinates)
        {
            var affectedPanel = OwnBoard.Panels.At(coordinates.Row, coordinates.Column);

            if (affectedPanel.WasAlreadyTargeted == true)
            {
                return ShotResult.AlreadyHit;
            }

            if (!affectedPanel.HasShip)
            {
                affectedPanel.WasAlreadyTargeted = true;
                return ShotResult.Miss;
            }

            var affectedShip = Fleet.First(ship => ship.Status == affectedPanel.OccupationStatus);
            affectedShip.Hits++;

            if (affectedShip.HasSunk)
            {
                Console.WriteLine("[Sinking ship sounds] ...You sank my " + affectedShip.Name + ".");
                affectedPanel.WasAlreadyTargeted = true;
                return ShotResult.Sank;
            }
            else
            {
                affectedPanel.WasAlreadyTargeted = true;
                return ShotResult.Hit;
            }
        }

        public string HandleShotResult(Coordinates coordinates, ShotResult ShotResult)
        {
            string result = "";
            var affectedPanel = OpponentBoard.Panels.At(coordinates.Row, coordinates.Column);
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
                case ShotResult.AlreadyHit:
                    result = ConstantsHandler.ALREADY_HIT;
                    break;
                case ShotResult.Sank:
                    affectedPanel.OccupationStatus = PanelStatus.Hit;
                    break;
            }
            return result;
        }
    }
}
