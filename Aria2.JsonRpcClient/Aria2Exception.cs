namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// Represents an exception thrown by the aria2 client.
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
        /// The aria2 error code.
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// The aria2 error message.
        /// </summary>
        public override string Message => base.Message;
    }
}
