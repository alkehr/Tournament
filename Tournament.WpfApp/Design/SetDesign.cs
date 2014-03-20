using Tournament.WpfApp.Core;
using Tournament.WpfApp.ViewModels;

namespace Tournament.WpfApp.Design
{
// ReSharper disable ClassNeverInstantiated.Global
    public class SetDesign : SetViewModel
// ReSharper restore ClassNeverInstantiated.Global
    {
        private const string DesignHomeTeam = "Home Team";
        private const string DesignAwayTeam = "Away Team";

        public SetDesign() : base(new Set(DesignAwayTeam, DesignHomeTeam, 10, 20), DesignHomeTeam) { }
    }
}
