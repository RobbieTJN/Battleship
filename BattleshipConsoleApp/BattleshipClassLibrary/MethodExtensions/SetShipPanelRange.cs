using System.Collections.Generic;
using System.Linq;

namespace BattleshipClassLibrary.Methods
{
    public static class SetShipPanelRange
    {
        public static List<Panel> ShipPanelRange(this List<Panel> panels, int startColumn, int startRow, int endColumn, int endRow)
        {
            return panels.Where(x => x.Coordinates.Column >= startColumn
                                     && x.Coordinates.Row >= startRow
                                     && x.Coordinates.Column <= endColumn
                                     && x.Coordinates.Row <= endRow).ToList();
        }
    }
}
