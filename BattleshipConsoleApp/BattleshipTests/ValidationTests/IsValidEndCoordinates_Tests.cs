using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class IsValidEndCoordinates_Tests
    {
        [Fact]
        public void IsValidEndCoordinates_Affirmative()
        {
            int endRow = 1;
            int endColumn = 3;
            Validator.IsValidEndCoordinates(endRow, endColumn).Should().BeTrue();
        }

        [Fact]
        public void IsValidEndCoordinates_Negative_RowIsOutsideBoard()
        {
            int endRow = 15;
            int endColumn = 3;
            Validator.IsValidEndCoordinates(endRow, endColumn).Should().BeFalse();
        }

        [Fact]
        public void IsValidEndCoordinates_Negative_ColumnIsOutsideBoard()
        {
            int endRow = 1;
            int endColumn = 15;
            Validator.IsValidEndCoordinates(endRow, endColumn).Should().BeFalse();
        }
    }
}
