using System;

namespace Rave.NET.Models.MobileMoney
{
    public class MobileMoney
    {
        public MobileMoney(string phonenumber, string network, string paymentType)
        {
            Phonenumber = phonenumber;
            Network = network;
            PaymentType = paymentType;

        }

        public string Phonenumber { get; set; }
        public string Network { get; set; }
        public string PaymentType { get; set; }
    }
}
