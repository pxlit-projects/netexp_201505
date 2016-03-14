using BruPark.Apps.WPF.ViewModels;
using BruPark.OpenData.Client;
using BruPark.OpenData.Models;
using BruPark.Tools.RestClient;
using BruPark.WebApi.Client;
using BruPark.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BruPark.Apps.WPF.Pages
{
    /// <summary>
    /// Interaction logic for SearchFormPage.xaml
    /// </summary>
    public partial class SearchFormPage : Page
    {
        public SearchFormPage()
        {
            InitializeComponent();

            this.DataContext = new SearchFormViewModel();
            
            // TODO: Remove after testing
            cmbMunicipality.SelectedIndex = 18; // 298;
            txtStreet.Text = "Klipveldstraat";
        }



        private void HandleSearch(object sender, EventArgs args)
        {
            Municipality municipality = (Municipality)cmbMunicipality.SelectedItem;

            if (municipality == null)
            {
                MessageBoxUtils.ShowWarning("Please select a municipality", "Missing input");
                return;
            }

            AddressRO address = new AddressRO();
            address.City = municipality.Name;
            address.PostalCode = Convert.ToString(municipality.PostalCode);
            address.Street = txtStreet.Text;

            if (string.IsNullOrWhiteSpace(address.Street))
            {
                MessageBoxUtils.ShowWarning("Please fill in the street", "Missing input");
                return;
            }

            SearchRequestRO request = new SearchRequestRO();
            request.Address = address;
            request.Disabled = (chkDisabled.IsChecked == true);

            Func<Response<SearchResponseRO>> producer = () =>
            {
                using (BruParkApiClient client = new BruParkApiClient())
                {
                    return client.SearchParkings(request);
                }
            };

            Action<Response<SearchResponseRO>> consumer = (response) =>
            {
                overlay.Visibility = System.Windows.Visibility.Hidden;

                if (response.Failure)
                {
                    Debug.WriteLine("ERROR:  " + response.Error);
                    MessageBoxUtils.ShowError(response.Error);
                    return;
                }

                SearchResponseRO output = response.Body;

                if (!String.IsNullOrEmpty(output.Error))
                {
                    Debug.WriteLine("ERROR:  " + output.Error);
                    MessageBoxUtils.ShowError(output.Error);
                    return;
                }

                NavigationService.Navigate(new ParkingListPage(output.Results));
            };

            overlay.Visibility = System.Windows.Visibility.Visible;

            BackgroundWorkerUtils.Start(producer, consumer);
        }
    }
}
