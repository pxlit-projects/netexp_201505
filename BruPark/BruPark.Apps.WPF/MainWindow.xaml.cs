using BruPark.Apps.WPF.Pages;
using System.Windows;

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

            frame.NavigationService.Navigate(new SearchFormPage());
        }
    }
}
