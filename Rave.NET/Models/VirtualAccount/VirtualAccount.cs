using System;
using Newtonsoft.Json;
using RestSharp;

namespace Rave.NET.Models.VirtualAccount
{
    public class VirtualAccount
    {
        public VirtualAccount()
        {   
        }

        public String CreateStaticVirtualAccount(VirtualAccountParams virtualaccountparams)
        {
            virtualaccountparams.Is_permanent.Equals(true);

            var client = new RestClient("https://api.ravepay.co/v2/banktransfers/accountnumbers");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject( new { virtualaccountparams.email, virtualaccountparams.Is_permanent, virtualaccountparams.seckey, virtualaccountparams.TxRef, virtualaccountparams.Narration }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.Content;
        }

        public String CreateTransactionVirtualAccount(VirtualAccountParams virtualaccountparams)
        {

            var client = new RestClient("https://api.ravepay.co/v2/banktransfers/accountnumbers");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { virtualaccountparams.seckey, virtualaccountparams.Amount, virtualaccountparams.Narration, virtualaccountparams.email, virtualaccountparams .TxRef}), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.Content;
        }

        public String CreateDurationStaticVirtualAccount(VirtualAccountParams virtualaccountparams)
        {

            var client = new RestClient("https://api.ravepay.co/v2/banktransfers/accountnumbers");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { virtualaccountparams.email, virtualaccountparams.Frequency, virtualaccountparams.Narration, virtualaccountparams .Duration, virtualaccountparams .seckey, virtualaccountparams .TxRef}), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.Content;
        }
    }
}
