using BruPark.Apps.WPF.Models;
using BruPark.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace BruPark.Apps.WPF.Pages
{
    /// <summary>
    /// Interaction logic for ParkingListPage.xaml
    /// </summary>
    public partial class ParkingListPage : Page
    {
        public ParkingListPage(IList<ParkingRO> parkings)
        {
            InitializeComponent();

            list.ItemsSource = parkings;
        }



        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ParkingRO parking = (ParkingRO)((ListViewItem)sender).Content;

            NavigationService.Navigate(new ParkingDetailsPage(new ParkingModel(parking)));
        }

        private void HandleNewSearch(object sender, EventArgs args)
        {
            NavigationService.Navigate(new SearchFormPage());
        }
    }
}
