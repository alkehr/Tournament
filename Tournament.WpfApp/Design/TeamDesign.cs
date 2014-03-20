using Tournament.WpfApp.ViewModels;

namespace Tournament.WpfApp.Design
{
// ReSharper disable ClassNeverInstantiated.Global
    public class TeamDesign : TeamViewModel
// ReSharper restore ClassNeverInstantiated.Global
    {
        public TeamDesign()
            : base(PoolDesign.Team1, PoolDesign.CreateDesignPool())
        {
        }
    }
}
