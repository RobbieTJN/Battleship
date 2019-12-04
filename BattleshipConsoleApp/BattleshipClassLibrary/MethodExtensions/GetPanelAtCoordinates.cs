using System.Collections.Generic;
using System.Linq;

namespace BattleshipClassLibrary.Methods
{
    public static class GetPanelAtCoordinates
    {
        public static Panel At(this List<Panel> panels, int column, int row)
        {
            return panels.Where(x => x.Coordinates.Column == column && x.Coordinates.Row == row).First();
        }
    }
}
