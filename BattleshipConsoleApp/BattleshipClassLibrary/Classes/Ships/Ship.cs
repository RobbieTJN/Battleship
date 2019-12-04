using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipClassLibrary
{
    public abstract class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public PanelStatus Status { get; set; }
        public bool HasSunk => Hits >= Size;
    }
}
