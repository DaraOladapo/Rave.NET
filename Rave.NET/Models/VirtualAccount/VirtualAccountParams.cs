using System;
using System.Collections.Generic;
using System.Text;
using Rave.NET.Models.Charge;
using Newtonsoft.Json;

namespace Rave.NET.Models.VirtualAccount
{
    public class VirtualAccountParams 
    {
        public VirtualAccountParams (string narration, string secretKey, string Email, string txRef, string amount) 
        {
            Narration = narration;
            email = Email;
            seckey = secretKey;
            TxRef = txRef;
            Amount = amount;
        }

        public VirtualAccountParams( string narration, string secretKey, string Email, string txRef)
        {
            Is_permanent = true;
            Narration = narration;
            email = Email;
            seckey = secretKey;
            TxRef = txRef;
            
        }

        public VirtualAccountParams(int frequency, int duration, string narration, string secretKey, string Email, string txRef, string amount)
        {
            Frequency = frequency;
            Duration = duration;
            Narration = narration;
            email = Email;
            seckey = secretKey;
            TxRef = txRef;
            Amount = amount;
        }

        [JsonProperty("is_permanent")]
        public bool Is_permanent { get; set; }

        [JsonProperty("frequency")]
        public int Frequency { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("seckey")]
        public string seckey { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("txRef")]
        public string TxRef { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

    }
}
