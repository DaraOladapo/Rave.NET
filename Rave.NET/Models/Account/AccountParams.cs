using System;
using System.Collections.Generic;
using System.Text;
using Rave.NET.Models.Banks;
using Newtonsoft.Json;

namespace Rave.NET.Models.Account
{
    public class AccountParams : Charge.ParamsBase
    {
        public AccountParams(string PbfPubKey, string secretKey, string firstName, string lastName, string email, string accountNumber, decimal amount, string bank, string currency, string txRef) : base(PbfPubKey, secretKey, firstName, lastName, email, currency)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Email = email;
            Accountbank = bank;
            PaymentType = "account";
            TxRef = txRef;
        }

        [JsonProperty("accountnumber")]
        public string AccountNumber { get; set; }


        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("accountbank")]
        public string Accountbank { get; set; }

        [JsonProperty("passcode")]
        public string passCode { get; set; }

        [JsonProperty("otp")]
        public string Otp { get; set; }
    }
}
