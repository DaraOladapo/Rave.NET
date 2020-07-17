using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Rave.NET.API;
using Newtonsoft.Json;

namespace Rave.NET.Models.Charge
{
    public class ChargeCard : Base<RaveResponse<Card.ResponseData>, Card.ResponseData>
    {
        public ChargeCard(RaveConfig conf) : base(conf) { }

        public override async Task<RaveResponse<Card.ResponseData>> Charge(IParams Params, bool isRecurring = false)
        {
            var encryptedKey = PayDataEncrypt.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PayDataEncrypt.EncryptData(encryptedKey, JsonConvert.SerializeObject(Params));

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = Params.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.CardCharge) { Content = content };
            var result = await RaveRequest.Request(requestMessage);

            return result;
        }

    }
}
