namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// A collection of parameters for a JSON-RPC request.
    /// </summary>
    public class JsonRpcParameters : List<object?>
    {
        /// <summary>
        /// Adds a value to the collection if it is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public void Add<T>(T value)
        {
            base.Add(value);
        }

        /// <summary>
        /// Converts an array of objects to a <see cref="JsonRpcParameters"/> instance.
        /// </summary>
        /// <param name="values"></param>
        public static implicit operator JsonRpcParameters(object?[] values)
        {
            var parameters = new JsonRpcParameters();
            parameters.AddRange(values);
            return parameters;
        }

        /// <summary>
        /// Converts a string to a <see cref="JsonRpcParameters"/> instance.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator JsonRpcParameters(string value)
        {
            var parameters = new JsonRpcParameters
            {
                value
            };
            return parameters;
        }

        /// <summary>
        /// Converts an integer to a <see cref="JsonRpcParameters"/> instance.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator JsonRpcParameters(int value)
        {
            var parameters = new JsonRpcParameters
            {
                value
            };
            return parameters;
        }

        /// <summary>
        /// Creates an empty <see cref="JsonRpcParameters"/> instance.
        /// </summary>
        public static JsonRpcParameters Empty => [];
    }
}
