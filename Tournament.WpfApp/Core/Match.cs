using System;
using System.Collections.Generic;
using System.Linq;

namespace Tournament.WpfApp.Core
{
    public class Match
    {
        private readonly List<Set> _sets;

        public Match(string team1, string team2, int numberOfSets)
        {
            Team1 = team1;
            Team2 = team2;

            _sets = new List<Set>(GenerateEmptySets(Team1, Team2, numberOfSets));
        }

        public event EventHandler ScoresChanged;

        public IEnumerable<Set> Sets { get { return _sets.AsReadOnly(); } }

        private bool IsComplete
        {
            get { return Sets.All(s => s.IsComplete); }
        }

        public string Team1 { get; private set; }

        public string Team2 { get; private set; }

        public int GetSetsWon(string team)
        {
            return Sets.Count(s => s.GetWinner() == team);
        }

        public int GetSetsLost(string team)
        {
            return Sets.Count(s => s.GetLoser() == team);
        }

        public string GetWinner()
        {
            if (!IsComplete)
                return null;

            var team1SetsWon = GetSetsWon(Team1);
            var team2SetsWon = GetSetsWon(Team2);

            if (team1SetsWon > team2SetsWon)
                return Team1;

            if (team2SetsWon > team1SetsWon)
                return Team2;

            return null;
        }

        public string GetLoser()
        {
            if (!IsComplete)
                return null;

            var winner = GetWinner();
            if (winner == Team1)
                return Team2;

            if (winner == Team2)
                return Team1;

            return null;
        }

        private void OnSetScoresChanged(object sender, EventArgs eventArgs)
        {
            RaiseScoresChanged();
        }

        private IEnumerable<Set> GenerateEmptySets(string team1, string team2, int numberOfSets)
        {
            var sets = Enumerable.Range(1, numberOfSets).Select(i => new Set(team1, team2));
            foreach (var set in sets)
            {
                set.ScoresChanged += OnSetScoresChanged;
                yield return set;
            }
        }

        private void RaiseScoresChanged()
        {
            var handler = ScoresChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
