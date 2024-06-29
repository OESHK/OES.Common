/***
 * All endpoints in this class should be sorted by their path.
 * All endpoints must start with a forward slash (/), they will be handled automatically when combining with base address.
 */

using System.Globalization;

namespace OES.Internal;

/// <summary>
/// Container for all API Endpoints OES API.
/// </summary>
internal static class ApiEndpoints
{
    public static Uri FormatUri(this string rawUri, params object[] values)
    {
        return values.Length == 0
            ? new Uri(rawUri, UriKind.Relative)
            : new Uri(string.Format(CultureInfo.InvariantCulture, rawUri, values), UriKind.Relative);
    }

    public static Uri GetApiInfo() => "/api_info".FormatUri();

    public static Uri Examinations() => "/examinations".FormatUri();

    public static Uri ExaminationById(int examinationId) => "/examinations/{0}".FormatUri(examinationId);

    public static Uri ExaminationCandidateEntries(int examinationId) =>
        "/examinations/{0}/candidates".FormatUri(examinationId);

    public static Uri OpenExamination(int examinationId) => "/examinations/{0}/open".FormatUri(examinationId);

    public static Uri MarkingPanelById(int panelId) => "/marking_panels/{0}".FormatUri(panelId);
}