using System;
using RestSharp;
using Newtonsoft.Json;
namespace Rave.NET.Models.Subscriptions
{
    public class CancelSubscription
    {
        public CancelSubscription()
        {
        }

        public string doCancelSubscription(SubscriptionRequestParams cancelsubscriptionrequestparams)
        {

            var client = new RestClient("https://api.ravepay.co/v2/gpx/subscriptions/"+ cancelsubscriptionrequestparams .Id+ "/cancel?fetch_by_tx="+ cancelsubscriptionrequestparams .fetch_by_tx+ "");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject( new { cancelsubscriptionrequestparams.Seckey }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }
    }
}
