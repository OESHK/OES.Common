/***
 * All endpoints in this class should be sorted by their path
 */

using System.Globalization;

namespace OES.Internal;

/// <summary>
/// Container for all API Endpoints OES API.
/// </summary>
public static class ApiEndpoints
{
    public static Uri FormatUri(this string rawUri, params object[] values)
    {
        return new Uri(string.Format(CultureInfo.InvariantCulture, rawUri, values), UriKind.Relative);
    }

    public static Uri GetApiInfo()
    {
        return "/api_info".FormatUri();
    }
}