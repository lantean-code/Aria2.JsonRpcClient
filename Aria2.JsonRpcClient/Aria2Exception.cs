namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// Represents an exception thrown by the Aria2 client.
    /// </summary>
    public class Aria2Exception : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Aria2Exception"/> class.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public Aria2Exception(int code, string? message) : base(message)
        {
            Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Aria2Exception"/> class.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public Aria2Exception(int code, string? message, Exception? innerException) : base(message, innerException)
        {
            Code = code;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public int Code { get; }
    }
}
