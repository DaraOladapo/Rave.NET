using System;
using RestSharp;
using Newtonsoft.Json;
namespace Rave.NET.Models.Ebills

{
    public class CreateOrder
    {
        public CreateOrder()
        {
        }

        public string doCreateOrder(EbillsCreateRequestParams ebillscreaterequestparams)
        {

            var client = new RestClient("https://api.ravepay.co/flwv3-pug/getpaidx/api/ebills/generateorder/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(ebillscreaterequestparams), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;

        }


    }
}
