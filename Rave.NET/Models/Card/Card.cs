﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rave.NET.Models.Card
{
    public class Card
    {
        public Card(string cardNo,  string expirymonth, string expiryyear, string cvv)
        {
            CardNo = cardNo;
            Expirymonth = expirymonth;
            Expiryyear = expiryyear;
            Cvv = cvv;
        }

        public Card(string cardNo, string expirymonth, string expiryyear, string cvv, string pin)
        {
            CardNo = cardNo;
            Expirymonth = expirymonth;
            Expiryyear = expiryyear;
            Cvv = cvv;
            Pin = pin;
        }

        public string CardNo { get; set; }
        public string Expirymonth { get; set; }
        public string Expiryyear { get; set; }
        public string Cvv { get; set; }
        public string Pin { get; set; }

    }
}
