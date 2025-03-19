using FluentAssertions;

namespace Aria2.JsonRpcClient.Test
{
    public class JsonRpcParametersTests
    {
        [Fact]
        public void GIVEN_ArrayWithOnlyNulls_WHEN_ImplicitConversionFromObjectArray_THEN_ReturnsEmptyParameters()
        {
            object?[] values = { null, null };

            JsonRpcParameters parameters = values;

            parameters.Should().NotBeNull();
            parameters.Count.Should().Be(0);
        }

        [Fact]
        public void GIVEN_ArrayWithMixedValues_WHEN_ImplicitConversionFromObjectArray_THEN_ReturnsParametersWithoutNulls()
        {
            object?[] values = { "hello", null, 42 };

            JsonRpcParameters parameters = values;

            parameters.Should().NotBeNull();
            parameters.Count.Should().Be(2);
            parameters[0].Should().Be("hello");
            parameters[1].Should().Be(42);
        }

        [Fact]
        public void GIVEN_StringValue_WHEN_ImplicitConversionFromString_THEN_ReturnsParametersWithValue()
        {
            string value = "test";

            JsonRpcParameters parameters = value;

            parameters.Should().NotBeNull();
            parameters.Count.Should().Be(1);
            parameters[0].Should().Be("test");
        }

        [Fact]
        public void GIVEN_IntValue_WHEN_ImplicitConversionFromInt_THEN_ReturnsParametersWithValue()
        {
            int value = 99;

            JsonRpcParameters parameters = value;

            parameters.Should().NotBeNull();
            parameters.Count.Should().Be(1);
            parameters[0].Should().Be(99);
        }

        [Fact]
        public void GIVEN_EmptyProperty_WHEN_Accessed_THEN_ReturnsEmptyParameters()
        {
            JsonRpcParameters parameters = JsonRpcParameters.Empty;

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
