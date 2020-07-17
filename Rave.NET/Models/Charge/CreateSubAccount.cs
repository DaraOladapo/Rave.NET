using System; using System.Collections.Generic; using System.Text; using System.Net.Http; using System.Threading.Tasks; using Rave.NET.API; using Rave.NET.Config; using Newtonsoft.Json;
using Rave.NET.Models.Account;

namespace Rave.NET.Models.Charge
{
    public class CreateSubAccount : Base<RaveResponse<Account.ResponseData>, Account.ResponseData>
    {

        public  CreateSubAccount(RaveConfig conf) : base(conf) { }

        public override async Task<RaveResponse<Account.ResponseData>> Charge(IParams Params, bool isRecurring = false)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { seckey = Params.SecretKey, account_bank ="044", country = "NG",  account_number = "0690000031", business_name ="TEST BUSINESS", business_email ="user@example.com", business_contact="0900000000"}), Encoding.UTF8, "application/json");
            Console.WriteLine(content);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.SubAccountCreate) { Content = content };             var result = await RaveRequest.Request(requestMessage);

            Console.WriteLine(result);             return result; 
        }
    }
}
