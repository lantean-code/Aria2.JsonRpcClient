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
                SizeType.Bytes => "",
                SizeType.Megabytes => "M",
                SizeType.Kilobytes => "K",
                _ => throw new ArgumentOutOfRangeException(nameof(sizeType), sizeType, null),
            };
        }

        private static readonly Dictionary<char, SizeType> _sizeTypeMapping = new()
        {
            { 'B', SizeType.Bytes },
            { 'b', SizeType.Bytes },
            { 'K', SizeType.Kilobytes },
            { 'k', SizeType.Kilobytes },
            { 'M', SizeType.Megabytes },
            { 'm', SizeType.Megabytes },
        };

        private static readonly HashSet<char> _validUnitChars = new()
        {
            { 'B' },
            { 'b' },
            { 'K' },
            { 'k' },
            { 'M' },
            { 'm' },
        };

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

            if (string.IsNullOrEmpty(s))
            {
                result = default;
                return false;
            }

            var unit = s[^1];

            if (char.IsDigit(unit))
            {
                unit = 'B';
                s += unit;
            }

            if (!_validUnitChars.Contains(unit))
            {
                result = default;
                return false;
            }

            if (!double.TryParse(s[..^1], out var sizeValue))
            {
                result = default;
                return false;
            }

            result = new Size
            {
                Value = sizeValue,
                SizeType = _sizeTypeMapping[unit],
            };

            return true;
        }
    }
}
