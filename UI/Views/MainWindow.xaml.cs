using System.Windows;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //DataContext = new ViewModels.MainWindowViewModel();
        }

        //private void ChangeText_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    (DataContext as ViewModels.MainWindowViewModel).WelcomeText = "Mein neuer Text aus dem Code Behind.";
        //}
    }
}
