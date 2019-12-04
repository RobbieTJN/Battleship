using BattleshipClassLibrary;
using FluentAssertions;
using Xunit;

namespace BattleshipTests.ValidationTests
{
    public class StringConverters_Tests
    {
        private string input;

        #region StringToIntTests
        [Fact]
        public void StringToInt_A()
        {
            input = "A";
            StringConverters.StringToInt(input).Should().Be(1);
        }

        [Fact]
        public void StringToInt_B()
        {
            input = "B";
            StringConverters.StringToInt(input).Should().Be(2);
        }

        [Fact]
        public void StringToInt_C()
        {
            input = "C";
            StringConverters.StringToInt(input).Should().Be(3);
        }

        [Fact]
        public void StringToInt_D()
        {
            input = "D";
            StringConverters.StringToInt(input).Should().Be(4);
        }

        [Fact]
        public void StringToInt_E()
        {
            input = "E";
            StringConverters.StringToInt(input).Should().Be(5);
        }

        [Fact]
        public void StringToInt_F()
        {
            input = "F";
            StringConverters.StringToInt(input).Should().Be(6);
        }

        [Fact]
        public void StringToInt_G()
        {
            input = "G";
            StringConverters.StringToInt(input).Should().Be(7);
        }

        [Fact]
        public void StringToInt_H()
        {
            input = "H";
            StringConverters.StringToInt(input).Should().Be(8);
        }
        #endregion

        [Fact]
        public void Orientation_Horizontal()
        {
            input = "H";
            StringConverters.Orientation(input).Should().Be("horizontal");
        }

        [Fact]
        public void Orientation_Vertical()
        {
            input = "V";
            StringConverters.Orientation(input).Should().Be("vertical");
        }

        [Fact]
        public void Orientation_InvalidInput()
        {
            input = "G";
            StringConverters.Orientation(input).Should().Be("Error");
        }

    }
}
