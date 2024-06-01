namespace OES;

internal static class Ensure
{
    public static void ArgumentNotNullOrEmpty(string? arg, string argName)
    {
        if (string.IsNullOrEmpty(arg)) throw new ArgumentNullException(argName);
    }
}