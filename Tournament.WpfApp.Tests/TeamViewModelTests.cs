using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tournament.WpfApp.Core;
using Tournament.WpfApp.ViewModels;

namespace Tournament.WpfApp.Tests
{
    [TestClass]
    public class TeamViewModelTests
    {
        private static Pool GenerateTestPool(string team1, string team2, string team3)
        {
            var pool = new Pool("Pool A", "Pool A Location", new[] { team1, team2, team3 }, 2);
            pool.Matches.ElementAt(0).Sets.ElementAt(0).SetTeamScore(team1, 11);
            pool.Matches.ElementAt(0).Sets.ElementAt(0).SetTeamScore(team2, 12);
            pool.Matches.ElementAt(0).Sets.ElementAt(1).SetTeamScore(team1, 21);
            pool.Matches.ElementAt(0).Sets.ElementAt(1).SetTeamScore(team2, 22);

            pool.Matches.ElementAt(1).Sets.ElementAt(0).SetTeamScore(team1, 11);
            pool.Matches.ElementAt(1).Sets.ElementAt(0).SetTeamScore(team3, 13);
            pool.Matches.ElementAt(1).Sets.ElementAt(1).SetTeamScore(team1, 21);
            pool.Matches.ElementAt(1).Sets.ElementAt(1).SetTeamScore(team3, 23);

            pool.Matches.ElementAt(2).Sets.ElementAt(0).SetTeamScore(team2, 12);
            pool.Matches.ElementAt(2).Sets.ElementAt(0).SetTeamScore(team3, 13);
            pool.Matches.ElementAt(2).Sets.ElementAt(1).SetTeamScore(team2, 22);
            pool.Matches.ElementAt(2).Sets.ElementAt(1).SetTeamScore(team3, 23);

            return pool;
        }

        [TestMethod]
        public void TeamMatchesWon_WithTeamLosingAllSets_ShouldEqualZero()
        {
            const string testTeam1 = "Team1";
            const string testTeam2 = "Team2";
            const string testTeam3 = "Team3";

            var testPool = GenerateTestPool(testTeam1, testTeam2, testTeam3);

            var teamViewModel = new TeamViewModel(testTeam1, testPool);

            const int expectedMatchesWon = 0;
            var actualMatchesWon = teamViewModel.MatchesWon;

            Assert.AreEqual(expectedMatchesWon, actualMatchesWon);
        }

        [TestMethod]
        public void TestMethod1()
        {
            const string testTeam1 = "Team1";
            const string testTeam2 = "Team2";
            const string testTeam3 = "Team3";

            var testPool = GenerateTestPool(testTeam1, testTeam2, testTeam3);

            var teamViewModel = new TeamViewModel(testTeam1, testPool);

            var matches = teamViewModel.Matches;
            
        }
    }
}
