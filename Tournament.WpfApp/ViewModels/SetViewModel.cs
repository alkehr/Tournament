using System;
using System.Globalization;
using System.Windows.Input;
using Tournament.WpfApp.Commands;
using Tournament.WpfApp.Core;
using Tournament.WpfApp.Views;

namespace Tournament.WpfApp.ViewModels
{
    public class SetViewModel : ViewModelBase
    {
        public static readonly SetViewModel NonPlayedSet = new SetViewModel();

        private readonly bool _willPlay = true;
        private readonly Set _set;
        private readonly string _homeTeam;
        private readonly string _awayTeam;
        private ICommand _editScores;

        private SetViewModel()
        {
            _set = Set.NullSet;
            _willPlay = false;
        }

        public SetViewModel(Set set, string homeTeam)
        {
            _set = set;
            _set.ScoresChanged += OnSetScoresChanged;

            if (_set.Team1 == homeTeam)
            {
                _homeTeam = _set.Team1;
                _awayTeam = _set.Team2;
            }
            else if (_set.Team2 == homeTeam)
            {
                _homeTeam = _set.Team2;
                _awayTeam = _set.Team1;
            }
            else
            {
                throw new ArgumentException(Resources.Resources.SetViewModel_InvalidHomeTeam, "homeTeam");
            }
        }

        private bool WillPlay
        {
            get { return _willPlay; }
        }

        private string HomeTeam
        {
            get { return _homeTeam; }
        }

        private string AwayTeam
        {
            get { return _awayTeam; }
        }

        private int HomeTeamScore
        {
            get { return _set.GetTeamScore(_homeTeam); }
            set { _set.SetTeamScore(_homeTeam, value); }
        }

        private int AwayTeamScore
        {
            get { return _set.GetTeamScore(_awayTeam); }
            set { _set.SetTeamScore(_awayTeam, value); }
        }

        public string HomeTeamScoreText
        {
            get { return WillPlay ? HomeTeamScore.ToString(CultureInfo.InvariantCulture) : "-"; }
        }

        public string AwayTeamScoreText
        {
            get { return WillPlay ? AwayTeamScore.ToString(CultureInfo.InvariantCulture) : "-"; }
        }

        public ICommand EditScores
        {
            get { return _editScores ?? (_editScores = new DelegateCommand(OnEditScores, CanEditScores)); }
        }

        private bool CanEditScores()
        {
            return !_set.IsNullSet;
        }

        private void OnEditScores()
        {
            var setData = new SetData
                {
                    HomeTeamName = HomeTeam,
                    HomeTeamScore = HomeTeamScore,
                    AwayTeamName = AwayTeam,
                    AwayTeamScore = AwayTeamScore
                };

            var dialog = new DialogWindow { Subject = setData };
            var result = dialog.ShowDialog();

            if (result ?? false)
            {
                HomeTeamScore = setData.HomeTeamScore;
                AwayTeamScore = setData.AwayTeamScore;
                _set.RaiseScoresChanged();
            }
        }

        private void OnSetScoresChanged(object sender, EventArgs eventArgs)
        {
            // ReSharper disable ExplicitCallerInfoArgument
            OnPropertyChanged("HomeTeamScore");
            OnPropertyChanged("HomeTeamScoreText");
            OnPropertyChanged("AwayTeamScore");
            OnPropertyChanged("AwayTeamScoreText");
            // ReSharper restore ExplicitCallerInfoArgument
        }
    }
}
