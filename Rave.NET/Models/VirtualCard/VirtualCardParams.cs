using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Rave.NET.Models.Charge;

namespace Rave.NET.Models.VirtualCard
{
    public class VirtualCardParams 
    {
        public VirtualCardParams(string secret_key, string billingName, string currency, string amount, string billingAddress, string billingCity, string billingState, string billingPostalCode, string billingCountry, string callback_url)
        {
            BillingName = billingName;
            BillingAddress = billingAddress;
            BillingCity = billingCity;
            BillingState = billingState;
            BillingPostalCode = billingPostalCode;
            BillingCountry = billingCountry;
            Amount = amount;
            Currency = currency;
            Secret_key = secret_key;
            Callback_url = callback_url;
        }

        public VirtualCardParams(string secret_key, string page) 
        {
            Pages = page;
            Secret_key = secret_key;
        }

        public VirtualCardParams(string secret_key, int id)
        {
            Id = id;
            Secret_key = secret_key;
        }

        public VirtualCardParams(string secret_key, string card_id, string amount)
        {
            Card_id = card_id;
            Amount = amount;
            Secret_key = secret_key;
        }


        public VirtualCardParams(string secret_key, string id, string amount, string debit_currency)
        {
            ID = id;
            Secret_key = secret_key;
            Amount = amount;
            Debit_currency = debit_currency;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("page")]
        public string Pages { get; set;  }

        [JsonProperty("billing_name")]
        public string BillingName { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("billing_address")]
        public string BillingAddress { get; set; }

        [JsonProperty("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_state")]
        public string BillingState { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("billing_postal_code")]
        public string BillingPostalCode { get; set; }

        [JsonProperty("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("secret_key")]
        public string Secret_key { get; set; }

        [JsonProperty("callback_url")]
        public string Callback_url { get; set; }

        [JsonProperty("debit_currency")]
        public string Debit_currency { get; set; }

        [JsonProperty("card_id")]
        public string Card_id { get; set; }
    }
}
