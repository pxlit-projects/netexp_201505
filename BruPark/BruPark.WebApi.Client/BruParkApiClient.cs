using BruPark.Tools.RestClient;
using BruPark.WebApi.Models;
using System;

namespace BruPark.WebApi.Client
{
    public class BruParkApiClient : IDisposable
    {
        private const string HOSTNAME = "brupark.azurewebsites.net";



        public void Dispose()
        {
            // Nothing to do here (yet)
        }

        public Response<SearchResponseRO> SearchParkings(SearchRequestRO request)
        {
            return RestClient.Post<SearchResponseRO>(Url("/parkings/search"), request);
        }

        public Response<FeedbackResponseRO> SubmitFeedback(int parkingId, FeedbackRequestRO request)
        {
            return RestClient.Post<FeedbackResponseRO>(Url("/parkings/{0}/feedback", parkingId), request);
        }

        private static string Url(string path, params object[] args)
        {
            return ("http://" + HOSTNAME + String.Format(path, args));
        }
    }
}
