using BattleshipClassLibrary;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using static BattleshipTests.TestExtensions;

namespace BattleshipTests.ValidationTests
{
    public class Player_Tests
    {
        #region IsDefeatedTests
        [Fact]
        public void IsDefeated_Default()
        {
            MakeValidPlayer().IsDefeated.Should().BeFalse();
        }

        [Fact]
        public void IsDefeated_NotAllShipsSunk()
        {
            var player = new Player("Test")
            {
                Fleet = new List<Ship>()
                {
                    new Battleship(), // Taken no hits, so hasn't sank
                    new Battleship()
                    {
                        Hits = 3
                    }
                }
            };
            player.IsDefeated.Should().BeFalse();
        }

        [Fact]
        public void IsDefeated_AllShipsSunk()
        {
            var player = MakeValidPlayer();
            for (int i = 0; i >= player.Fleet.Count; i++)
            {
                MakeValidPlayer(x => x.Fleet[i].Hits = 3).IsDefeated.Should().BeTrue();
            }
        }
        #endregion

        #region PlaceShipTests
        [Fact]
        public void PlaceShip_Success_Horizontal()
        {
            var player = MakeValidPlayer();
            var ship = new Battleship();
            int startRow = 1;
            int startColumn = 1;
            string orientation = "horizontal";
            player.PlaceShip(ship, startRow, startColumn, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_SUCCESS);
        }

        [Fact]
        public void PlaceShip_Success_Vertical()
        {
            var player = MakeValidPlayer();
            var ship = new Battleship();
            int startRow = 1;
            int startColumn = 1;
            string orientation = "vertical";
            player.PlaceShip(ship, startRow, startColumn, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_SUCCESS);
        }

        [Fact]
        public void PlaceShip_Success_CheckPanels()
        {
            var player = MakeValidPlayer();
            var ship = new Battleship();
            int startRow = 1;
            int startColumn = 1;
            string orientation = "horizontal";

            player.PlaceShip(ship, startRow, startColumn, orientation);
            player.OwnBoard.Panels[0].OccupationStatus.Should().Be(ship.Status);
        }

        [Fact]
        public void PlaceShip_Failure_InvalidEndCoordinates_Row()
        {
            var player = MakeValidPlayer();
            var ship = new Battleship();
            int startRow = ConstantsHandler.BOARD_LENGTH + 1;
            int startColumn = 1;
            string orientation = "horizontal";
            player.PlaceShip(ship, startRow, startColumn, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_INVALID_COORDS);
        }

        [Fact]
        public void PlaceShip_Failure_InvalidEndCoordinates_Column()
        {
            var player = MakeValidPlayer();
            var ship = new Battleship();
            int startRow = 1;
            int startColumn = ConstantsHandler.BOARD_LENGTH + 1;
            string orientation = "horizontal";
            player.PlaceShip(ship, startRow, startColumn, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_INVALID_COORDS);
        }

        [Fact]
        public void PlaceShip_Failure_PanelAlreadyHasShip()
        {
            var player = MakeValidPlayer();
            var ship = new Battleship();
            int startRow = 1;
            int startColumn = 1;
            string orientation = "horizontal";
            player.PlaceShip(ship, startRow, startColumn, orientation);

            player.PlaceShip(ship, startRow, startColumn, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_HAS_SHIP);
        }
        #endregion

        [Fact]
        public void FireShot()
        {
            int row = 1;
            int column = 1;
            var player = MakeValidPlayer();
            var expected = new Coordinates(row, column);
            player.FireShot(row, column).Should().BeEquivalentTo(expected);
        }
    }
}
