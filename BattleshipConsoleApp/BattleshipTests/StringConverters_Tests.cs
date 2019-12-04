using BattleshipClassLibrary;
using BattleshipClassLibrary.Validation;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class StringConverters_Tests
    {
        #region StringToIntTests
        [Fact]
        public void StringToInt_A()
        {
            string input = "A";
            StringConverters.StringToInt(input).Should().Be(1);
        }

        [Fact]
        public void StringToInt_B()
        {
            string input = "B";
            StringConverters.StringToInt(input).Should().Be(2);
        }

        [Fact]
        public void StringToInt_C()
        {
            string input = "C";
            StringConverters.StringToInt(input).Should().Be(3);
        }

        [Fact]
        public void StringToInt_D()
        {
            string input = "D";
            StringConverters.StringToInt(input).Should().Be(4);
        }

        [Fact]
        public void StringToInt_E()
        {
            string input = "E";
            StringConverters.StringToInt(input).Should().Be(5);
        }

        [Fact]
        public void StringToInt_F()
        {
            string input = "F";
            StringConverters.StringToInt(input).Should().Be(6);
        }

        [Fact]
        public void StringToInt_G()
        {
            string input = "G";
            StringConverters.StringToInt(input).Should().Be(7);
        }

        [Fact]
        public void StringToInt_H()
        {
            string input = "H";
            StringConverters.StringToInt(input).Should().Be(8);
        }
        #endregion

        [Fact]
        public void Orientation_Horizontal()
        {
            string input = "H";
            StringConverters.Orientation(input).Should().Be("horizontal");
        }

        [Fact]
        public void Orientation_Vertical()
        {
            string input = "V";
            StringConverters.Orientation(input).Should().Be("vertical");
        }

        [Fact]
        public void Orientation_InvalidInput()
        {
            string input = "G";
            StringConverters.Orientation(input).Should().Be("Error");
        }

    }
}
