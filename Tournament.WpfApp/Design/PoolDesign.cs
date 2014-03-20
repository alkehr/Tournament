using System.Linq;
using Tournament.WpfApp.Core;
using Tournament.WpfApp.ViewModels;

namespace Tournament.WpfApp.Design
{
    internal class PoolDesign : PoolViewModel
    {
        internal const string Team1 = "Team #1";
        internal const string Team2 = "Team #2";
        private const string Team3 = "Team #3";
        private const string Team4 = "Team #4";

        internal PoolDesign()
            : base(CreateDesignPool())
        {
        }

        internal static Pool CreateDesignPool()
        {
            var pool = new Pool("Pool A", "WT - The Box Ct. 7", new[] { Team1, Team2, Team3, Team4 }, 2);

            pool.Matches.ElementAt(0).Sets.ElementAt(0).SetTeamScore(Team1, 11);
            pool.Matches.ElementAt(0).Sets.ElementAt(0).SetTeamScore(Team2, 12);
            pool.Matches.ElementAt(0).Sets.ElementAt(1).SetTeamScore(Team1, 21);
            pool.Matches.ElementAt(0).Sets.ElementAt(1).SetTeamScore(Team2, 22);

            pool.Matches.ElementAt(1).Sets.ElementAt(0).SetTeamScore(Team1, 11);
            pool.Matches.ElementAt(1).Sets.ElementAt(0).SetTeamScore(Team3, 13);
            pool.Matches.ElementAt(1).Sets.ElementAt(1).SetTeamScore(Team1, 21);
            pool.Matches.ElementAt(1).Sets.ElementAt(1).SetTeamScore(Team3, 23);
            
            pool.Matches.ElementAt(2).Sets.ElementAt(0).SetTeamScore(Team1, 11);
            pool.Matches.ElementAt(2).Sets.ElementAt(0).SetTeamScore(Team4, 14);
            pool.Matches.ElementAt(2).Sets.ElementAt(1).SetTeamScore(Team1, 21);
            pool.Matches.ElementAt(2).Sets.ElementAt(1).SetTeamScore(Team4, 24);

            pool.Matches.ElementAt(3).Sets.ElementAt(0).SetTeamScore(Team2, 12);
            pool.Matches.ElementAt(3).Sets.ElementAt(0).SetTeamScore(Team3, 13);
            pool.Matches.ElementAt(3).Sets.ElementAt(1).SetTeamScore(Team2, 22);
            pool.Matches.ElementAt(3).Sets.ElementAt(1).SetTeamScore(Team3, 23);

            pool.Matches.ElementAt(4).Sets.ElementAt(0).SetTeamScore(Team2, 12);
            pool.Matches.ElementAt(4).Sets.ElementAt(0).SetTeamScore(Team4, 14);
            pool.Matches.ElementAt(4).Sets.ElementAt(1).SetTeamScore(Team2, 22);
            pool.Matches.ElementAt(4).Sets.ElementAt(1).SetTeamScore(Team4, 24);

            pool.Matches.ElementAt(5).Sets.ElementAt(0).SetTeamScore(Team3, 13);
            pool.Matches.ElementAt(5).Sets.ElementAt(0).SetTeamScore(Team4, 14);
            pool.Matches.ElementAt(5).Sets.ElementAt(1).SetTeamScore(Team3, 23);
            pool.Matches.ElementAt(5).Sets.ElementAt(1).SetTeamScore(Team4, 24);

            return pool;
        }
    }
}
