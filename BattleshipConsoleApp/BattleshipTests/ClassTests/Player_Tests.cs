using BattleshipClassLibrary;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using static BattleshipTests.TestExtensions;

namespace BattleshipTests.ValidationTests
{
    public class Player_Tests
    {
        #region CommonVariables
        private readonly Player player1 = MakeValidPlayer(), player2 = MakeValidPlayer();
        private readonly Ship ship = new Battleship();
        private int row = 1, column = 1;
        private string orientation = "horizontal";
        #endregion


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
            for (int i = 0; i >= player1.Fleet.Count; i++)
            {
                MakeValidPlayer(player => player.Fleet[i].Hits = 3).IsDefeated.Should().BeTrue();
            }
        }
        #endregion

        #region PlaceShipTests
        [Fact]
        public void PlaceShip_Success_Horizontal()
        {
            player1.PlaceShip(ship, row, column, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_SUCCESS);
        }

        [Fact]
        public void PlaceShip_Success_Vertical()
        {
            orientation = "vertical";
            player1.PlaceShip(ship, row, column, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_SUCCESS);
        }

        [Fact]
        public void PlaceShip_Success_CheckPanels()
        {
            player1.PlaceShip(ship, row, column, orientation);
            player1.OwnBoard.Panels[0].OccupationStatus.Should().Be(ship.Status);
        }

        [Fact]
        public void PlaceShip_Failure_InvalidEndCoordinates_Row()
        {
            row = ConstantsHandler.BOARD_LENGTH + 1;
            player1.PlaceShip(ship, row, column, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_INVALID_COORDS);
        }

        [Fact]
        public void PlaceShip_Failure_InvalidEndCoordinates_Column()
        {
            column = ConstantsHandler.BOARD_LENGTH + 1;
            player1.PlaceShip(ship, row, column, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_INVALID_COORDS);
        }

        [Fact]
        public void PlaceShip_Failure_PanelAlreadyHasShip()
        {
            player1.PlaceShip(ship, row, column, orientation);
            player1.PlaceShip(ship, row, column, orientation).Should().Be(ConstantsHandler.SHIP_PLACE_HAS_SHIP);
        }
        #endregion

        #region FireShotTest
        [Fact]
        public void FireShot()
        {
            var expected = new Coordinates(row, column);
            player1.FireShot(row, column).Should().BeEquivalentTo(expected);
        }
        #endregion

        #region HandleShotTests
        [Fact]
        public void HandleShot_Hit()
        {
            player2.PlaceShip(ship, row, column, orientation);
            var coordinates = player1.FireShot(row, column);
            player2.HandleShot(coordinates).Should().Be(ShotResult.Hit);
        }

        [Fact]
        public void HandleShot_Sank()
        {
            player2.PlaceShip(ship, row, column, orientation);

            var coordinates = player1.FireShot(row, column);
            var result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result);

            coordinates = player2.FireShot(row, column + 1);
            result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result);

            coordinates = player2.FireShot(row, column + 2);
            player2.HandleShot(coordinates).Should().Be(ShotResult.Sank);
        }

        [Fact]
        public void HandleShot_AlreadyHit()
        {
            player2.PlaceShip(ship, row, column, orientation);

            var coordinates = player1.FireShot(row, column);
            var result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result);

            coordinates = player2.FireShot(row, column);
            player2.HandleShot(coordinates).Should().Be(ShotResult.AlreadyHit);
        }

        [Fact]
        public void HandleShot_Miss()
        {
            player2.PlaceShip(ship, row, column, orientation);
            var coordinates = player1.FireShot(row + 1, column + 1);
            player2.HandleShot(coordinates).Should().Be(ShotResult.Miss);
        }
        #endregion

        #region HandleShotResultTests
        [Fact]
        public void HandleShotResult_Hit()
        {
            player2.PlaceShip(ship, row, column, orientation);
            var coordinates = player1.FireShot(row, column);
            var result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result).Should().Be(ConstantsHandler.HIT);
        }

        [Fact]
        public void HandleShotResult_Sank()
        {
            player2.PlaceShip(ship, row, column, orientation);

            var coordinates = player1.FireShot(row, column);
            var result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result);

            coordinates = player2.FireShot(row, column + 1);
            result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result);

            coordinates = player2.FireShot(row, column + 2);
            result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result).Should().Be("");
        }

        [Fact]
        public void HandleShotResult_AlreadyHit()
        {
            player2.PlaceShip(ship, row, column, orientation);

            var coordinates = player1.FireShot(row, column);
            var result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result);

            coordinates = player2.FireShot(row, column);
            result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result).Should().Be(ConstantsHandler.ALREADY_HIT);
        }

        [Fact]
        public void HandleShotResult_Miss()
        {
            player2.PlaceShip(ship, row, column, orientation);
            var coordinates = player1.FireShot(row + 1, column + 1);
            var result = player2.HandleShot(coordinates);
            player1.HandleShotResult(coordinates, result).Should().Be(ConstantsHandler.MISS);
        }
        #endregion
    }
}
