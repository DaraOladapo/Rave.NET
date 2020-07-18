using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Rave.NET.API;

namespace Rave.NET.Models.Account
{
    public class ResponseData : Charge.ChargeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("validateInstruction")]
        public string ValidateInstruction { get; set; }


        [JsonProperty("validateInstructions")]

        public Validate ValidateInstructions { get; set; }

        public class Validate
        {
            [JsonProperty("valparams")]
            public string[] Valparams { get; set; }
            [JsonProperty("instruction")]
            public string Instruction { get; set; }
        }
    }
}
