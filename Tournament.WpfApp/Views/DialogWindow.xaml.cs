using System.Windows;

namespace Tournament.WpfApp.Views
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow
    {
        public static readonly DependencyProperty SubjectProperty;

        static DialogWindow()
        {
            SubjectProperty = DependencyProperty.Register("Subject", typeof(object), typeof(DialogWindow), new PropertyMetadata(default(object), OnSubjectChanged));
        }

        public DialogWindow()
        {
            InitializeComponent();
        }

        public object Subject
        {
            //get { return GetValue(SubjectProperty); }
            set { SetValue(SubjectProperty, value); }
        }

        private static void OnSubjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dialog = d as DialogWindow;
            if (dialog == null)
                return;

            dialog.MainContent.Content = e.NewValue;
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
