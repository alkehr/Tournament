using System.Linq;
using Tournament.WpfApp.Core;
using Tournament.WpfApp.ViewModels;

namespace Tournament.WpfApp.Design
{
// ReSharper disable ClassNeverInstantiated.Global
    public class MatchDesign : MatchViewModel
// ReSharper restore ClassNeverInstantiated.Global
    {
        public MatchDesign()
            : base(CreateMatch(), PoolDesign.Team1)
        {
        }

        private static Match CreateMatch()
        {
            var match = new Match(PoolDesign.Team1, PoolDesign.Team2, 2);

            var set1 = match.Sets.ElementAt(0);
            set1.SetTeamScore(PoolDesign.Team1, 25);
            set1.SetTeamScore(PoolDesign.Team2, 15);

            var set2 = match.Sets.ElementAt(1);
            set2.SetTeamScore(PoolDesign.Team1, 25);
            set2.SetTeamScore(PoolDesign.Team2, 18);

            return match;
        }
    }
}
