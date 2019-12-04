using System.Collections.Generic;

namespace BattleshipClassLibrary
{
    public class Board
    {
        public List<Panel> Panels { get; set; }
        public Board()
        {
            Panels = new List<Panel>();
            for (int row = 1; row <= ConstantsHandler.BOARD_LENGTH; row++)
            {
                for (int column = 1; column <= ConstantsHandler.BOARD_LENGTH; column++)
                {
                    Panels.Add(new Panel(row, column));
                }
            }
        }
    }
}
