using System.Collections.Generic;
using System.Linq;

namespace BattleshipClassLibrary.Methods
{
    public static class GetPanelAtCoordinates
    {
        public static Panel At(this List<Panel> panels, int row, int column)
        {
            return panels.Where(panel => panel.Coordinates.Row == row && panel.Coordinates.Column == column).First();
        }
    }
}