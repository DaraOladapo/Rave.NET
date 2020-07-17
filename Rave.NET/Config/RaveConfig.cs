using System;
using System.Collections.Generic;
using System.Text;

namespace Rave
{
    public class RaveConfig
    {
        public RaveConfig(bool isLive)
        {
            IsLive = isLive;
        }

        public RaveConfig(string publicKey, string secretKey, bool isLive)
        {
            IsLive = isLive;
            PbfPubKey = publicKey;
            SecretKey = secretKey;
        }

        public RaveConfig(string publicKey, bool isLive)
        {
            IsLive = isLive;
            PbfPubKey = publicKey;
        }

        public RaveConfig(string publicKey, string secretKey)
        {
            IsLive = false;
            PbfPubKey = publicKey;
            SecretKey = secretKey;
        }

        public bool IsLive { get; set; }
        public string PbfPubKey { get; set; }
        public string SecretKey { get; set; }




    }
}