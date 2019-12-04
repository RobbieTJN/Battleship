using System.ComponentModel;

namespace BattleshipClassLibrary
{
    public enum PanelStatus
    {
        [Description(" ")]
        Empty,
        [Description("S")]
        Destroyer,
        [Description("S")]
        Submarine,
        [Description("S")]
        Cruiser,
        [Description("S")]
        Battlehip,
        [Description("S")]
        AircraftCarrier,
        [Description("X")]
        Hit,
        [Description("M")]
        Miss
    }
}
