using Aria2.JsonRpcClient.Models;
using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class AddUriTests
    {
        [Fact]
        public void GIVEN_Uris_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectName()
        {
            var uris = new[] { "http://example.com/file1", "http://example.com/file2" };
            var target = new AddUri(uris);

            target.Method.Should().Be("aria2.addUri");
            target.Parameters[0].Should().BeEquivalentTo(uris);
        }

        [Fact]
        public void GIVEN_UrisAndOptions_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndOptions()
        {
            var uris = new[] { "http://example.com/file1", "http://example.com/file2" };
            var target = new AddUri(uris, new Aria2DownloadOptions { Dir = "Downloads" });

            target.Method.Should().Be("aria2.addUri");
            target.Parameters[0].Should().BeEquivalentTo(uris);
            target.Parameters[1].Should().BeEquivalentTo(new { Dir = "Downloads" });
        }

        [Fact]
        public void GIVEN_UrisAndPosition_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var uris = new[] { "http://example.com/file1", "http://example.com/file2" };
            var target = new AddUri(uris, position: 3);

            target.Method.Should().Be("aria2.addUri");
            target.Parameters[0].Should().BeEquivalentTo(uris);
            target.Parameters[1].Should().BeNull();
            target.Parameters[2].Should().Be(3);
        }

        [Fact]
        public void GIVEN_UrisAndId_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var uris = new[] { "http://example.com/file1", "http://example.com/file2" };
            var target = new AddUri(uris, id: "customId");

            target.Method.Should().Be("aria2.addUri");
            target.Parameters[0].Should().BeEquivalentTo(uris);
            target.Parameters[1].Should().BeNull();
            target.Parameters[2].Should().BeNull();
            target.Id.Should().Be("customId");
        }
    }
}
