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
        public void GIVEN_StringWithMegabytesUpperCase_WHEN_TryParseCalled_THEN_ReturnsValidSize()
        {
            bool success = Size.TryParse("1M", out var size);

            success.Should().BeTrue();
            size.Value.Should().Be(1);
            size.SizeType.Should().Be(SizeType.Megabytes);
        }

        [Fact]
        public void GIVEN_StringWithMegabytesLowerCase_WHEN_TryParseCalled_THEN_ReturnsValidSize()
        {
            bool success = Size.TryParse("1.234m", out var size);

            success.Should().BeTrue();
            size.Value.Should().BeApproximately(1.234, 0.001);
            size.SizeType.Should().Be(SizeType.Megabytes);
        }

        [Fact]
        public void GIVEN_StringWithKilobytesUpperCase_WHEN_TryParseCalled_THEN_ReturnsValidSize()
        {
            bool success = Size.TryParse("50K", out var size);

            success.Should().BeTrue();
            size.Value.Should().Be(50);
            size.SizeType.Should().Be(SizeType.Kilobytes);
        }

        [Fact]
        public void GIVEN_StringWithKilobytesLowerCase_WHEN_TryParseCalled_THEN_ReturnsValidSize()
        {
            bool success = Size.TryParse("75k", out var size);

            success.Should().BeTrue();
            size.Value.Should().Be(75);
            size.SizeType.Should().Be(SizeType.Kilobytes);
        }

        [Fact]
        public void GIVEN_StringWithInvalidUnit_WHEN_TryParseCalled_THEN_ReturnsFalse()
        {
            bool success = Size.TryParse("1G", out var size);

            success.Should().BeFalse();
        }

        [Fact]
        public void GIVEN_StringWithInvalidNumeric_WHEN_TryParseCalled_THEN_ReturnsFalse()
        {
            bool success = Size.TryParse("abcM", out var size);

            success.Should().BeFalse();
        }

        [Fact]
        public void GIVEN_EmptyString_WHEN_TryParseCalled_THEN_ThrowsIndexOutOfRangeException()
        {
            Action act = () => Size.TryParse("", out var size);

            act.Should().Throw<IndexOutOfRangeException>();
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
    }
}
