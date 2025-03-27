using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class SizeTests
    {
        [Fact]
        public void GIVEN_SizeWithMegabytes_WHEN_CallingToString_THEN_ReturnsFormattedString()
        {
            var size = new Size(1.234, SizeType.Megabytes);

            var result = size.ToString();

            result.Should().Be("1.23M");
        }

        [Fact]
        public void GIVEN_SizeWithKilobytes_WHEN_CallingToString_THEN_ReturnsFormattedString()
        {
            var size = new Size(1000, SizeType.Kilobytes);

            var result = size.ToString();

            result.Should().Be("1000K");
        }

        [Fact]
        public void GIVEN_SizeWithInvalidSizeType_WHEN_CallingToString_THEN_ThrowsArgumentOutOfRangeException()
        {
            var invalidSizeType = (SizeType)99;
            var size = new Size(5, invalidSizeType);

            Action act = () => size.ToString();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void GIVEN_SizeInstance_WHEN_SettingProperties_THEN_GettersReturnSameValues()
        {
            var size = new Size();
            size.Value = 123.45;
            size.SizeType = SizeType.Megabytes;

            size.Value.Should().Be(123.45);
            size.SizeType.Should().Be(SizeType.Megabytes);
        }

        [Fact]
        public void GIVEN_SizeInstance_WHEN_PropertiesChanged_THEN_CallingToStringReflectsNewValues()
        {
            var size = new Size();
            size.Value = 200;
            size.SizeType = SizeType.Kilobytes;
            size.ToString().Should().Be("200K");

            size.Value = 3.14159;
            size.SizeType = SizeType.Megabytes;
            size.ToString().Should().Be("3.14M");
        }

        [Theory]
        [InlineData("10", SizeType.Bytes, 10)]
        [InlineData("20B", SizeType.Bytes, 20)]
        [InlineData("30b", SizeType.Bytes, 30)]
        [InlineData("40K", SizeType.Kilobytes, 40)]
        [InlineData("50k", SizeType.Kilobytes, 50)]
        [InlineData("60M", SizeType.Megabytes, 60)]
        [InlineData("70m", SizeType.Megabytes, 70)]
        [InlineData("71.4m", SizeType.Megabytes, 71.4)]
        public void GIVEN_InputString_WHEN_ParsingValue_THEN_ShouldParseAsSizeTypeWithCorrectValue(string inputValue, SizeType expectedSizeType, double expectedValue)
        {
            var result = Size.TryParse(inputValue, out var size);

            result.Should().BeTrue();
            size.SizeType.Should().Be(expectedSizeType);
            size.Value.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("1G")]
        [InlineData("abcM")]
        [InlineData("")]
        public void GIVEN_InputString_WHEN_ParsingValue_THEN_ShouldFailToParse(string inputValue)
        {
            var success = Size.TryParse(inputValue, out var size);

            success.Should().BeFalse();
        }
    }
}
