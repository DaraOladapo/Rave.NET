using System;
using RestSharp;
using Newtonsoft.Json;
namespace Rave.NET.Models.Subscriptions
{
    public class ListSubscriptions
    {
        public ListSubscriptions()
        {
        }

        public string doListSubscriptions(String seckey)
        {
            var client = new RestClient("https://api.ravepay.co/v2/gpx/subscriptions/query?seckey="+ seckey + "");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
