using System.Net;
using System.Text;
using Microsoft.Extensions.Options;

namespace Aria2.JsonRpcClient.Services
{
    /// <summary>
    /// An implementation of <see cref="IRequestHandler"/> that sends JSON‑RPC requests to aria2 using HTTP GET.
    /// The URL is built according to the aria2 specification:
    /// /jsonrpc?method=METHOD_NAME&amp;id=ID&amp;params=BASE64_ENCODED_PARAMS
    /// </summary>
    internal class HttpGetRequestHandler : IRequestHandler
    {
        private readonly HttpClient _httpClient;
        private readonly string _secret;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpGetRequestHandler"/> class.
        /// </summary>
        /// <param name="httpClient">
        /// An instance of <see cref="HttpClient"/> which should have its BaseAddress property set to the aria2 JSON‑RPC endpoint URL.
        /// </param>
        /// <param name="options">The aria2 options.</param>
        public HttpGetRequestHandler(HttpClient httpClient, IOptions<Aria2ClientOptions> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri($"http://{options.Value.Host}:{options.Value.Port}/jsonrpc");
            _secret = options.Value.Secret;
        }

        /// <inheritdoc />
        public async Task<JsonRpcResponse<TResponse>> SendRequest<TResponse>(JsonRpcRequest request)
        {
            var responseContent = await SendHttpRequest(request);
            return Serializer.Deserialize<JsonRpcResponse<TResponse>>(responseContent);
        }

        /// <inheritdoc />
        public async Task<JsonRpcResponse> SendRequest(JsonRpcRequest request)
        {
            var responseContent = await SendHttpRequest(request);
            return Serializer.Deserialize<JsonRpcResponse>(responseContent);
        }

        /// <summary>
        /// Builds the URL according to the aria2 HTTP GET JSON‑RPC specification and sends the request.
        /// The query string is built as:
        /// /jsonrpc?method=METHOD_NAME&amp;id=ID&amp;params=BASE64_ENCODED_PARAMS
        /// Where the "params" value is a Base64-encoded JSON array (after UTF‑8 encoding) that is then percent‑encoded.
        /// </summary>
        /// <param name="request">The JSON-RPC request to be sent.</param>
        /// <returns>The raw JSON response as a string.</returns>
        private async Task<string> SendHttpRequest(JsonRpcRequest request)
        {
            request.EnsureSecret(_secret);

            // Serialize the 'params' value to JSON.
            var jsonParams = Serializer.Serialize(request.Parameters);

            // Convert the JSON string to UTF-8 bytes and then Base64-encode the result.
            var base64Params = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonParams));

            // Percent-encode the Base64 string.
            var encodedParams = WebUtility.UrlEncode(base64Params);

            // Build the query string per spec: ?method=METHOD_NAME&id=ID&params=BASE64_ENCODED_PARAMS
            var url = $"?method={request.Method}&id={request.Id}&params={encodedParams}";

            var httpResponse = await _httpClient.GetAsync(url);
            return await httpResponse.Content.ReadAsStringAsync();
        }
    }
}
