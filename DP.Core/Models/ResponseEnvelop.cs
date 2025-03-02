using System.Net;

namespace DP.Core.Models
{
    public class ResponseEnvelope<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
    }
}
