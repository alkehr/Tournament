using Tournament.WpfApp.Core;

namespace Tournament.WpfApp.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            CurrentContent = new PoolViewModel(CreatePoolFromDummyData());
        }

        public object CurrentContent { get; set; }

        private static Pool CreatePoolFromDummyData()
        {
            const string team1 = "Team #1";
            const string team2 = "Team #2";
            const string team3 = "Team #3";
            const string team4 = "Team #4";

            var pool = new Pool("Pool A", "WT - The Box Ct. 7", new[] { team1, team2, team3, team4 }, 2);

            //pool.Matches.ElementAt(0).Sets.ElementAt(0).SetTeamScore(team1, 11);
            //pool.Matches.ElementAt(0).Sets.ElementAt(0).SetTeamScore(team2, 12);
            //pool.Matches.ElementAt(0).Sets.ElementAt(1).SetTeamScore(team1, 21);
            //pool.Matches.ElementAt(0).Sets.ElementAt(1).SetTeamScore(team2, 22);

            //pool.Matches.ElementAt(1).Sets.ElementAt(0).SetTeamScore(team1, 11);
            //pool.Matches.ElementAt(1).Sets.ElementAt(0).SetTeamScore(team3, 13);
            //pool.Matches.ElementAt(1).Sets.ElementAt(1).SetTeamScore(team1, 21);
            //pool.Matches.ElementAt(1).Sets.ElementAt(1).SetTeamScore(team3, 23);

            //pool.Matches.ElementAt(2).Sets.ElementAt(0).SetTeamScore(team1, 11);
            //pool.Matches.ElementAt(2).Sets.ElementAt(0).SetTeamScore(team4, 14);
            //pool.Matches.ElementAt(2).Sets.ElementAt(1).SetTeamScore(team1, 21);
            //pool.Matches.ElementAt(2).Sets.ElementAt(1).SetTeamScore(team4, 24);

            //pool.Matches.ElementAt(3).Sets.ElementAt(0).SetTeamScore(team2, 12);
            //pool.Matches.ElementAt(3).Sets.ElementAt(0).SetTeamScore(team3, 13);
            //pool.Matches.ElementAt(3).Sets.ElementAt(1).SetTeamScore(team2, 22);
            //pool.Matches.ElementAt(3).Sets.ElementAt(1).SetTeamScore(team3, 23);

            //pool.Matches.ElementAt(4).Sets.ElementAt(0).SetTeamScore(team2, 12);
            //pool.Matches.ElementAt(4).Sets.ElementAt(0).SetTeamScore(team4, 14);
            //pool.Matches.ElementAt(4).Sets.ElementAt(1).SetTeamScore(team2, 22);
            //pool.Matches.ElementAt(4).Sets.ElementAt(1).SetTeamScore(team4, 24);

            //pool.Matches.ElementAt(5).Sets.ElementAt(0).SetTeamScore(team3, 13);
            //pool.Matches.ElementAt(5).Sets.ElementAt(0).SetTeamScore(team4, 14);
            //pool.Matches.ElementAt(5).Sets.ElementAt(1).SetTeamScore(team3, 23);
            //pool.Matches.ElementAt(5).Sets.ElementAt(1).SetTeamScore(team4, 24);

            return pool;
        }
    }
}
