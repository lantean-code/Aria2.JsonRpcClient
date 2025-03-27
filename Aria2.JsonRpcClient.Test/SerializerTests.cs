using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test
{
    public class SerializerTests
    {
        private record Custom
        {
            [JsonPropertyName("id")]
            public required string Id { get; init; }
        }

        [Fact]
        public void GIVEN_GetTypeInfoReturnsNull_WHEN_DeserializingStringToCustom_THEN_ShouldFallbackToReflectionDeserializing()
        {
            var json = "{\"id\":\"test\"}";
            var obj = Serializer.Deserialize<Custom>(json);
            obj.Should().NotBeNull();
            obj.Id.Should().Be("test");
        }

        [Fact]
        public void GIVEN_GetTypeInfoReturnsNull_WHEN_DeserializingJsonNodeToCustom_THEN_ShouldFallbackToReflectionDeserializing()
        {
            var json = "{\"id\":\"test\"}";
            var obj = Serializer.Deserialize<Custom>(JsonNode.Parse(json)!);
            obj.Should().NotBeNull();
            obj.Id.Should().Be("test");
        }

        [Fact]
        public void GIVEN_GetTypeInfoReturnsNull_WHEN_DeserializingJsonElementToCustom_THEN_ShouldFallbackToReflectionDeserializing()
        {
            var json = "{\"id\":\"test\"}";
            JsonElement jsonElement;
            using (var doc = JsonDocument.Parse(json))
            {
                jsonElement = doc.RootElement.Clone();
            }
            var obj = Serializer.Deserialize<Custom>(jsonElement);
            obj.Should().NotBeNull();
            obj.Id.Should().Be("test");
        }

        [Fact]
        public void GIVEN_GetTypeInfoReturnsNull_WHEN_DeserializingJsonElementToCustomAsObject_THEN_ShouldFallbackToReflectionDeserializing()
        {
            var json = "{\"id\":\"test\"}";
            JsonElement jsonElement;
            using (var doc = JsonDocument.Parse(json))
            {
                jsonElement = doc.RootElement.Clone();
            }
            var obj = (Custom?)Serializer.Deserialize(jsonElement, typeof(Custom));
            obj.Should().NotBeNull();
            obj.Id.Should().Be("test");
        }

        [Fact]
        public void GIVEN_GetTypeInfoReturnsNull_WHEN_DeserializingStringToNullCustom_THEN_ShouldThrowException()
        {
            var json = "null";
            var act = () => Serializer.Deserialize<Custom>(json);
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid JSON-RPC response.");
        }

        [Fact]
        public void GIVEN_GetTypeInfoReturnsNull_WHEN_DeserializingJsonNodeToNullCustom_THEN_ShouldThrowException()
        {
            var json = "null";
            var act = () => Serializer.Deserialize<Custom>(JsonNode.Parse(json)!);
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid JSON-RPC response.");
        }

        [Fact]
        public void GIVEN_GetTypeInfoReturnsNull_WHEN_DeserializingJsonElementToNullCustom_THEN_ShouldThrowException()
        {
            var json = "null";
            JsonElement jsonElement;
            using (var doc = JsonDocument.Parse(json))
            {
                jsonElement = doc.RootElement.Clone();
            }
            var act = () => Serializer.Deserialize<Custom>(jsonElement);
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid JSON-RPC response.");
        }

        [Fact]
        public void GIVEN_GetTypeInfoReturnsNull_WHEN_DeserializingJsonElementToNullCustomAsObject_THEN_ShouldThrowException()
        {
            var json = "null";
            JsonElement jsonElement;
            using (var doc = JsonDocument.Parse(json))
            {
                jsonElement = doc.RootElement.Clone();
            }
            var act = () => (Custom?)Serializer.Deserialize(jsonElement, typeof(Custom));
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid JSON-RPC response.");
        }

        [Fact]
        public void GIVEN_GetTypeInfoReturnsNull_WHEN_Serializing_THEN_ShouldReturnString()
        {
            var obj = new Custom { Id = "test" };

            var json = Serializer.Serialize(obj);

            json.Should().Be("{\"id\":\"test\"}");
        }
    }
}
