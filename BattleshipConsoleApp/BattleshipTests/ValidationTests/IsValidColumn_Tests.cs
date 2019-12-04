using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class IsValidColumn_Tests
    {
        private string input;
        [Fact]
        public void IsValidColumn_Affirmative()
        {
            input = "A";
            Validator.IsValidColumn(input).Should().BeTrue();
        }

        [Fact]
        public void IsValidColumn_Negative_InputIsNotSingleLetter()
        {
            input = "AA";
            Validator.IsValidColumn(input).Should().BeFalse();
        }

        [Fact]
        public void IsValidColumn_Negative_InputIsOutsideBoard()
        {
            input = "Z";
            Validator.IsValidColumn(input).Should().BeFalse();
        }
    }
}
