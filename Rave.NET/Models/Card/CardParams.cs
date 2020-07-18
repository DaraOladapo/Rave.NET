using System;
using System.Collections.Generic;
using System.Text;
using Rave.NET.Models.Charge;
using Newtonsoft.Json;

namespace Rave.NET.Models.Card
{
    public class CardParams : ParamsBase
    {
        public CardParams(string PbfPubKey, string secretKey, string firstName, string lastName, string email, decimal amount, string currency) : base(PbfPubKey, secretKey, firstName, lastName, email, currency)
        {
            Amount = amount;
        }

        public CardParams(string PbfPubKey, string secretKey, string firstName, string lastName, string email, decimal amount, string currency, Card card) : base(PbfPubKey, secretKey, firstName, lastName, email, currency)
        {
            Amount = amount;
            CardNo = card.CardNo;
            Expirymonth = card.Expirymonth;
            Expiryyear = card.Expiryyear;
            Cvv = card.Cvv;
            Pin = card.Pin;
        }
        
        public CardParams(string PbfPubKey, string secretKey, string firstName, string lastName, string email, decimal amount, string currency, Card card, string billingzip, string billingcity, string billingaddress, string billingstate, string billingcountry) : base(PbfPubKey, secretKey, firstName, lastName, email, currency)
        {
            Amount = amount;
            CardNo = card.CardNo;
            Expirymonth = card.Expirymonth;
            Expiryyear = card.Expiryyear;
            Cvv = card.Cvv;
            Pin = card.Pin;
            BillingZip = billingzip;
            BillingCity = billingcity;
            BillingAddress = billingaddress;
            BillingState = billingstate;
            BillingCountry = billingcountry;


        }

        [JsonProperty("cardno")]
        public string CardNo { get; set; }
        

        [JsonProperty("cvv")]
        public string Cvv { get; set; }
        

        [JsonProperty("expirymonth")]
        public string Expirymonth { get; set; }
        

        [JsonProperty("expiryyear")]
        public string Expiryyear { get; set; }


        [JsonProperty("pin")]
        public string Pin { get; set; }


        [JsonProperty("suggested_auth")]
        public string SuggestedAuth { get; set; }


        [JsonProperty("IP")]
        public string Ip { get; set; }


        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }


        [JsonProperty("charge_type")]
        public string ChargeType { get; set; }


        [JsonProperty("otp")]
        public string Otp { get; set; }
    }
}
