using System;
using System.Collections.Generic;
using System.Text;
using Rave.NET.Models.Charge;
using Newtonsoft.Json;

namespace Rave.NET.Models.Subaccount
{
    public class SubAccountParams : ParamsBase
    {
        public SubAccountParams(string secretKey, string accountBank, string accountNumber, string businessName, string businessEmail, string businessContact, string businessMobile) : base(secretKey)
        {
            AccountBank = accountBank;
            AccountNumber = accountNumber;
            BusinessName = businessName;
            BusinessEmail = businessEmail;
            BusinessContact = businessContact;
            BusinessMobile = businessMobile;
            seckey = base.SecretKey;
        }

        [JsonProperty("account_bank")]
        public string AccountBank { get; set; }

        [JsonProperty("seckey")]
        public string seckey { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("business_email")]
        public string  BusinessEmail { get; set; }

        [JsonProperty("business_contact")]
        public string BusinessContact { get; set; }

        [JsonProperty("business_mobile")]
        public string BusinessMobile { get; set; }
    }
}
