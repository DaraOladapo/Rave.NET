using System;
using RestSharp;
using Newtonsoft.Json;
namespace Rave.NET.Models.Subscriptions
{
    public class ActivateSubscription
    {
        public ActivateSubscription()
        {
        }

        public string doActivateSubscription(SubscriptionRequestParams activatesubscriptionrequestparams)
        {
            var client = new RestClient("https://api.ravepay.co/v2/gpx/subscriptions/"+ activatesubscriptionrequestparams .Id+ "/activate?fetch_by_tx="+activatesubscriptionrequestparams.fetch_by_tx+"");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject( new { activatesubscriptionrequestparams.Seckey }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }
    }
}
