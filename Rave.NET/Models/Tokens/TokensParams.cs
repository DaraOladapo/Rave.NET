using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Rave.NET.Models.Charge;

namespace Rave.NET.Models.Tokens
{
    public class TokensParams : IParams
    {
        public TokensParams(string secretKey, string firstName, string lastName, string email, string txRef, decimal amount, string currency, string country)
        {
            SecretKey = secretKey;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            TxRef = txRef;
            Amount = amount;
            Country = country;
            Currency = currency;
        }

        
        [JsonProperty("SECKEY")]
        public string SecretKey { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("PBFPubKey")]
        public string PbfPubKey { get; set; }
        
        [JsonProperty("currency")]
        public string Currency { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        
        [JsonProperty("txRef")]
        public string TxRef { get; set; }
        
        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phonenumber")]
        public string PhoneNumber { get; set; }
       
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("IP")]
        public string Ip { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }
    }
}
