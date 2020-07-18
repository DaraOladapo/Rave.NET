using Newtonsoft.Json;
using Rave.NET.API;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rave.NET.Models.Banks
{
    public class Transfer
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }

    public class TransferToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }
    }


    public class TransferListResponse
    {
        public TransferToken Token { get; set; }
        public List<Transfer> Banks { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public static class TransferService
    {
        private static readonly RaveRequest req = new RaveRequest();

        public static async Task<IEnumerable<Bank>> GetBankList()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, Endpoints.GetDirectBankDebitList);
            return await req.Request<IEnumerable<Bank>>(requestMessage);
        }

        public static async Task<RaveResponse<TransferListResponse>> GetBankTransferList(string country, RaveConfig config)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{Endpoints.GetBankTransferList}{country}?public_key={config.PbfPubKey}");
            return await req.Request<RaveResponse<TransferListResponse>>(requestMessage);
        }
    }
}
