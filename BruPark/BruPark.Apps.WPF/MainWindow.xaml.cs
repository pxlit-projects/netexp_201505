using BruPark.Apps.WPF.Pages;
using System.Windows;
using System.Windows.Navigation;

namespace BruPark.Apps.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //  Hide the navigation bar
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            //  Show the search form
            frame.NavigationService.Navigate(new SearchFormPage());
        }
    }
}
