using System;

namespace Tournament.WpfApp.Core
{
    public class Set
    {
        public static readonly Set NullSet = new Set();

        private bool _team1ScoreSet;
        private bool _team2ScoreSet;
        private readonly bool _isNullSet;

        private Set()
        {
            _isNullSet = true;
        }

        public Set(string team1, string team2)
        {
            Team1 = team1;
            Team2 = team2;
        }

        public Set(string team1, string team2, int team1Score, int team2Score)
            : this(team1, team2)
        {
            Team1Score = team1Score;
            Team2Score = team2Score;
        }

        public event EventHandler ScoresChanged;

        public bool IsNullSet { get { return _isNullSet; } }

        public bool IsComplete { get { return !_isNullSet && (_team1ScoreSet && _team2ScoreSet); } }

        public string Team1 { get; private set; }
        public string Team2 { get; private set; }

        private int Team1Score { get; set; }
        private int Team2Score { get; set; }

        public string GetWinner()
        {
            if (!IsComplete)
                return null;

            return Team1Score > Team2Score ? Team1 : Team2;
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

        public int GetTeamScore(string team)
        {
            if (_isNullSet)
                return 0;

            if (Team1 == team)
                return Team1Score;

            if (Team2 == team)
                return Team2Score;

            return 0;
        }

        public void SetTeamScore(string team, int score)
        {
            if (_isNullSet)
                return;

            if (Team1 == team)
            {
                Team1Score = score;
                _team1ScoreSet = true;
            }

            if (Team2 == team)
            {
                Team2Score = score;
                _team2ScoreSet = true;
            }
        }

        public void RaiseScoresChanged()
        {
            var handler = ScoresChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
