using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CleanArchTemplate.Core.Http
{
    public interface IHttpRequestSender
    {
        Task<TResponse> SendPostRequest<TResponse>(string requestUri, object content, Func<HttpResponseMessage, Task<TResponse>> deserializer);
    }
}