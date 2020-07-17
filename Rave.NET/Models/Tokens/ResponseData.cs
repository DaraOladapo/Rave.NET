using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Rave.NET.Models.Charge;

namespace Rave.NET.Models.Tokens{
    public class ResponseDataTokens: ChargeResponse
    {
        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("cycle")]
        public string Cycle { get; set; }

        [JsonProperty("appfee")]
        public string AppFee { get; set; }

        [JsonProperty("merchantfee")]
        public string MerchantFee { get; set; }

        [JsonProperty("merchantbearsfee")]
        public string Merchantbearsfee { get; set; }

        [JsonProperty("authModelUsed")]
        public string AuthModelUsed { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("IP")]
        public string Ip { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("vbvrespmessage")]
        public string Vbvrespmessage { get; set; }

        [JsonProperty("vbvrespcode")]
        public string Vbvrespcode { get; set; }


        [JsonProperty("acctvalrespmsg")]
        public string AcctValRespMsg { get; set; }

        [JsonProperty("acctvalrespcode")]
        public string AcctvalRespcode { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("is_error")]
        public bool IsError { get; set; }

        [JsonProperty("chargeToken")]
        public Token CardChargeToken { get; set; }
    }
}
