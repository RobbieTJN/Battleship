using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class IsValidName_Tests
    {
        private string input;
        [Fact]
        public void IsValidName_Affirmative()
        {
            input = "Test";
            Validator.IsValidName(input).Should().BeTrue();
        }

        [Fact]
        public void IsValidName_Negative_TooLong()
        {
            input = "aaaaaaaaaaaaaaaaaaaaa";
            Validator.IsValidName(input).Should().BeFalse();
        }

        [Fact]
        public void IsValidName_Negative_InputIsNotLetters()
        {
            input = "1";
            Validator.IsValidName(input).Should().BeFalse();
        }
    }
}
