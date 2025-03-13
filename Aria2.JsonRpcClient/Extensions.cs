using Aria2.JsonRpcClient.Models;

namespace Aria2.JsonRpcClient
{
    internal static class Extensions
    {
        /// <summary>
        /// Ensures that the secret is included in the request parameters.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="secret"></param>
        internal static void EnsureSecret(this JsonRpcRequest request, string secret)
        {
            if (request.Method == "system.multicall")
            {
                foreach (var calls in request.Parameters.Cast<SystemMulticallRequest[]>())
                {
                    foreach (var call in calls)
                    {
                        InsertSecretIfRequired(call.Parameters, secret);
                    }
                }
            }
            else
            {
                InsertSecretIfRequired(request.Parameters, secret);
            }
        }

        private static void InsertSecretIfRequired(JsonRpcParameters jsonRpcParameters, string secret)
        {
            if (jsonRpcParameters.Count == 0 || jsonRpcParameters[0] is not string val || !val.StartsWith("token:"))
            {
                jsonRpcParameters.Insert(0, "token:" + secret);
            }
        }
    }
}
