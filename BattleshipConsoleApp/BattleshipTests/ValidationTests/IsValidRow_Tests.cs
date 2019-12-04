using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class IsValidRow_Tests
    {
        [Fact]
        public void IsValidRow_Affirmative()
        {
            string input = "1";
            Validator.IsValidRow(input).Should().BeTrue();
        }

        [Fact]
        public void IsValidRow_Negative_CannotParse()
        {
            string input = "N";
            Validator.IsValidRow(input).Should().BeFalse();
        }

        [Fact]
        public void IsValidRow_Negative_InputIsOutsideBoard()
        {
            string input = "100";
            Validator.IsValidRow(input).Should().BeFalse();
        }

        [Fact]
        public void IsValidRow_Negative_InputIsZero()
        {
            string input = "0";
            Validator.IsValidRow(input).Should().BeFalse();
        }
    }
}
