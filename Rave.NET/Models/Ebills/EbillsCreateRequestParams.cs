using System;
using System.Collections.Generic;
using System.Text;
using Rave.NET.Models.Charge;
using Newtonsoft.Json;

namespace Rave.NET.Models.Ebills
{
    public class EbillsCreateRequestParams
    {
        public EbillsCreateRequestParams( string currency, int numberofunits, string narration, string seckey, string email, int amount, string phonenumber, string txRef, string ip) 
        {
            Country = "NG";
            Currency = currency;
            Numberofunits = numberofunits;
            Narration = narration;
            SECKEY = seckey;
            Amount = amount;
            Phonenumber = phonenumber;
            Email = email;
            TxRef = txRef;
            IP = ip;

        }


        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("numberofunits")]
        public int Numberofunits { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("SECKEY")]
        public string SECKEY { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("phonenumber")]
        public string Phonenumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("txRef")]
        public string TxRef { get; set; }

        [JsonProperty("IP")]
        public string IP { get; set; }

    }
}
