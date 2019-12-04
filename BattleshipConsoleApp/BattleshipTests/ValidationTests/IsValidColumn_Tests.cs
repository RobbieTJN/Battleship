using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class IsValidColumn_Tests
    {
        [Fact]
        public void IsValidColumn_Affirmative()
        {
            string input = "A";
            Validator.IsValidColumn(input).Should().BeTrue();
        }

        [Fact]
        public void IsValidRow_Negative_InputIsNotSingleLetter()
        {
            string input = "AA";
            Validator.IsValidColumn(input).Should().BeFalse();
        }

        [Fact]
        public void IsValidRow_Negative_InputIsOutsideBoard()
        {
            string input = "Z";
            Validator.IsValidColumn(input).Should().BeFalse();
        }
    }
}
