using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Rave.NET.Models.Card
{
    public class ResponseData : Charge.ChargeResponse
    {
        [JsonProperty("suggested_auth")]
        public string SuggestedAuth { get; set; }

        [JsonProperty("authModelUsed")]
        public string AuthModelUsed { get; set; }
    }
}
