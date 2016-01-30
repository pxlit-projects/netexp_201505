using BruPark.Apps.WPF.Models;
using BruPark.WebApi.Models;
using System.Windows.Controls;

namespace BruPark.Apps.WPF.Pages
{
    /// <summary>
    /// Interaction logic for ParkingDetailsPage.xaml
    /// </summary>
    public partial class ParkingDetailsPage : Page
    {
        private ParkingModel model;



        public ParkingDetailsPage(ParkingModel model)
        {
            InitializeComponent();

            DataContext = this.model = model;
        }
    }
}
