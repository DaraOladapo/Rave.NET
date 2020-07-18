using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Rave.NET.API;
using Newtonsoft.Json;

namespace Rave.NET.Models.Subaccount
{
    public class SubAccounts
    {
        public SubAccounts(RaveConfig config)
        {
            Config = config;
            PayDataEncrypt = new DataEncryption();
            RaveApiRequest = new RaveRequest<RaveResponse<ResponseData>, ResponseData>(config);
        }

        private RaveConfig Config { get; }
        private IDataEncryption PayDataEncrypt { get; }
        private IRaveRequest<RaveResponse<ResponseData>, ResponseData> RaveApiRequest { get; }

        public async Task<RaveResponse<ResponseData>> Create(SubAccountParams subaccountParams)
        {
            var encryptedKey = PayDataEncrypt.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PayDataEncrypt.EncryptData(encryptedKey, JsonConvert.SerializeObject(subaccountParams));

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = subaccountParams.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.SubAccountCreate) { Content = content };

            var result = await RaveApiRequest.Request(requestMessage);
            return result;
        }
    }
}
