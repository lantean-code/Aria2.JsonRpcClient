using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// An abstract Json RPC request. Inherit from this to add addtional aria2 requests.
    /// </summary>
    public abstract record JsonRpcRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRpcRequest"/> class.
        /// </summary>
        /// <param name="method">The name of the method to be called.</param>
        /// <param name="parameters">The parameters to be passed to the method.</param>
        /// <param name="id">The id of the request.</param>
        protected JsonRpcRequest(string method, JsonRpcParameters parameters, string? id = null)
        {
            Method = method;
            Parameters = parameters;
            Id = id ?? Guid.NewGuid().ToString();
        }

        /// <summary>
        /// The JSON-RPC version - for Aira2, this is always "2.0".
        /// </summary>
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; } = "2.0";

        /// <summary>
        /// The name of the method to be called.
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; }

        /// <summary>
        /// The parameters to be passed to the method.
        /// </summary>
        [JsonPropertyName("params")]
        public JsonRpcParameters Parameters { get; }

        /// <summary>
        /// The id of the request.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; }

        /// <summary>
        /// The type of the return value. This will always be <code>typeof(void)</code>.
        /// </summary>
        [JsonIgnore]
        public virtual Type ReturnType { get; } = typeof(void);
    }

    /// <summary>
    /// An abstract Json RPC request with a return type. Inherit from this to add addtional aria2 requests.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract record JsonRpcRequest<T> : JsonRpcRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRpcRequest{T}"/> class.
        /// </summary>
        /// <param name="method">The name of the method to be called.</param>
        /// <param name="parameters">The parameters to be passed to the method.</param>
        /// <param name="id">The id of the request.</param>
        protected JsonRpcRequest(string method, JsonRpcParameters parameters, string? id = null) : base(method, parameters, id)
        {
        }

        /// <summary>
        /// The type of the return value. This is always a <typeparamref name="T"/>.
        /// </summary>
        [JsonIgnore]
        public override Type ReturnType { get; } = typeof(T);

        /// <summary>
        /// A helper method to cast the response of a <see cref="IAria2Client.SystemMulticall(JsonRpcRequest[])"/> to the correct type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T GetResult(object? value)
        {
            if (value is null)
            {
                throw new ArgumentNullException("value");
            }

            return (T)value;
        }

        /// <summary>
        /// Helper method to determine if the response of a <see cref="IAria2Client.SystemMulticall(JsonRpcRequest[])"/> is an error.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="jsonRpcError"></param>
        /// <returns></returns>
        public static bool IsError(object? value, [NotNullWhen(true)] out JsonRpcError? jsonRpcError)
        {
            if (value is JsonRpcError error)
            {
                jsonRpcError = error;
                return true;
            }

            jsonRpcError = null;
            return false;
        }
    }
}
