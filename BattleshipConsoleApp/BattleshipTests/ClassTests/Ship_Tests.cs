using BattleshipClassLibrary;
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
            MakeValidShip().HasSunk.Should().BeFalse();
        }

        [Fact]
        public void HasSunk_Battleship_TakenDamage()
        {
            MakeValidShip(s => s.Hits = 1).HasSunk.Should().BeFalse();
        }

        [Fact]
        public void HasSunk_Battleship_True()
        {
            MakeValidShip(s => s.Hits = 3).HasSunk.Should().BeTrue();
        }
    }
}
