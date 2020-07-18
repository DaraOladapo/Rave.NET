using System;
using RestSharp;
using Newtonsoft.Json;
namespace Rave.NET.Models.Ebills
{
    public class UpdateOrder
    {
        public UpdateOrder()
        {
        }

        public string doUpdateOrder(EbillsUpdateRequestParams ebillsupdaterequestparams)
        {

            var client = new RestClient("https://api.ravepay.co/flwv3-pug/getpaidx/api/ebills/update/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(ebillsupdaterequestparams), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;

        }

    }
}
