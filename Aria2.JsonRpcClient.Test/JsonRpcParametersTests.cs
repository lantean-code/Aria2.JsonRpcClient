using FluentAssertions;

namespace Aria2.JsonRpcClient.Test
{
    public class JsonRpcParametersTests
    {
        [Fact]
        public void GIVEN_ArrayWithOnlyNulls_WHEN_ImplicitConversionFromObjectArray_THEN_ReturnsNullParameters()
        {
            object?[] values = { null, null };

            JsonRpcParameters parameters = values;

            parameters.Should().NotBeNull();
            parameters.Count.Should().Be(2);
        }

        [Fact]
        public void GIVEN_ArrayWithMixedValues_WHEN_ImplicitConversionFromObjectArray_THEN_ReturnsParametersWithNulls()
        {
            object?[] values = { "hello", null, 42 };

            JsonRpcParameters parameters = values;

            parameters.Should().NotBeNull();
            parameters.Count.Should().Be(3);
            parameters[0].Should().Be("hello");
            parameters[1].Should().BeNull();
            parameters[2].Should().Be(42);
        }

        [Fact]
        public void GIVEN_StringValue_WHEN_ImplicitConversionFromString_THEN_ReturnsParametersWithValue()
        {
            var value = "test";

            JsonRpcParameters parameters = value;

            parameters.Should().NotBeNull();
            parameters.Count.Should().Be(1);
            parameters[0].Should().Be("test");
        }

        [Fact]
        public void GIVEN_IntValue_WHEN_ImplicitConversionFromInt_THEN_ReturnsParametersWithValue()
        {
            var value = 99;

            JsonRpcParameters parameters = value;

            parameters.Should().NotBeNull();
            parameters.Count.Should().Be(1);
            parameters[0].Should().Be(99);
        }

        [Fact]
        public void GIVEN_EmptyProperty_WHEN_Accessed_THEN_ReturnsEmptyParameters()
        {
            var parameters = JsonRpcParameters.Empty;

            parameters.Should().NotBeNull();
            parameters.Count.Should().Be(0);
        }

        [Fact]
        public void GIVEN_ParametersInstance_WHEN_AddCalled_THEN_IncreasesCount()
        {
            var parameters = new JsonRpcParameters();
            parameters.Add("value1");

            parameters.Count.Should().Be(1);
            parameters[0].Should().Be("value1");
        }

        [Fact]
        public void GIVEN_NullValue_WHEN_AddCalledDirectly_THEN_NullIsAdded()
        {
            var parameters = new JsonRpcParameters();
            parameters.Add<string?>(null);

            parameters.Count.Should().Be(1);
            parameters[0].Should().BeNull();
        }
    }
}
