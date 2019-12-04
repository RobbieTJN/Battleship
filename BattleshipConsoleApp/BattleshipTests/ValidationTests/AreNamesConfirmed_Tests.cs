using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class AreNamesConfirmed_Tests
    {
        private string input;
        [Fact]
        public void AreNamesConfirmed_Affirmative()
        {
            input = "Y";
            Validator.AreNamesConfirmed(input).Should().BeTrue();
        }

        [Fact]
        public void AreNamesConfirmed_Negative()
        {
            input = "N";
            Validator.AreNamesConfirmed(input).Should().BeFalse();
        }
    }
}
