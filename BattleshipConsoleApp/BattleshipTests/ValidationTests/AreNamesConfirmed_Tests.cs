using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class AreNamesConfirmed_Tests
    {
        [Fact]
        public void AreNamesConfirmed_Affirmative()
        {
            string input = "Y";
            Validator.AreNamesConfirmed(input).Should().BeTrue();
        }

        [Fact]
        public void AreNamesConfirmed_Negative()
        {
            string input = "N";
            Validator.AreNamesConfirmed(input).Should().BeFalse();
        }
    }
}
