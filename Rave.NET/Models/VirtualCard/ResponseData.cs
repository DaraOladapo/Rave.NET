using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Rave.NET.API;

namespace Rave.NET.Models.VirtualCard
{
    //public class VirtualCardResponse<T> : RaveResponse<T> where T : ResponseData { }

    public class ResponseData : Charge.ChargeResponse
    {
        [JsonProperty("AccountId")]
        public string AccountId { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("card_hash")]
        public string CardHash { get; set; }

        [JsonProperty("cardpan")]
        public string CardPan { get; set; }

        [JsonProperty("maskedpan")]
        public string MaskedPan { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("address_1")]
        public string Address { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("card_type")]
        public string CardType { get; set; }

        [JsonProperty("name_on_card")]
        public string NameonCard { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }
    }
}
