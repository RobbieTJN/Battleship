using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipClassLibrary
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Size = 3;
            Status = PanelStatus.Battlehip;
        }
    }
}
