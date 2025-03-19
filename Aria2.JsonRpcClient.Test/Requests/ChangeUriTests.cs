using Aria2.JsonRpcClient.Requests;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Requests
{
    public class ChangeUriTests
    {
        [Fact]
        public void GIVEN_WithGidFileIndexDelUrisAddUris_WHEN_Constructing_THEN_ShouldCreateJsonRequestWithCorrectNameAndParameters()
        {
            var gid = "gid123";
            int fileIndex = 1;
            IEnumerable<string> delUris = new[] { "http://example.com/del1", "http://example.com/del2" };
            IEnumerable<string> addUris = new[] { "http://example.com/add1", "http://example.com/add2" };

            var target = new ChangeUri(gid, fileIndex, delUris, addUris);

            target.Method.Should().Be("aria2.changeUri");
            target.Parameters.Should().HaveCount(5);
            target.Parameters[0].Should().Be(gid);
            target.Parameters[1].Should().Be(fileIndex);
            target.Parameters[2].Should().BeEquivalentTo(delUris);
            target.Parameters[3].Should().BeEquivalentTo(addUris);
            target.Parameters[4].Should().BeNull();
        }

        [Fact]
        public void GIVEN_WithGidFileIndexDelUrisAddUrisAndPosition_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var gid = "gid123";
            int fileIndex = 1;
            IEnumerable<string> delUris = new[] { "http://example.com/del1", "http://example.com/del2" };
            IEnumerable<string> addUris = new[] { "http://example.com/add1", "http://example.com/add2" };
            int position = 5;

            var target = new ChangeUri(gid, fileIndex, delUris, addUris, position: position);

            target.Method.Should().Be("aria2.changeUri");
            target.Parameters.Should().HaveCount(5);
            target.Parameters[0].Should().Be(gid);
            target.Parameters[1].Should().Be(fileIndex);
            target.Parameters[2].Should().BeEquivalentTo(delUris);
            target.Parameters[3].Should().BeEquivalentTo(addUris);
            target.Parameters[4].Should().Be(position);
        }

        [Fact]
        public void GIVEN_WithGidFileIndexDelUrisAddUrisAndId_WHEN_Constructing_THEN_CreateValidRequestWithParametersAtCorrectPositions()
        {
            var gid = "gid123";
            int fileIndex = 1;
            IEnumerable<string> delUris = new[] { "http://example.com/del1", "http://example.com/del2" };
            IEnumerable<string> addUris = new[] { "http://example.com/add1", "http://example.com/add2" };

            var target = new ChangeUri(gid, fileIndex, delUris, addUris, id: "testId");

            target.Method.Should().Be("aria2.changeUri");
            target.Parameters.Should().HaveCount(5);
            target.Parameters[0].Should().Be(gid);
            target.Parameters[1].Should().Be(fileIndex);
            target.Parameters[2].Should().BeEquivalentTo(delUris);
            target.Parameters[3].Should().BeEquivalentTo(addUris);
            target.Parameters[4].Should().BeNull();
            target.Id.Should().Be("testId");
        }
    }
}
