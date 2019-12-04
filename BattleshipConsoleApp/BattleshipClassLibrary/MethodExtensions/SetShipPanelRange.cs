using System.Collections.Generic;
using System.Linq;

namespace BattleshipClassLibrary.Methods
{
    public static class SetShipPanelRange
    {
        public static List<Panel> ShipPanelRange(this List<Panel> panels, int startRow, int startColumn, int endRow, int endColumn)
        {
            return panels.Where(x => x.Coordinates.Row >= startRow
                                     && x.Coordinates.Column >= startColumn
                                     && x.Coordinates.Row <= endRow
                                     && x.Coordinates.Column <= endColumn).ToList();
        }
    }
}
