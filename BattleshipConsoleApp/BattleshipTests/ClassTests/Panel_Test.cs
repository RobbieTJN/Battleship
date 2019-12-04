using BattleshipClassLibrary;
using FluentAssertions;
using Xunit;
using static BattleshipTests.TestExtensions;

namespace BattleshipTests.ValidationTests
{
    public class Panel_Tests
    {
        [Fact]
        public void DisplayStatus()
        {
            MakeValidPanel().DisplayStatus.Should().Be(" ");
        }

        [Fact]
        public void HasShip_Default()
        {
            MakeValidPanel().HasShip.Should().BeFalse();
        }

        [Fact]
        public void HasShip_Affirmative()
        {
            MakeValidPanel(p => p.OccupationStatus = PanelStatus.Battleship).HasShip.Should().BeTrue();
        }
    }
}
