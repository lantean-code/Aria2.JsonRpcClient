using System.Globalization;

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
        /// Initializes a new instance of the <see cref="Size"/> struct. 
        /// </summary>
        public Size()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sizeType"></param>
        public Size(double value, SizeType sizeType)
        {
            Value = value;
            SizeType = sizeType;
        }

        /// <summary>
        /// Converts the size value to a string.
        /// </summary>
        /// <returns></returns>
        public override readonly string ToString()
        {
            return $"{Value.ToString("0.##", CultureInfo.InvariantCulture)}{GetSize(SizeType)}";
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

        /// <summary>
        /// Tries to parse a size value from a string.
        /// </summary>
        /// <param name="s">A string containing a size to convert.</param>
        /// <param name="result"></param>
        /// <returns>True if <paramref name="s"/> was converted successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool TryParse(string s, out Size result)
        {
            s = s.Trim();

            var unit = s[^1];

            if (unit != 'M' && unit != 'K' && unit != 'm' && unit != 'k')
            {
                result = default;
                return false;
            }

            var sizeType = unit switch
            {
                'M' => SizeType.Megabytes,
                'm' => SizeType.Megabytes,
                'K' => SizeType.Kilobytes,
                'k' => SizeType.Kilobytes,
                _ => throw new ArgumentOutOfRangeException(nameof(s), unit, null),
            };

            if (!double.TryParse(s[..^1], out var sizeValue))
            {
                result = default;
                return false;
            }

            result = new Size
            {
                Value = sizeValue,
                SizeType = sizeType,
            };

            return true;
        }
    }
}
