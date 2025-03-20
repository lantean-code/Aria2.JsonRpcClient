using System.Net;

#if NET48
using System.Net.Http;
#endif

using System.Text;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;
using Microsoft.Extensions.Options;

namespace Aria2.JsonRpcClient.Test
{
    public class HttpGetRequestHandlerTests
    {
        [Fact]
        public async Task GIVEN_ValidForcePauseRequest_WHEN_SendingRequestGeneric_THEN_ShouldCallHttpClientWithCorrectUrlAndReturnDeserializedResponse()
        {
            var expectedResult = "dummyResult";
            var responseJson = $"{{\"jsonrpc\":\"2.0\",\"id\":\"testId\",\"result\":\"{expectedResult}\"}}";
            var fakeHandler = new FakeHttpMessageHandler(responseJson);
            var httpClient = new HttpClient(fakeHandler);
            var options = CreateOptions("localhost", 6800, "secret123");
            var handler = new HttpGetRequestHandler(httpClient, options);
            var request = new ForcePause("gid123", "testId");

            var response = await handler.SendRequest<string>(request);

            response.Should().NotBeNull();
            response.Result.Should().Be(expectedResult);

            var jsonParams = "[\"token:secret123\",\"gid123\"]";
            var base64Params = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonParams));
            var encodedParams = WebUtility.UrlEncode(base64Params);
            var expectedQuery = $"?method={request.Method}&id={request.Id}&params={encodedParams}";
            var expectedUri = new Uri(httpClient.BaseAddress!, expectedQuery);
            fakeHandler.RequestedUri.Should().BeEquivalentTo(expectedUri);
        }

        [Fact]
        public async Task GIVEN_ValidForcePauseRequest_WHEN_SendingRequestNonGeneric_THEN_ShouldCallHttpClientWithCorrectUrlAndReturnDeserializedResponse()
        {
            var responseJson = "{\"jsonrpc\":\"2.0\",\"id\":\"testId\",\"result\":null}";
            var fakeHandler = new FakeHttpMessageHandler(responseJson);
            var httpClient = new HttpClient(fakeHandler);
            var options = CreateOptions("localhost", 6800, "secret123");
            var handler = new HttpGetRequestHandler(httpClient, options);
            var request = new ForcePause("gid123", "testId");

            var response = await handler.SendRequest(request);

            response.Should().NotBeNull();
            response.Id.Should().Be("testId");

            var jsonParams = "[\"token:secret123\",\"gid123\"]";
            var base64Params = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonParams));
            var encodedParams = WebUtility.UrlEncode(base64Params);
            var expectedQuery = $"?method={request.Method}&id={request.Id}&params={encodedParams}";
            var expectedUri = new Uri(httpClient.BaseAddress!, expectedQuery);
            fakeHandler.RequestedUri.Should().BeEquivalentTo(expectedUri);
        }

        // A fake HttpMessageHandler that returns a predetermined JSON response.
        private class FakeHttpMessageHandler : HttpMessageHandler
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

        private IOptions<Aria2ClientOptions> CreateOptions(string host, int port, string secret)
        {
            return Options.Create(new Aria2ClientOptions
            {
                Host = host,
                Port = port,
                Secret = secret
            });
        }
    }
}
