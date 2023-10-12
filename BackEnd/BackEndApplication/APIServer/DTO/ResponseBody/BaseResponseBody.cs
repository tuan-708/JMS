using System.Net;

namespace APIServer.DTO.ResponseBody
{
    public class BaseResponseBody<T>
    {
        public HttpStatusCode statusCode { get; set; }
        public T? data { get; set; }
        public string? message { get; set; }
    }
}
