using FluentAssertions;
using Xunit;
using static BattleshipTests.TestExtensions;

namespace BattleshipTests.ValidationTests
{
    public class Ship_Tests
    {
        [Fact]
        public void HasSunk_Battleship_Default()
        {
            MakeValidBattleship().HasSunk.Should().BeFalse();
        }

        [Fact]
        public void HasSunk_Battleship_TakenDamage()
        {
            MakeValidBattleship(ship => ship.Hits = 1).HasSunk.Should().BeFalse();
        }

        [Fact]
        public void HasSunk_Battleship_True()
        {
            MakeValidBattleship(ship => ship.Hits = 3).HasSunk.Should().BeTrue();
        }
    }
}
