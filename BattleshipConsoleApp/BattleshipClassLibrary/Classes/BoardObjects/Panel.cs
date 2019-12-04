using BattleshipClassLibrary.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BattleshipClassLibrary
{
    public class Panel
    {
        public PanelStatus OccupationStatus;
        public Coordinates Coordinates;

        public string DisplayStatus => OccupationStatus.GetDescription<DescriptionAttribute>().Description;

        public Panel(int column, int row)
        {
            Coordinates = new Coordinates(column, row);
            OccupationStatus = PanelStatus.Empty;
        }

        public bool HasShip => OccupationStatus == PanelStatus.Destroyer
            || OccupationStatus == PanelStatus.Submarine
            || OccupationStatus == PanelStatus.Cruiser
            || OccupationStatus == PanelStatus.Battlehip
            || OccupationStatus == PanelStatus.AircraftCarrier;
    }
}
