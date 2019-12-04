using BattleshipClassLibrary.GameObjects;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class GameUtilities_Tests
    {
        GameUtilities utilities = new GameUtilities();

        [Fact]
        public void CoinFlip()
        {
            utilities.CoinFlip().Should().BeInRange(1, 2);
        }
    }
}
