using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class IsValidRow_Tests
    {
        private string input;
        [Fact]
        public void IsValidRow_Affirmative()
        {
            input = "1";
            Validator.IsValidRow(input).Should().BeTrue();
        }

        [Fact]
        public void IsValidRow_Negative_CannotParse()
        {
            input = "N";
            Validator.IsValidRow(input).Should().BeFalse();
        }

        [Fact]
        public void IsValidRow_Negative_InputIsOutsideBoard()
        {
            input = "100";
            Validator.IsValidRow(input).Should().BeFalse();
        }

        [Fact]
        public void IsValidRow_Negative_InputIsZero()
        {
            input = "0";
            Validator.IsValidRow(input).Should().BeFalse();
        }
    }
}
