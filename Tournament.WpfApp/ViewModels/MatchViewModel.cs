using System;
using System.Collections.Generic;
using System.Linq;
using Tournament.WpfApp.Core;

namespace Tournament.WpfApp.ViewModels
{
    public class MatchViewModel : ViewModelBase
    {
        private readonly Match _match;
        private readonly string _homeTeam;
        private IEnumerable<SetViewModel> _sets;

        public MatchViewModel()
        {
        }

        public MatchViewModel(Match match, string homeTeam)
        {
            _match = match;
            _match.ScoresChanged += OnMatchScoresChanged;
            _homeTeam = homeTeam;
        }

        private int NumberOfSetsToShow
        {
            get { return 3; }
        }

        public IEnumerable<SetViewModel> Sets
        {
            get
            {
                if (_match == null)
                    yield break;

                if (_sets == null)
                    _sets = _match.Sets.Select(s => new SetViewModel(s, _homeTeam));

                int setsReturned = 0;
                foreach (var set in _sets)
                {
                    yield return set;
                    setsReturned++;
                }

                while (setsReturned++ < NumberOfSetsToShow)
                {
                    yield return SetViewModel.NonPlayedSet;
                }
            }
        }

        private bool IsBye
        {
            get { return _match == null; }
        }

        public bool WillPlay
        {
            get { return !IsBye; }
        }

        private void OnMatchScoresChanged(object sender, EventArgs eventArgs)
        {
            // ReSharper disable ExplicitCallerInfoArgument
            OnPropertyChanged("IsComplete");
            // ReSharper restore ExplicitCallerInfoArgument
        }
    }
}
