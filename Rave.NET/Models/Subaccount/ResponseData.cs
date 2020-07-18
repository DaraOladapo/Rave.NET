using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Rave.NET.Models.Subaccount
{
    public class ResponseData : Charge.ChargeResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("account_bank")]
        public string AccountBank { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("date_created")]
        public string DateCreated { get; set; }

        [JsonProperty("subaccount_id")]
        public string SubaccountId { get; set; }

        [JsonProperty("bank_name")]
        public string BankName { get; set; }
    }
}
