using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Rave.NET.API
{

    public class RaveResponse<T> where T : class
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public virtual T Data { get; set; }

        [OnError]
        internal void OnError(StreamingContext streamingContext, ErrorContext error)
        {
            if (error.Error is JsonSerializationException) 
            {
                Data = default(T);
                error.Handled = true;
                return;
            }
            #if DEBUG
            error.Handled = false;
            #else
            error.Handled = true;
            #endif
        }
    }
}
