using BattleshipClassLibrary.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipClassLibrary.Classes.BoardObjects
{
    public class AttackBoard : Board
    {
        public List<Coordinates> GetHitNeighbors()
        {
            List<Panel> panels = new List<Panel>();
            var hits = Panels.Where(x => x.OccupationStatus == PanelStatus.Hit);
            foreach (var hit in hits)
            {
                panels.AddRange(GetNeighbors(hit.Coordinates).ToList());
            }
            return panels.Distinct().Where(x => x.OccupationStatus == PanelStatus.Empty).Select(x => x.Coordinates).ToList();
        }

        public List<Panel> GetNeighbors(Coordinates coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            List<Panel> panels = new List<Panel>();
            if (column > ConstantsHandler.BOARD_LENGTH)
            {
                panels.Add(Panels.At(column - 1, row));
            }
            if (row > ConstantsHandler.BOARD_LENGTH)
            {
                panels.Add(Panels.At(column, row - 1));
            }
            if (row < ConstantsHandler.BOARD_LENGTH)
            {
                panels.Add(Panels.At(column, row + 1));
            }
            if (column < ConstantsHandler.BOARD_LENGTH)
            {
                panels.Add(Panels.At(column + 1, row));
            }
            return panels;
        }
    }
}
