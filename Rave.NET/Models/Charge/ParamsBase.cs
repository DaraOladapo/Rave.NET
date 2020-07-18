using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Rave.NET.Models.Charge
{
    public enum AuthTypes { PIN, VBVSECURECODE, AVS_VBVSECURECODE }

    public abstract class ParamsBase : IParams
    {
        protected ParamsBase(string secretKey)
        {
            SecretKey = secretKey;
        }

        protected ParamsBase(string secretKey, string currency)
        {
            SecretKey = secretKey;
            Currency = currency;
        }

        protected ParamsBase(string secretKey, string email, String txref)
        {
            SecretKey = secretKey;
            Email = email;
            TxRef = txref;
        }

        protected ParamsBase(string pbfPubKey, string secretKey, string firstName, string lastName, string email, string currency)
        {
            PbfPubKey = pbfPubKey;
            SecretKey = secretKey;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Currency = currency;
            Country = "NG";
        }

        protected ParamsBase(string pbfPubKey, string secretKey, string firstName, string lastName, string email, string currency, string country)
        {
            PbfPubKey = pbfPubKey;
            SecretKey = secretKey;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Currency = currency;
            Country = country;
        }

        protected static string GetAuthType(AuthTypes authType)
        {
            switch (authType)
            {
                case AuthTypes.PIN:
                    return "PIN";
                case AuthTypes.VBVSECURECODE:
                    return "VBVSECURECODE";
                case AuthTypes.AVS_VBVSECURECODE:
                    return "AVS_VBVSECURECODE";
                default:
                    return "PIN";
            }

        }

        [JsonProperty("PBFPubKey")]
        public string PbfPubKey { get; set; }

        
        [JsonProperty("SecretKey")]
        public string SecretKey { get; set;  }
        

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
        
        
        [JsonProperty("billingzip")]
        public string BillingZip { get; set; }


        [JsonProperty("billingcity")]
        public string BillingCity { get; set; }


        [JsonProperty("billingaddress")]
        public string BillingAddress { get; set; }


        [JsonProperty("billingstate")]
        public string BillingState { get; set; }


        [JsonProperty("billingcountry")]
        public string BillingCountry { get; set; }
    }
}
