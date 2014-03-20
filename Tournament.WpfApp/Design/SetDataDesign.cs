using Tournament.WpfApp.Core;

namespace Tournament.WpfApp.Design
{
// ReSharper disable ClassNeverInstantiated.Global
    public class SetDataDesign : SetData
// ReSharper restore ClassNeverInstantiated.Global
    {
        public SetDataDesign()
        {
            HomeTeamName = "Design Home Team";
            AwayTeamName = "Design Away Team";

            HomeTeamScore = 25;
            AwayTeamScore = 10;
        }
    }
}
