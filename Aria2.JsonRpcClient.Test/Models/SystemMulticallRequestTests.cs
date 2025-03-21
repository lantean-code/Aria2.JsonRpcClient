using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class SystemMulticallRequestTests
    {
        [Fact]
        public void GIVEN_NoNullOptions_WHEN_Serializing_ShouldConvertAllToCorrectValues()
        {
            var request = new SystemMulticallRequest
            {
                MethodName = "system.methodName",
                Parameters = ["param1", "42"]
            };

            var json = Serializer.Serialize(request);

            json.Should().Be("{\"methodName\":\"system.methodName\",\"params\":[\"param1\",\"42\"]}");
        }

        [Fact]
        public void GIVEN_MiddleNullOptions_WHEN_Serializing_ShouldConvertAllToCorrectValues()
        {
            var request = new SystemMulticallRequest
            {
                MethodName = "system.methodName",
                Parameters = ["param1", null, "42"]
            };

            var json = Serializer.Serialize(request);

            json.Should().Be("{\"methodName\":\"system.methodName\",\"params\":[\"param1\",null,\"42\"]}");
        }

        [Fact]
        public void GIVEN_TrailingNullOptions_WHEN_Serializing_ShouldConvertAllToCorrectValues()
        {
            var request = new SystemMulticallRequest
            {
                MethodName = "system.methodName",
                Parameters = ["param1", "42", null]
            };

            var json = Serializer.Serialize(request);

            json.Should().Be("{\"methodName\":\"system.methodName\",\"params\":[\"param1\",\"42\"]}");
        }
    }
}
