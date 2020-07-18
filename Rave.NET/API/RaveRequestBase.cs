using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Rave.NET.API
{
    internal abstract class RaveRequestBase<T1, T2> : IRaveRequest<T1, T2> where T1 : RaveResponse<T2>, new() where T2 : class
    {
        protected RaveRequestBase()
        {
            Config = new RaveConfig(false);
            HttpClient = new HttpClient
            {
                BaseAddress = Config.IsLive
                    ? new Uri(Rave.NET.Config.Const.LiveUrl)
                    : new Uri(Rave.NET.Config.Const.SanboxUrl)
            };
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected RaveRequestBase(RaveConfig config)
        {
            Config = config;
            HttpClient = new HttpClient()
            {
                BaseAddress = Config.IsLive
                    ? new Uri(Rave.NET.Config.Const.LiveUrl)
                    : new Uri(Rave.NET.Config.Const.SanboxUrl)
            };
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        protected HttpClient HttpClient { get; }
        protected RaveConfig Config { get; set; }

        public virtual async Task<T1> Request(HttpRequestMessage requestBody)
        {
            var httpResponse = await HttpClient.SendAsync(requestBody);
            T1 response;
            if (httpResponse.IsSuccessStatusCode)
            {
                response =
                    JsonConvert.DeserializeObject<T1>(await httpResponse.Content.ReadAsStringAsync());
            }
            else
            {
                response = await ExamineFailedRespone(httpResponse);
            }
            // Todo: If request fails find out the type of failure
            return response;
        }
        public async Task<T0> Request<T0>(HttpRequestMessage requestBody)
        {
            var httpResponse = await HttpClient.SendAsync(requestBody);
            var response = JsonConvert.DeserializeObject<T0>(await httpResponse.Content.ReadAsStringAsync());
            return response;
        }

        private static async Task<T1> ExamineFailedRespone(HttpResponseMessage httpResponse)
        {
            return JsonConvert.DeserializeObject<T1>(await httpResponse.Content.ReadAsStringAsync()); // Todo: This is a placeholder
        }
    }
}

