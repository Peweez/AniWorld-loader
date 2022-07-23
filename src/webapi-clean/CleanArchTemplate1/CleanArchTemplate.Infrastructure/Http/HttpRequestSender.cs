using CleanArchTemplate.Core.Http;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchTemplate.Infrastructure.Http
{
    public class HttpRequestSender : IHttpRequestSender
    {
        public HttpRequestSender(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private readonly IHttpClientFactory _httpClientFactory;

        public async Task<TResponse> SendPostRequest<TResponse>(string requestUri, object content, Func<HttpResponseMessage, Task<TResponse>> deserializer)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync(requestUri, new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, MediaTypeNames.Application.Json));
            httpResponseMessage.EnsureSuccessStatusCode();
            TResponse response = await deserializer.Invoke(httpResponseMessage);
            return response;
        }
    }
}
