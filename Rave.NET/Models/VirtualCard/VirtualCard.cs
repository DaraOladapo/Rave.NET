using System;
using RestSharp;
using Newtonsoft.Json;

namespace Rave.NET.Models.VirtualCard
{
    public class VirtualCard
    {
        public VirtualCard()
        {
          
        }

        public string doCreateVirtualCard(VirtualCardParams virtualcardparams)
        {
            var client = new RestClient("https://api.ravepay.co/v2/services/virtualcards/new");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(virtualcardparams), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }

        public string doListVirtualCard(VirtualCardParams virtualcardparams)
        {
            var client = new RestClient("https://api.ravepay.co/v2/services/virtualcards/search");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { virtualcardparams.Secret_key, virtualcardparams.Pages }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }

        public string doGetVirtualCard(VirtualCardParams virtualcardparams)
        {
            var client = new RestClient("https://api.ravepay.co/v2/services/virtualcards/get");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { virtualcardparams.Secret_key, virtualcardparams.Id }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }

        public string doTerminateVirtualCard(VirtualCardParams virtualcardparams)
        {
            var client = new RestClient("https://api.ravepay.co/v2/services/virtualcards/"+ virtualcardparams.Id+ "/terminate");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { virtualcardparams.Secret_key }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }

        public string doFundVirtualCard(VirtualCardParams virtualcardparams)
        {
            var client = new RestClient("https://api.ravepay.co/v2/services/virtualcards/fund");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { virtualcardparams.Secret_key, virtualcardparams.Id, virtualcardparams.Amount, virtualcardparams.Debit_currency}), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }

        public string doFreezeVirtualCardTransaction(string card_id, string seckey)
        {
            var client = new RestClient("https://api.ravepay.co/v2/services/virtualcards/"+ card_id + "/status/block");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { seckey }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }

        public string doUnFreezeVirtualCardTransaction(string card_id, string seckey)
        {
            var client = new RestClient("https://api.ravepay.co/v2/services/virtualcards/" + card_id + "/status/unblock");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { seckey }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }

        public string doWithdrawVirtualCard(VirtualCardParams virtualcardparams)
        {
            var client = new RestClient("https://api.ravepay.co/v2/services/virtualcards/withdraw");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { virtualcardparams.Card_id, virtualcardparams.Secret_key, virtualcardparams.Amount }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response.Content;
        }
    }
}
