using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Rave.NET.Models.Banks
{
    public class Bank
    {
        public Bank() { }

        public Bank(string bankName, string bankCode)
        {
            BankName = bankName;
            BankCode = bankCode;
        }

        [JsonProperty("bankname")]
        public string BankName { get; set; }

        [JsonProperty("bankcode")]
        public string BankCode { get; set; }

        public override string ToString()
        {
            return $"Bank name: {BankName} \t Bank Code: {BankCode}";
        }
    }
}
