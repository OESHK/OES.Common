namespace OES;

internal static class Ensure
{
    public static void ArgumentNotNullOrEmpty(string? arg, string argName)
    {
        if (string.IsNullOrEmpty(arg)) throw new ArgumentNullException(argName);
    }

    public static void ArgumentNotNull(object? obj, string argName)
    {
        if (obj is null) throw new ArgumentNullException(argName);
    }
}