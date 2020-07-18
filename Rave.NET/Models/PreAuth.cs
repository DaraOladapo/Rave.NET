using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rave.NET.API;
using Rave.NET.Config;

namespace Rave.NET.Models
{
    public class PreAuth
    {
        public PreAuth(RaveConfig config)
        {
            Config = config;
            PayDataEncrypt = new DataEncryption();
            RaveApiRequest = new RaveRequest<RaveResponse<PreAuthResponseData>, PreAuthResponseData>(config);
            
        }
        private RaveConfig Config { get; }
        private IDataEncryption PayDataEncrypt { get; }
        private IRaveRequest<RaveResponse<PreAuthResponseData>, PreAuthResponseData>RaveApiRequest { get; }


        public async Task<RaveResponse<PreAuthResponseData>>Preauthorize(PreAuthParams preauthParams)
        {
            var encryptedKey = PayDataEncrypt.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PayDataEncrypt.EncryptData(encryptedKey, JsonConvert.SerializeObject(preauthParams));

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = preauthParams.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.PreauthorizeCardCharge) { Content = content };

            return await RaveApiRequest.Request(requestMessage);
        }

        public async Task<RaveResponse<PreAuthResponseData>> Capture(string flwRef)
        {
            var payload = new { flwRef, SECKEY = Config.SecretKey };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.PreauthorizeCapture) { Content = content };

            return await RaveApiRequest.Request(requestMessage);
        }

        public async Task<RaveResponse<PreAuthResponseData>> Void(string flwRef)
        {
            var payload = new { @ref = flwRef, action = "void", SECKEY = Config.SecretKey };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.PreauthorizeReturnOrVoid) { Content = content };

            return await RaveApiRequest.Request(requestMessage);
        }

        public async Task<RaveResponse<PreAuthResponseData>> Refund(string flwRef)
        {
            var payload = new { @ref = flwRef, action = "refund", SECKEY = Config.SecretKey };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.PreauthorizeReturnOrVoid) { Content = content };

            return await RaveApiRequest.Request(requestMessage);
        }

    }

    public class PreAuthResponseData : Charge.ChargeResponse
    {
        [JsonProperty("CreatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("UpdatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("DeletedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DeletedAt { get; set; }
    }

    public class PreAuthParams : Charge.ParamsBase
    {
        public PreAuthParams(string PbfPubKey, string secretKey, string firstName, string lastName, string email, decimal amount, string currency) : base(PbfPubKey, secretKey, firstName, lastName, email, currency)
        {
            Amount = amount;
        }

        public PreAuthParams(string PbfPubKey, string secretKey, string firstName, string lastName, string email, decimal amount, string currency, Card.Card card) : base(PbfPubKey, secretKey, firstName, lastName, email, currency)
        {
            ChargeType = "preauth";
            Amount = amount;
            CardNo = card.CardNo;
            Expirymonth = card.Expirymonth;
            Expiryyear = card.Expiryyear;
            Cvv = card.Cvv;
            Pin = card.Pin;
        }

        [JsonProperty("charge_type")]
        public string ChargeType { get; set; }

        [JsonProperty("cardno")]
        public string CardNo { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }

        [JsonProperty("expirymonth")]
        public string Expirymonth { get; set; }

        [JsonProperty("expiryyear")]
        public string Expiryyear { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}
