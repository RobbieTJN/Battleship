using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class IsValidEndCoordinates_Tests
    {
        private int endRow = 1, endColumn = 3;
        [Fact]
        public void IsValidEndCoordinates_Affirmative()
        {
            Validator.IsValidEndCoordinates(endRow, endColumn).Should().BeTrue();
        }

        [Fact]
        public void IsValidEndCoordinates_Negative_RowIsOutsideBoard()
        {
            endRow = 15;
            Validator.IsValidEndCoordinates(endRow, endColumn).Should().BeFalse();
        }

        [Fact]
        public void IsValidEndCoordinates_Negative_ColumnIsOutsideBoard()
        {
            endColumn = 15;
            Validator.IsValidEndCoordinates(endRow, endColumn).Should().BeFalse();
        }
    }
}
