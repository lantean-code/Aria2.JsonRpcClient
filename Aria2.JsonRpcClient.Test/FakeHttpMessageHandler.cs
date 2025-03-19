using System.Net;
using System.Text;

namespace Aria2.JsonRpcClient.Test
{
    // A simple fake HttpMessageHandler to capture the request URI and return a predetermined response.
    internal class FakeHttpMessageHandler : HttpMessageHandler
    {
        public Uri? RequestedUri { get; private set; }
        private readonly string _responseContent;

        public FakeHttpMessageHandler(string responseContent)
        {
            _responseContent = responseContent;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestedUri = request.RequestUri;
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_responseContent, Encoding.UTF8, "application/json")
            };
            return Task.FromResult(response);
        }
    }
}
