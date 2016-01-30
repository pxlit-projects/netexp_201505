using BruPark.OpenData.Client;
using BruPark.OpenData.Models;
using BruPark.Tools.RestClient;
using BruPark.WebApi.Client;
using BruPark.WebApi.Models;
using System;
using System.Diagnostics;
using System.Windows.Controls;

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

            cmbMunicipality.ItemsSource = new MunicipalityManager().GetMunicipalitiesByPostalCode();


            // TODO: Remove after testing
            cmbMunicipality.SelectedIndex = 298;
            txtStreet.Text = "Detmoldlaan";
        }



        private void HandleSearch(object sender, EventArgs args)
        {
            Municipality municipality = (Municipality)cmbMunicipality.SelectedItem;

            AddressRO address = new AddressRO();
            address.City = municipality.Name;
            address.PostalCode = Convert.ToString(municipality.PostalCode);
            address.Street = txtStreet.Text;

            SearchRequestRO request = new SearchRequestRO();
            request.Address = address;
            request.Disabled = (chkDisabled.IsChecked == true);

            Response<SearchResponseRO> response;

            using (BruParkApiClient client = new BruParkApiClient()) {
                response = client.SearchParkings(request);
            }

            if (response.Failure)
            {
                Debug.WriteLine("ERROR:  " + response.Error);
            }

            SearchResponseRO output = response.Body;

            if (!String.IsNullOrEmpty(output.Error))
            {
                Debug.WriteLine("ERROR:  " + output.Error);
                return;
            }

            NavigationService.Navigate(new ParkingListPage(output.Results));
        }
    }
}
