using System.Text.Json;
using Aria2.JsonRpcClient.Models;
using FluentAssertions;

namespace Aria2.JsonRpcClient.Test.Models
{
    public class Aria2ErrorCodeTests
    {
        [Theory]
        [InlineData("0", Aria2ErrorCode.Success)]
        [InlineData("1", Aria2ErrorCode.UnknownError)]
        [InlineData("2", Aria2ErrorCode.Timeout)]
        [InlineData("3", Aria2ErrorCode.ResourceNotFound)]
        [InlineData("4", Aria2ErrorCode.MaxFileNotFoundExceeded)]
        [InlineData("5", Aria2ErrorCode.DownloadTooSlow)]
        [InlineData("6", Aria2ErrorCode.NetworkProblem)]
        [InlineData("7", Aria2ErrorCode.UnfinishedDownloads)]
        [InlineData("8", Aria2ErrorCode.ResumeNotSupported)]
        [InlineData("9", Aria2ErrorCode.NotEnoughDiskSpace)]
        [InlineData("10", Aria2ErrorCode.PieceLengthMismatch)]
        [InlineData("11", Aria2ErrorCode.DownloadingSameFile)]
        [InlineData("12", Aria2ErrorCode.DownloadingSameTorrent)]
        [InlineData("13", Aria2ErrorCode.FileAlreadyExists)]
        [InlineData("14", Aria2ErrorCode.FileRenameFailed)]
        [InlineData("15", Aria2ErrorCode.CannotOpenFile)]
        [InlineData("16", Aria2ErrorCode.CannotCreateOrTruncateFile)]
        [InlineData("17", Aria2ErrorCode.FileIOError)]
        [InlineData("18", Aria2ErrorCode.CannotCreateDirectory)]
        [InlineData("19", Aria2ErrorCode.NameResolutionFailed)]
        [InlineData("20", Aria2ErrorCode.MetalinkParseError)]
        [InlineData("21", Aria2ErrorCode.FTPCommandFailed)]
        [InlineData("22", Aria2ErrorCode.BadHttpResponseHeader)]
        [InlineData("23", Aria2ErrorCode.TooManyRedirects)]
        [InlineData("24", Aria2ErrorCode.HttpAuthorizationFailed)]
        [InlineData("25", Aria2ErrorCode.BencodeParseError)]
        [InlineData("26", Aria2ErrorCode.TorrentFileCorrupted)]
        [InlineData("27", Aria2ErrorCode.BadMagnetUri)]
        [InlineData("28", Aria2ErrorCode.BadOrUnexpectedOption)]
        [InlineData("29", Aria2ErrorCode.RemoteServerOverloaded)]
        [InlineData("30", Aria2ErrorCode.JsonRpcParseError)]
        [InlineData("31", Aria2ErrorCode.Reserved)]
        [InlineData("32", Aria2ErrorCode.ChecksumValidationFailed)]
        public void GIVEN_InputAsString_WHEN_Deserializing_THEN_ReturnsExpected(string input, Aria2ErrorCode expected)
        {
            JsonSerializer.Deserialize<Aria2ErrorCode>($"\"{input}\"", Aria2ClientSerialization.Options).Should().Be(expected);
        }

        [Theory]
        [InlineData(0, Aria2ErrorCode.Success)]
        [InlineData(1, Aria2ErrorCode.UnknownError)]
        [InlineData(2, Aria2ErrorCode.Timeout)]
        [InlineData(3, Aria2ErrorCode.ResourceNotFound)]
        [InlineData(4, Aria2ErrorCode.MaxFileNotFoundExceeded)]
        [InlineData(5, Aria2ErrorCode.DownloadTooSlow)]
        [InlineData(6, Aria2ErrorCode.NetworkProblem)]
        [InlineData(7, Aria2ErrorCode.UnfinishedDownloads)]
        [InlineData(8, Aria2ErrorCode.ResumeNotSupported)]
        [InlineData(9, Aria2ErrorCode.NotEnoughDiskSpace)]
        [InlineData(10, Aria2ErrorCode.PieceLengthMismatch)]
        [InlineData(11, Aria2ErrorCode.DownloadingSameFile)]
        [InlineData(12, Aria2ErrorCode.DownloadingSameTorrent)]
        [InlineData(13, Aria2ErrorCode.FileAlreadyExists)]
        [InlineData(14, Aria2ErrorCode.FileRenameFailed)]
        [InlineData(15, Aria2ErrorCode.CannotOpenFile)]
        [InlineData(16, Aria2ErrorCode.CannotCreateOrTruncateFile)]
        [InlineData(17, Aria2ErrorCode.FileIOError)]
        [InlineData(18, Aria2ErrorCode.CannotCreateDirectory)]
        [InlineData(19, Aria2ErrorCode.NameResolutionFailed)]
        [InlineData(20, Aria2ErrorCode.MetalinkParseError)]
        [InlineData(21, Aria2ErrorCode.FTPCommandFailed)]
        [InlineData(22, Aria2ErrorCode.BadHttpResponseHeader)]
        [InlineData(23, Aria2ErrorCode.TooManyRedirects)]
        [InlineData(24, Aria2ErrorCode.HttpAuthorizationFailed)]
        [InlineData(25, Aria2ErrorCode.BencodeParseError)]
        [InlineData(26, Aria2ErrorCode.TorrentFileCorrupted)]
        [InlineData(27, Aria2ErrorCode.BadMagnetUri)]
        [InlineData(28, Aria2ErrorCode.BadOrUnexpectedOption)]
        [InlineData(29, Aria2ErrorCode.RemoteServerOverloaded)]
        [InlineData(30, Aria2ErrorCode.JsonRpcParseError)]
        [InlineData(31, Aria2ErrorCode.Reserved)]
        [InlineData(32, Aria2ErrorCode.ChecksumValidationFailed)]
        public void GIVEN_InputAsInt_WHEN_Deserializing_THEN_ReturnsExpected(int input, Aria2ErrorCode expected)
        {
            JsonSerializer.Deserialize<Aria2ErrorCode>(input, Aria2ClientSerialization.Options).Should().Be(expected);
        }
    }
}
