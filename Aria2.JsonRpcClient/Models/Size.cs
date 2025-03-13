namespace Aria2.JsonRpcClient.Models
{
    /// <summary>
    /// Represents a size value provided as a string (for example, '1M', '100K').
    /// </summary>
    public struct Size
    {
        /// <summary>
        /// The raw size value.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// The type of size value.
        /// </summary>
        public SizeType SizeType { get; set; }

        /// <summary>
        /// Converts the size value to a string.
        /// </summary>
        /// <returns></returns>
        public override readonly string ToString()
        {
            return $"{Value}{GetSize(SizeType)}";
        }

        private static string GetSize(SizeType sizeType)
        {
            return sizeType switch
            {
                SizeType.Megabytes => "M",
                SizeType.Kilobytes => "K",
                _ => throw new ArgumentOutOfRangeException(nameof(sizeType), sizeType, null),
            };
        }
    }
}
