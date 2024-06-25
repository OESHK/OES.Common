namespace OES;

/// <summary>
/// The exception that is thrown when the OES API server connected uses a version that this class library does not support.
/// </summary>
public class UnsupportedApiVersionException : Exception
{
    public UnsupportedApiVersionException(string remoteVersion, string[] supportedVersions) : base(GenerateMessage(remoteVersion, supportedVersions))
    {
    }

    private static string GenerateMessage(string remoteVersion, string[] supportedVersions)
        =>
            $"The server is using an OES API version of \"{remoteVersion}\", which is incompatible with the current OES.Common library."
            + $"Supported versions are: {supportedVersions.Aggregate((previous, current) => previous + ", " + current)}";
}