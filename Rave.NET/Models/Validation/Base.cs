using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rave.NET.API;
using Newtonsoft.Json;
using System.Net.Http;

namespace Rave.NET.Models.Validation
{
    public abstract class Base<T> : IChargeValidate<T> where T: ValidateChargeDatabase
    {
        protected Base(RaveConfig config)
        {
            Config = config;
            RaveApiRequest = new RaveRequest<RaveResponse<T>, T>(config);
        }
        protected internal RaveConfig Config { get; }
        internal IRaveRequest<RaveResponse<T>,T> RaveApiRequest { get; }

        public virtual async Task<RaveResponse<T>> ValidateCharge(IValidateParams validateChargeParams)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(validateChargeParams), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.ValidateCharge) { Content = requestBody };
            var result = await RaveApiRequest.Request(requestMessage);
            return result;
        }
    }

    public interface IValidateResponse { }

    public interface IValidateParams
    {
        string PfbPubKey { get; set; }
    }

    public interface IChargeValidate<T> where T: ValidateChargeDatabase
    {
        Task<RaveResponse<T>> ValidateCharge(IValidateParams validateParams);
    }

    public class ValidateChargeResponse : ValidateChargeDatabase { }



    public abstract class ValidateChargeDatabase : IValidateResponse { }

    public abstract class ValidateParams : IValidateParams
    {
        protected ValidateParams(string pfbPubKey)
        {
            PfbPubKey = pfbPubKey;
        }

        [JsonProperty("PBFPubKey")]
        public string PfbPubKey { get; set; }
    }
}
