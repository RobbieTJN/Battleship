using BattleshipClassLibrary;
using BattleshipClassLibrary.Methods;
using System.ComponentModel;
using Xunit;

namespace BattleshipTests.MethodsTests
{
    public class GetPanelAtCoordinates_Test
    {
        [Fact]
        public void GetPanelAtCoordinates()
        {
            Board board = new Board();
            PanelStatus panelStatusBattleship = PanelStatus.Empty;
            string status = panelStatusBattleship.GetDescription<DescriptionAttribute>().Description;
            string output = board.Panels.At(1, 1).DisplayStatus;
            Assert.Equal(status, output);
        }
    }
}
