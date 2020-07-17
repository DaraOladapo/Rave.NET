using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Rave.NET.API;
using Newtonsoft.Json;


namespace Rave.NET.Models.Validation
{
    class ValidateAccountCharge : Base<ValidateAccountChargeResponse>
    {
        public ValidateAccountCharge(RaveConfig config) : base(config)
        {

        }

        public override async Task<RaveResponse<ValidateAccountChargeResponse>> ValidateCharge(IValidateParams validateChargeParams)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(validateChargeParams), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.ValidateCharge) { Content = requestBody };
            var result = await RaveApiRequest.Request(requestMessage);
            return result;
        }
    }

    public class ValidateAccountChargeParams : ValidateParams
    {
        public ValidateAccountChargeParams(string pbfPubKey, string transactionReference, string otp) : base(pbfPubKey)
        {
            TransactionReference = transactionReference;
            Otp = otp;
        }

        [JsonProperty("transaction_reference")]
        public string TransactionReference { get; set; }

        [JsonProperty("otp")]
        public string Otp { get; set; }
    }


    public class ValidateAccountChargeResponse : ValidateChargeDatabase
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("txRef")]
        public string TxRef { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("orderRef")]
        public string OrderRef { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("charge_type")]
        public string ChargeType { get; set; }

        [JsonProperty("charged_amount")]
        public decimal ChargedAmount { get; set; }

        [JsonProperty("chargeResponseCode")]
        public string ChargeResponseCode { get; set; }

        [JsonProperty("chargeResponseMessage")]
        public string ChargeResponseMessage { get; set; }

        [JsonProperty("flwRef")]
        public string FlwRef { get; set; }

        [JsonProperty("customerId")]
        public long CustomerId { get; set; }


        [JsonProperty("fraud_status")]
        public string FraudStatus { get; set; }

        [JsonProperty("authurl")]
        public string Authurl { get; set; }
    }
}
