using System;
using System.Collections.Generic;
using System.Linq;

namespace Tournament.WpfApp.Core
{
    public class Pool
    {
        private readonly List<string> _teams;
        private readonly List<Match> _matches;

        public Pool(string name, string location, IEnumerable<string> teams, int numberOfSets)
        {
            Name = name;
            Location = location;
            _teams = new List<string>(teams);
            _matches = new List<Match>(GenerateMatches(_teams, numberOfSets));
        }

        public event EventHandler ScoresChanged;

        private IEnumerable<Match> GenerateMatches(List<string> teams, int numberOfSets)
        {
            var remainingTeams = new List<string>(teams);
            foreach (string team1 in teams)
            {
                foreach (string team2 in remainingTeams)
                {
                    if (team1 != team2)
                    {
                        var match = new Match(team1, team2, numberOfSets);
                        match.ScoresChanged += OnMatchScoresChanged;
                        yield return match;
                    }
                }

                remainingTeams.Remove(team1);
            }
        }

        private void OnMatchScoresChanged(object sender, EventArgs eventArgs)
        {
            RaiseScoresChanged();
        }

        public string Name { get; private set; }

        public string Location { get; private set; }

        public IEnumerable<string> Teams { get { return _teams.AsReadOnly(); } }

        public IEnumerable<Match> Matches { get { return _matches.AsReadOnly(); } }

        public int GetSetsWon(string team)
        {
            return Matches.Sum(m => m.GetSetsWon(team));
        }

        public int GetSetsLost(string team)
        {
            return Matches.Sum(m => m.GetSetsLost(team));
        }

        public int GetMatchesWon(string team)
        {
            return Matches.Count(m => m.GetWinner() == team);
        }

        public int GetMatchesLost(string team)
        {
            return Matches.Count(m => m.GetLoser() == team);
        }

        public int GetTeamRank(string team)
        {
            if (team == null) throw new ArgumentNullException("team");

            return 0;
        }

        private void RaiseScoresChanged()
        {
            var handler = ScoresChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
