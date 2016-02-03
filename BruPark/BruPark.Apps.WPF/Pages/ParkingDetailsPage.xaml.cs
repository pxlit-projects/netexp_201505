using BruPark.Apps.WPF.Models;
using BruPark.Tools.RestClient;
using BruPark.WebApi.Client;
using BruPark.WebApi.Models;
using System;
using System.Diagnostics;
using System.Windows;
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

        private void HandleFeedback(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBoxUtils.AskYesNoCancel("Were you able to park here?", "Submit feedback");
            Debug.WriteLine("answer = " + answer);

            bool feedback = default(bool);

            switch (answer)
            {
                case MessageBoxResult.Cancel:
                    // Nothing to do, return immediately.
                    return;

                case MessageBoxResult.No:
                    feedback = false;
                    break;

                case MessageBoxResult.Yes:
                    feedback = true;
                    break;
            }

            Func<Response<FeedbackResponseRO>> producer = () =>
            {
                using (BruParkApiClient client = new BruParkApiClient())
                {
                    int parkingId = model.Id;

                    FeedbackRequestRO request = new FeedbackRequestRO();
                    request.Feedback = feedback;

                    return client.SubmitFeedback(parkingId, request);
                }
            };

            Action<Response<FeedbackResponseRO>> consumer = (response) =>
            {
                overlay.Visibility = Visibility.Hidden;

                if (response.Failure)
                {
                    Debug.WriteLine("ERROR:  " + response.Error);
                    MessageBoxUtils.ShowError(response.Error);
                    return;
                }

                FeedbackResponseRO output = response.Body;

                if (!String.IsNullOrEmpty(output.Error))
                {
                    Debug.WriteLine("ERROR:  " + output.Error);
                    MessageBoxUtils.ShowError(output.Error);
                    return;
                }

                // Update the success rate
                model.SuccessRate = output.SuccessRate;
            };

            overlay.Visibility = Visibility.Visible;

            BackgroundWorkerUtils.Start(producer, consumer);
        }
    }
}
