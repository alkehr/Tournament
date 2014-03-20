using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tournament.WpfApp.Core;

namespace Tournament.WpfApp.ViewModels
{
    public class TeamViewModel : ViewModelBase
    {
        private readonly string _team;
        private readonly Pool _pool;

        public TeamViewModel(string team, Pool pool)
        {
            _team = team;
            _pool = pool;
            _pool.ScoresChanged += OnPoolScoresChanged;
        }

        public string TeamName { get { return _team; } }

        private List<MatchViewModel> _matches; 

        public IEnumerable<MatchViewModel> Matches
        {
            get { return (_matches ?? (_matches = new List<MatchViewModel>(CreateMatchViewModels()))).AsReadOnly(); }
        }

        private Match FindMatch(string team1, string team2)
        {
            var team1Matches = _pool.Matches.Where(m => m.Team1 == team1 || m.Team2 == team1);
            var x = team1Matches.Where(m => m.Team1 == team2 || m.Team2 == team2);

            return x.FirstOrDefault();
        }

        private IEnumerable<MatchViewModel> CreateMatchViewModels()
        {
            foreach (var team in _pool.Teams)
            {
                if (team == _team)
                    yield return new MatchViewModel();
                else
                {
                    var match = FindMatch(team, _team);
                    yield return new MatchViewModel(match, _team);
                }
            }
        }

        public int MatchesWon
        {
            get { return _pool.GetMatchesWon(_team); }
        }

        public int MatchesLost
        {
            get { return _pool.GetMatchesLost(_team); }
        }

        public int SetsWon
        {
            get { return _pool.GetSetsWon(_team); }
        }

        public int SetsLost
        {
            get { return _pool.GetSetsLost(_team); }
        }

        private int TotalSets
        {
            get { return SetsWon + SetsLost; }
        }

        public double SetWinRatio
        {
            get { return SetsWon / (double)TotalSets; }
        }

        public string Rank
        {
            get
            {
                var rank = _pool.GetTeamRank(_team);
                return rank > 0 ? rank.ToString(CultureInfo.InvariantCulture) : "?";
            }
        }

        private void OnPoolScoresChanged(object sender, EventArgs eventArgs)
        {
            // ReSharper disable ExplicitCallerInfoArgument
            OnPropertyChanged("MatchesWon");
            OnPropertyChanged("MatchesLost");
            OnPropertyChanged("SetsWon");
            OnPropertyChanged("SetsLost");
            OnPropertyChanged("SetWinRatio");
            OnPropertyChanged("Rank");
            // ReSharper restore ExplicitCallerInfoArgument
        }
    }
}
