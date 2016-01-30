using System;
using System.Net;

namespace BruPark.Tools.RestClient
{
    public class Response<T>
    {
        public T Body { get; set; }

        public string Error { get; set; }

        public bool Failure
        {
            get
            {
                return !String.IsNullOrEmpty(Error);
            }
        }

        public HttpStatusCode StatusCode { get; set; }
        


        public Response(HttpStatusCode statusCode, T body = default(T))
        {
            Body = body;
            StatusCode = statusCode;
        }
    }
}
