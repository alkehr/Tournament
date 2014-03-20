using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tournament.WpfApp.Properties;

namespace Tournament.WpfApp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
