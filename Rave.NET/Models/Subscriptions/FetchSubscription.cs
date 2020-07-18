using System;
using RestSharp;
using Newtonsoft.Json;
namespace Rave.NET.Models.Subscriptions
{
    public class FetchSubscription
    {
        public FetchSubscription()
        {
        }

        public string doFetchSubscription(String seckey , String transactionid)
        {
            var client = new RestClient("https://api.ravepay.co/v2/gpx/subscriptions/query?seckey="+ seckey + "&transaction_id="+ transactionid + "");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }
    }
}
