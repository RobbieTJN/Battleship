using BattleshipClassLibrary;
using System;

namespace BattleshipTests
{
    public static class TestExtensions
    {
        #region MakeValidPanelMethods
        public static Panel MakeValidPanel()
        {
            return new Panel(1, 1);
        }

        public static Panel MakeValidPanel(Action<Panel> initializer)
        {
            var panel = MakeValidPanel();
            initializer(panel);
            return panel;
        }
        #endregion

        #region MakeValidShipMethods
        public static Ship MakeValidBattleship()
        {
            return new Battleship();
        }

        public static Ship MakeValidBattleship(Action<Ship> initializer)
        {
            var ship = MakeValidBattleship();
            initializer(ship);
            return ship;
        }
        #endregion

        #region MakeValidPlayerMethods
        public static Player MakeValidPlayer()
        {
            return new Player("Test");
        }

        public static Player MakeValidPlayer(Action<Player> initializer)
        {
            var player = MakeValidPlayer();
            initializer(player);
            return player;
        }
        #endregion

        
    }
}
