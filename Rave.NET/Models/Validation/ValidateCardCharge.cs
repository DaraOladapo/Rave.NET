using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Rave.NET.API;
using Newtonsoft.Json;

namespace Rave.NET.Models.Validation
{
    public class ValidateCardCharge : Base<ValidateCardChargeResponse>
    {
        public ValidateCardCharge(RaveConfig config) : base(config) { }

        public override async Task<RaveResponse<ValidateCardChargeResponse>> ValidateCharge(IValidateParams validateChargeParams)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(validateChargeParams), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.ValidateCharge) { Content = requestBody };
            var result = await RaveApiRequest.Request(requestMessage);
            return result;
        }
    }

    public class ValidateCardParams : ValidateParams
    {
        public ValidateCardParams(string pfbPubKey, string transactionReference, string otp) : base(pfbPubKey)
        {
            TransactionReference = transactionReference;
            Otp = otp;
        }
        [JsonProperty("transaction_reference")]
        public string TransactionReference { get; set; }
        [JsonProperty("otp")]
        public string Otp { get; set; }
    }

    public class ValidateCardChargeResponse : ValidateChargeDatabase
    {
        [JsonProperty("tx")]
        public CardValidationTXData TX { get; set; }
        [JsonProperty("data")]
        public CardValidationData Data { get; set; }

        public class CardValidationData
        {
            [JsonProperty("responsecode")]
            public string Responsecode { get; set; }

            [JsonProperty("responsemessage")]
            public string Responsemessage { get; set; }
        }

        public class CardValidationTXData : Charge.ChargeResponse
        {
            //[JsonProperty("chargeToken")]
            //public RaveChargeToken CardChargeToken { get; set; }
        }

    }
}
