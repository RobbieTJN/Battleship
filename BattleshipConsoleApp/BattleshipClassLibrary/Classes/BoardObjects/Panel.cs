using BattleshipClassLibrary.Methods;
using System.ComponentModel;

namespace BattleshipClassLibrary
{
    public class Panel
    {
        public PanelStatus OccupationStatus { get; set; }
        public Coordinates Coordinates { get; set; }
        public bool WasAlreadyTargeted = false;

        public string DisplayStatus => OccupationStatus.GetDescription<DescriptionAttribute>().Description;

        public Panel(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationStatus = PanelStatus.Empty;
        }

        public bool HasShip => OccupationStatus == PanelStatus.Destroyer
            || OccupationStatus == PanelStatus.Submarine
            || OccupationStatus == PanelStatus.Cruiser
            || OccupationStatus == PanelStatus.Battleship
            || OccupationStatus == PanelStatus.AircraftCarrier;

        
    }
}
