using BattleshipClassLibrary;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace BattleshipTests.BoardObjectsTests
{
    public class DrawEmptyBoard_Test
    {
        [Fact]
        public void ShipPanelRange()
        {
            Board actual = new Board();
            actual.DrawEmptyBoard();
            string expected =
                "o o o o o o o o " + Environment.NewLine +
                "o o o o o o o o " + Environment.NewLine +
                "o o o o o o o o " + Environment.NewLine +
                "o o o o o o o o " + Environment.NewLine +
                "o o o o o o o o " + Environment.NewLine +
                "o o o o o o o o " + Environment.NewLine +
                "o o o o o o o o " + Environment.NewLine +
                "o o o o o o o o " + Environment.NewLine;

            //Assert.Equal(expected, actual.DrawEmptyBoard());
        }
    }
}
