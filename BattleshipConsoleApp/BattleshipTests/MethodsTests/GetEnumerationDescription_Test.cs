using BattleshipClassLibrary;
using BattleshipClassLibrary.Methods;
using System.ComponentModel;
using Xunit;

namespace BattleshipTests
{
    public class GetEnumerationDescription_Test
    {
        [Fact]
        public void GetDescription()
        {
            PanelStatus panelStatusBattleship = PanelStatus.Empty;
            string status = panelStatusBattleship.GetDescription<DescriptionAttribute>().Description;
            Assert.Equal(" ", status);
        }
    }
}
