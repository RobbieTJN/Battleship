using BattleshipClassLibrary;
using BattleshipClassLibrary.Methods;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace BattleshipTests.MethodsTests
{
    public class SetShipPanelRange_Test
    {
        [Fact]
        public void ShipPanelRange()
        {
            
            Board board = new Board();
            var actual = board.Panels.ShipPanelRange(1, 1, 1, 3);

            var expected = new List<Panel>()
            {
                new Panel(1, 1),
                new Panel(1, 2),
                new Panel(1, 3)
            };

            expected.Should().BeEquivalentTo(actual);
            //Assert.Equal(expected, actual); // This fails for some reason?
        }
    }
}
