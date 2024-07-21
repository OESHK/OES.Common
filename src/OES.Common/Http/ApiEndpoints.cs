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

    public static Uri GetApiInfo() => 
        "/api_info".FormatUri();

    public static Uri Examinations() =>
        "/examinations".FormatUri();

    public static Uri ExaminationById(int examinationId) => 
        "/examinations/{0}".FormatUri(examinationId);

    public static Uri ExaminationCandidateEntries(int examinationId) =>
        "/examinations/{0}/candidates".FormatUri(examinationId);

    public static Uri ExaminationCandidateEntriesById(int examinationId, string candidateId) =>
        "/examinations/{0}/candidates/{1}".FormatUri(examinationId, candidateId);

    public static Uri MarkingPanels(int examinationId) =>
        "/examinations/{0}/marking_panels".FormatUri(examinationId);

    public static Uri MarkingPanelById(int examinationId, int panelId) =>
        "/examinations/{0}/marking_panels/{1}".FormatUri(examinationId, panelId);

    public static Uri MarkingPanelMembersGeneralMarkers(int examinationId, int panelId) =>
        "/examinations/{0}/marking_panels/{1}/members/markers".FormatUri(examinationId, panelId);

    public static Uri MarkingPanelMembersGeneralMarkerById(int examinationId, int panelId, string markerId) =>
        "/examinations/{0}/marking_panels/{1}/members/markers/{2}".FormatUri(examinationId, panelId, markerId);

    public static Uri MarkingPanelMembersSupervisors(int examinationId, int panelId) =>
        "/examinations/{0}/marking_panels/{1}/members/supervisors".FormatUri(examinationId, panelId);

    public static Uri MarkingPanelMembersSupervisorById(int examinationId, int panelId, string markerId) =>
        "/examinations/{0}/marking_panels/{1}/members/supervisors/{2}".FormatUri(examinationId, panelId, markerId);

    public static Uri OpenExamination(int examinationId) =>
        "/examinations/{0}/open".FormatUri(examinationId);

    public static Uri ExamScriptDefinitions(int examinationId) =>
        "/examinations/{0}/script_defs".FormatUri(examinationId);

    public static Uri ExamScriptDefinitionById(int examinationId, int definitionId) =>
        "/examinations/{0}/script_defs/{1}".FormatUri(examinationId, definitionId);

    public static Uri MCSheetDefinition(int examinationId, int scriptDefinitionId) =>
        "/examinations/{0}/script_defs/{1}/mc_sheet_def".FormatUri(examinationId, scriptDefinitionId);

    public static Uri MCQuestionDefinitions(int examinationId, int scriptDefinitionId) =>
        "/examinations/{0}/script_defs/{1}/question_defs/mcqs".FormatUri(examinationId, scriptDefinitionId);

    public static Uri MCQuestionDefinitionById(int examinationId, int scriptDefinitionId, int mcqDefinitionId) =>
        "/examinations/{0}/script_defs/{1}/question_defs/mcqs/{2}".FormatUri(examinationId, scriptDefinitionId, mcqDefinitionId);

    public static Uri NonMCQuestionDefinitions(int examinationId, int scriptDefinitionId) =>
        "/examinations/{0}/script_defs/{1}/question_defs/non_mcqs".FormatUri(examinationId, scriptDefinitionId);

    public static Uri NonMCQuestionDefinitionById(int examinationId, int scriptDefinitionId, int nonMCQuestionDefinitionId) =>
        "/examinations/{0}/script_defs/{1}/question_defs/non_mcqs/{2}".FormatUri(examinationId, scriptDefinitionId, nonMCQuestionDefinitionId);

    public static Uri ScriptSliceDefinitions(int examinationId, int scriptDefinitionId) =>
        "/examinations/{0}/script_defs/{1}/slice_defs".FormatUri(examinationId, scriptDefinitionId);

    public static Uri ScriptSliceDefinitionById(int examinationId, int scriptDefinitionId, int sliceDefinitionId) =>
        "/examinations/{0}/script_defs/{1}/slice_defs/{2}".FormatUri(examinationId, scriptDefinitionId, sliceDefinitionId);
    
    public static Uri QuestionNumberBoxDefinitions() =>
        "/qnb_defs".FormatUri();

    public static Uri QuestionNumberBoxDefinitionById(int qnbDefinitionId) =>
        "/qnb_defs/{0}".FormatUri(qnbDefinitionId);
}