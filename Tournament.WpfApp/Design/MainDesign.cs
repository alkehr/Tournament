using Tournament.WpfApp.ViewModels;

namespace Tournament.WpfApp.Design
{
// ReSharper disable ClassNeverInstantiated.Global
    public class MainDesign : MainViewModel
// ReSharper restore ClassNeverInstantiated.Global
    {
        public MainDesign()
        {
            CurrentContent = new PoolDesign();
        }
    }
}
